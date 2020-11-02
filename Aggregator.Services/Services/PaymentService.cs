using Aggregator.Domain.Enums;
using Aggregator.Domain.Models;
using Aggregator.Repository.Repositories.Base;
using Aggregator.Services.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aggregator.Services
{
    public class PaymentService
    {
        private readonly UserInfoService _userInfoService;
        private readonly DbRepository _db;

        public PaymentService()
        {
            _userInfoService = new UserInfoService();
            _db = new DbRepository();
        }

        public ByTicketResult ByTikets(BuyTicketsDto buyTicketDto, UserInfoDto userInfoDto, CouponDto coupon)
        {
            ByTicketResult byTicketResult = new ByTicketResult();
            Сustomer customer = _userInfoService.GetOrCreateCustomer(userInfoDto);
            
            //get tikets
            List<string> tiketsIds = new List<string>(buyTicketDto.Tikets.Select(x => x.Id));
            var tikets = _db.ChicagoTikets.GetByListIds(tiketsIds);

            // calculate the cost
            double cost = 0;
            double sale = 0;
            // additional charges
            double AdditionalCharges = 0;
            if (buyTicketDto.SuperPass)
            {
                AdditionalCharges += 20;
            }
            if (buyTicketDto.Insurance)
            {
                AdditionalCharges += 2;
            }

            if (coupon != null  && coupon.SaleProcent > 0)
            {
                sale = coupon.SaleProcent / 100;
            }

            foreach (var item in tikets)
            {
                var currentTiket = buyTicketDto.Tikets.First(x => x.Id == item.Id);
                double mainSum = currentTiket.Age.Adult * (item.AdultCost + TortureMuseumAudioGuide(item, buyTicketDto.AudioGuide) + AdditionalCharges);
                mainSum += currentTiket.Age.Child * (item.ChildCost + TortureMuseumAudioGuide(item, buyTicketDto.AudioGuide) + AdditionalCharges);
                cost += mainSum - ( mainSum * sale);
            }
            buyTicketDto.Amount = (decimal)cost;

            buyTicketDto.Amount += (buyTicketDto.Amount * buyTicketDto.CityProcent) / 100;
            // payment process
            var chargeCreditCard = new ChargeCreditCard();
            var transaction = chargeCreditCard.Run(buyTicketDto, customer);
           // transaction.ErrorCode = string.Empty;
            _db.Transactions.Add(transaction);

            byTicketResult.Transaction = transaction;

            if (string.IsNullOrEmpty(transaction.ErrorCode) && coupon != null)
            {
                var couponDb = _db.Coupons.FindById(coupon.Id);
                if (couponDb.Counter == null || couponDb.Counter == 0)
                {
                    couponDb.Counter = 1;
                }
                else
                {
                    couponDb.Counter ++;
                }
               
                _db.Coupons.Update(couponDb);
            }

            List <CustomerTiket> customerTikets = new List<CustomerTiket>();
            if (!string.IsNullOrEmpty(transaction.ErrorCode))
            {
                foreach (var item in tikets)
                {
                    var currentTiket = buyTicketDto.Tikets.First(x => x.Id == item.Id);
                    if (currentTiket.Age.Adult > 0)
                    {
                        var tmp = new CustomerTiket();
                        tmp.TiketId = item.Id;
                        tmp.CustomerId = customer.Id;
                        double mainSum = currentTiket.Age.Adult * (item.AdultCost + TortureMuseumAudioGuide(item, buyTicketDto.AudioGuide));
                        tmp.Cost = mainSum - (mainSum * sale);
                        tmp.Count = currentTiket.Age.Adult;
                        tmp.AgeCategory = "Adult";
                        tmp.Status =  CustomerTiketStatus.Succes.ToString();
                        if (coupon != null)
                        {
                            tmp.SpesialPropositionId = coupon.SaleProcent > 0 ? string.Empty : coupon.SpecialPropositionId;
                        }
                        tmp.Sale = sale;
                        tmp.IsAudioGuide = IsTortureMuseum(item) && buyTicketDto.AudioGuide;
                        tmp.SuperPass = buyTicketDto.SuperPass;
                        tmp.Insurance = buyTicketDto.Insurance;
                        customerTikets.Add(tmp);
                    }
                    if (currentTiket.Age.Child > 0)
                    {
                        var tmp = new CustomerTiket();
                        tmp.TiketId = item.Id;
                        tmp.CustomerId = customer.Id;
                        double mainSum = currentTiket.Age.Child * (item.ChildCost + TortureMuseumAudioGuide(item, buyTicketDto.AudioGuide));
                        tmp.Cost = mainSum - (mainSum * sale);
                        tmp.Count = currentTiket.Age.Child;
                        tmp.AgeCategory = "Child";
                        tmp.Status = CustomerTiketStatus.Succes.ToString();
                        if (coupon != null)
                        {
                            tmp.SpesialPropositionId = coupon.SaleProcent > 0 ? string.Empty : coupon.SpecialPropositionId;
                        }
                        tmp.Sale = sale;
                        tmp.IsAudioGuide = IsTortureMuseum(item) && buyTicketDto.AudioGuide;
                        tmp.SuperPass = buyTicketDto.SuperPass;
                        tmp.Insurance = buyTicketDto.Insurance;
                        customerTikets.Add(tmp);
                    }

                }
            }
               
            _db.CustomerTikets.AddRange(customerTikets);
            byTicketResult.CustomerTikets = customerTikets;
            return byTicketResult;
        }


        private double TortureMuseumAudioGuide(ChicagoTiket tiket, bool exist)
        {
            if (!exist)
            {
                return 0;
            }

            if(IsTortureMuseum(tiket))
            {
                return 1.99;
            }
            return 0;
        }

        public bool IsTortureMuseum(ChicagoTiket tiket)
        {
            List<string> torchureMuseums = new List<string>();
            torchureMuseums.Add("f85d41b3-6abc-4887-929c-5afc8a45f2f6");
            torchureMuseums.Add("bac57114-9277-457c-accd-06f8f09470d1");
            torchureMuseums.Add("8dc10747-ac92-4d1f-9ba5-c4bf21c21b3f");
            return torchureMuseums.Any(x => x == tiket.Id);
        }
    }
}
