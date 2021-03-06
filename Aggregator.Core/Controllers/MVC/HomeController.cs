﻿using System;
using System.Collections.Generic;
using System.Drawing;
using AutoMapper;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aggregator.Core.Utility;
using Aggregator.Domain.Enums;
using Aggregator.Helpers;
using Aggregator.Models;
using Aggregator.Services;
using Aggregator.Services.ModelsDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QRCoder;
using Rotativa.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.AspNetCore.Hosting.Internal;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.ObjectPool;
using System.Diagnostics;
using Microsoft.AspNetCore.Routing;
using Aggregator.Services.Services;
using Aggregator.Domain.Models;

namespace Aggregator.Controllers.MVC
{
    public class HomeController : Controller
    {
        private readonly CouponService _couponService;
        private readonly LockedService _lockedService;
        private readonly TiketService _tiketService;
        private readonly SelectedTicketServices _selectedTicketServices;
        private readonly IHttpContextAccessor _accessor;

        public HomeController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _tiketService = new TiketService();
            _couponService = new CouponService();
            _lockedService = new LockedService();
            _selectedTicketServices = new SelectedTicketServices();
        }

        public IActionResult Basket(string PromoCode)
        {
            var viewModel = new BuyTicketViewModel();
            viewModel.PromoCode = PromoCode;
            viewModel.Tikets = "[{\"Id\":2, \"Age\": { \"Adult\":12, \"Child\":8}}]";

            string userIp = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var loked = _lockedService.GetOrCreate(userIp);
            viewModel.Capcha = loked.Counter > 3;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SendToPayment(BuyTicketViewModel viewModel)
        {
            var buyTicketDto = new BuyTicketsDto();

            string userIp = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var loked = _lockedService.GetOrCreate(userIp);
            if (loked.Counter > 3)
            {
                if (!await GoogleRecaptchaHelper.IsReCaptchaPassedAsync(Request.Form["g-recaptcha-response"], "6LfDaKMUAAAAANBMRfr0PKYou2JyqWgYHHwgrOEo"))
                {

                    ModelState.AddModelError(string.Empty, "You failed the CAPTCHA");
                    viewModel.Messages = new List<MessageViewModel>();
                    viewModel.Messages.Add(new MessageViewModel()
                    {
                        Key = "CAPTCHA",
                        Text = "You failed the CAPTCHA",
                        IsException = true
                    });
                    return View("Basket", viewModel);
                }
            }




            // add card
            var mapperCard = new MapperConfiguration(cfg => cfg.CreateMap<CardViewModel, CardDto>()).CreateMapper();
            buyTicketDto.Card = mapperCard.Map<CardViewModel, CardDto>(viewModel.Card);
            if (!string.IsNullOrEmpty(viewModel.Card.ExpiresEnd))
            {
                buyTicketDto.Card.ExpirationDate = viewModel.Card.ExpiresEnd.Replace(@"/", string.Empty);
            }

            // add tikets
            buyTicketDto.Tikets = new List<TiketInfo>();
           
            buyTicketDto.Tikets = JsonConvert.DeserializeObject<List<TiketInfo>>(viewModel.Tikets);
            var temp = buyTicketDto.Tikets;
            buyTicketDto.Tikets = new List<TiketInfo>();
            foreach (var item in temp)
            {
                if (item.Age.Adult > 0 || item.Age.Child > 0)
                    buyTicketDto.Tikets.Add(item);
            }

            // add coupun if have
            CouponDto coupon = null;
            if (!string.IsNullOrEmpty(viewModel.PromoCode))
            {
                coupon = _couponService.GetByPromoCode(viewModel.PromoCode);
                if (viewModel.City == "Chicago IL" && coupon.City != City.Chicago.ToString())
                {
                    coupon = null;
                }
                if (viewModel.City == "St. Augistine" && coupon.City != City.Augistine.ToString())
                {
                    coupon = null;
                }
            }

            // add user info
            UserInfoDto userInfo = new UserInfoDto();
            userInfo.Email = viewModel.UserInfo.Email;
            userInfo.Phone = viewModel.UserInfo.Phone;
            userInfo.Surname = viewModel.UserInfo.Surname;
            userInfo.Name = viewModel.UserInfo.Name;

            // add AudioGuide 
            buyTicketDto.AudioGuide = Convert.ToBoolean(viewModel.AudioGuide);
            buyTicketDto.SuperPass = Convert.ToBoolean(viewModel.SuperTiket);
            buyTicketDto.Insurance = Convert.ToBoolean(viewModel.Insurance);

            // set sity
            buyTicketDto.CityProcent = 110;
            if (viewModel.City == "Chicago")
            {
                buyTicketDto.CityProcent = 6.25m;

            }
            if (viewModel.City == "Augistine")
            {
                buyTicketDto.CityProcent = 6.5m;
            }
            if (buyTicketDto.CityProcent == 110)
            {
                ModelState.AddModelError(string.Empty, "You failed the choose a city");
                viewModel.Messages = new List<MessageViewModel>();
                viewModel.Messages.Add(new MessageViewModel()
                {
                    Key = "City",
                    Text = "Choose a city",
                    IsException = true
                });
                return View("Basket", viewModel);
            }

            PaymentService paymentService = new PaymentService();
            var result = paymentService.ByTikets(buyTicketDto, userInfo, coupon);
            result.Transaction.ErrorCode = string.Empty;


            return await SpendUserResult(result, userInfo, viewModel.PromoCode, viewModel.City);
        }

        private byte[] CreateQrcode(string text)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            var bitmapBytes = BitmapToBytes(qrCodeImage); //Convert bitmap into a byte array\
            return bitmapBytes;
        }

        private static byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        public async Task<IActionResult> SpendUserResult(ByTicketResult result, UserInfoDto userInfo, string PromoCode, string city)
        {
            string userIp = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var loked = _lockedService.GetOrCreate(userIp);

            if (string.IsNullOrEmpty(result.Transaction.ErrorCode))
            {
                _lockedService.RemoveLockedById(loked.Id);
                string htmlMessage = @"Thank you! You bought some tickets. Check attached to this message PDF file for your tickets.<br/>";
                var tikets = _tiketService.GetTiketsByIds(result.CustomerTikets.Select(x => x.TiketId).ToList());

                int i = 1;
                foreach (var item in result.CustomerTikets)
                {
                    var tmpUrl = Url.Page(
                      "/Home/TicketsPurchased",
                      pageHandler: null,
                      values: new { id = item.Id },
                      protocol: Request.Scheme);

                    var tiket = tikets.First(x => x.Id == item.TiketId);

                    htmlMessage += $@"{i}) Name: {tiket.Text};<br/> Total : {item.Cost}; <br/>
                                     Date : {item.CreationDate};<br>
                                     <a href='tmpUrl'>Link on tiket</a>.   <br>";
                    i++;
                }

                TicketsToPDFViewModel tickets = new TicketsToPDFViewModel();
                tickets.Tickets = new List<TicketToPdfViewModel>();
                // var img =    CreateQrcode();
                string hostname = Request.Host.Value;
                foreach (var item in result.CustomerTikets)
                {
                    var currentTicket = tikets.First(x => x.Id == item.TiketId);
                    TicketToPdfViewModel tmp = new TicketToPdfViewModel();
                    tmp.AgeCategory = item.AgeCategory;
                    tmp.Cost = item.Cost.ToString();
                    tmp.Count = item.Count.ToString();
                    tmp.TiketId = item.TiketId;
                    tmp.HaveAudioGuide = item.IsAudioGuide;
                    tmp.CreationDate = item.CreationDate;
                    tmp.Email = userInfo.Email;
                    tmp.Name = userInfo.Name;
                    tmp.Phone = userInfo.Phone;
                    tmp.Surname = userInfo.Surname;
                    tmp.TicketName = currentTicket.Text;
                    tmp.TicketImgUrl = currentTicket.ImageId;
                    tmp.ImageQr = CreateQrcode($"http://{hostname}/Admin/DetailsTicket/" + item.Id);
                    tmp.City = city;
                    tickets.Tickets.Add(tmp);
                }

                var viewAsPDF = new ViewAsPdf("TicketsInPDF", tickets);
                var pdfFileByteArray = await viewAsPDF.BuildFile(ControllerContext);
                Stream stream = new MemoryStream(pdfFileByteArray);

                await EmailSender.SendEmailAsync(userInfo.Email, "Ticket Purchase", htmlMessage, stream);

                // return new ViewAsPdf("TicketsInPDF", tickets);
                var viewModel = new BuyTicketViewModel();
                viewModel.Messages = new List<MessageViewModel>();
                viewModel.Messages.Add(new MessageViewModel()
                {
                    Key = "Done.",
                    Text = "Your purchase is okay, yours tickets sent to your email.",
                    IsException = false
                });
                _selectedTicketServices.DeleteByIp(userIp);
                return View("TicketsInPDF", tickets);
            }
            else
            {

                TicketsToPDFViewModel tickets = new TicketsToPDFViewModel();
                tickets.Transaction = result.Transaction;

                //var viewAsPDF = new ViewAsPdf("TicketsInPDF", tickets);
                //var pdfFileByteArray = await viewAsPDF.BuildFile(ControllerContext);
                //Stream stream = new MemoryStream(pdfFileByteArray);

                //string htmlMessage = $"<div><h2> When you tried to buy a ticket(s) errors occurred</h2>" +
                //    $"<b>Please check the input data </b><br /> ";
                //await EmailSender.SendEmailAsync(userInfo.Email, "Ticket Purchase", htmlMessage, stream);


                // return to busket 
                var lokedUp = _lockedService.UpdateLoked(userIp);

                var viewModel = new BuyTicketViewModel();
                viewModel.PromoCode = PromoCode;
                viewModel.Capcha = lokedUp.Counter > 3;
                viewModel.Messages = new List<MessageViewModel>();
                viewModel.Messages.Add(new MessageViewModel()
                {
                    Key = "User Card",
                    Text = "Tickets are not purchased, there are problems with payment",
                    IsException = true
                });
                return View("Basket", viewModel);

            }

        }

        public IActionResult GetTikets(string сity, string PromoCode)
        {
            CouponDto coupon = null;
            if (!string.IsNullOrEmpty(PromoCode))
            {
                coupon = _couponService.GetByPromoCode(PromoCode);
            }

            //List<string> Ids = new List<string>(Id.Split(';'));
            //Ids.Remove("");p

            List<TiketDto> tiketsDtos = new List<TiketDto>();
            if (сity == City.Augistine.ToString())
            {
                tiketsDtos = _tiketService.GetAllAugistineTikets();
            }
            if (сity == City.Chicago.ToString())
            {
                tiketsDtos = _tiketService.GetAllChicagoTikets();
            }

            if (tiketsDtos == null || tiketsDtos.Count < 1)
            {
                return new EmptyResult();
            }
            var viewModel = new List<TiketViewModel>();
            if (tiketsDtos != null)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TiketDto, TiketViewModel>()).CreateMapper();
                viewModel = mapper.Map<List<TiketDto>, List<TiketViewModel>>(tiketsDtos);
            }

            foreach (var item in viewModel)
            {
                if (item.Id == "bac57114-9277-457c-accd-06f8f09470d1")
                {
                    item.Text = item.Text.Replace("\n", "<br />");
                }

                if (coupon != null && coupon.SaleProcent > 0)
                {
                    double sale = coupon.SaleProcent / 100;

                    item.ChildSale = sale * item.ChildCost;
                    item.AdultCost = sale * item.AdultCost;
                }
            }


            return Json(viewModel);
        }

        public IActionResult TicketsInPDF()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetTicket([FromBody]object ticket)
        {
            SelectedTicket selectedTicket = new SelectedTicket();
            selectedTicket.Tickets = ticket.ToString();
            selectedTicket.Id = Guid.NewGuid().ToString();
            selectedTicket.UserId = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            _selectedTicketServices.Add(selectedTicket);

            return Ok(new { text = "Success" });
        }

        public IActionResult GetTicketsByIp()
        {
            var ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();

           return Ok(_selectedTicketServices.GetByIP(ip).OrderBy(c => c.CreationDate));
        }

        public IActionResult DeleteTickets()
        {
            _selectedTicketServices.DeleteByIp(_accessor.HttpContext.Connection.RemoteIpAddress.ToString());

            return Ok();
        }

        public IActionResult Augustine()
        {
            return View();
        }
    }
}
