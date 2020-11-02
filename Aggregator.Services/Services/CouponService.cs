using Aggregator.Domain.Models;
using Aggregator.Repository.Repositories.Base;
using Aggregator.Services.ModelsDto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Services
{
    public class CouponService
    {
        private readonly DbRepository _db;
        public CouponService()
        {
            _db = new DbRepository();
        }

        public void  Create(CreateCouponDto couponDto)
        {
            var coupons = _db.Coupons.GetAll();
            if(coupons.Any(x => x.Text == couponDto.Text))
            {
                throw new Exception(" Text is not unique");
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CreateCouponDto, Coupon>()).CreateMapper();
            Coupon entity = mapper.Map<CreateCouponDto, Coupon>(couponDto);
             _db.Coupons.Add(entity);
        }

        public  List<CouponDto> GetAll(  )
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Coupon, CouponDto>()).CreateMapper();
            var coupons =  _db.Coupons.GetAll();
            var result = mapper.Map<List<Coupon>, List<CouponDto>>(coupons);
            return result;
        }

        public void DeleteAllEnds()
        {
            var coupons = _db.Coupons.GetAll();
            var removsCoupons = coupons.Where(x => x.ClosingDate < DateTime.Now);

            foreach (var item in removsCoupons)
            {
                _db.Coupons.Remove(item);
            }
        }

        public CouponDto GetById(string id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Coupon, CouponDto>()).CreateMapper();
            var coupon = _db.Coupons.FindById(id);
            var result = mapper.Map<Coupon, CouponDto>(coupon);
            return result;
        }

        public void Update(CouponDto couponDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CouponDto, Coupon>()).CreateMapper();
            Coupon entity = mapper.Map<CouponDto, Coupon>(couponDto);
            _db.Coupons.Update(entity);
        }

        public CouponDto GetByPromoCode(string promoCode)
        {
            Coupon entity =  _db.Coupons.GetByPromoCode(promoCode);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Coupon, CouponDto>()).CreateMapper();
            var result = mapper.Map<Coupon, CouponDto>(entity);
            return result;
        }
    }
}
