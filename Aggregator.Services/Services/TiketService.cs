using Aggregator.Domain.Enums;
using Aggregator.Domain.Models;
using Aggregator.Domain.ModelsToView;
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
    public class TiketService
    {
        private readonly DbRepository _db;
        public TiketService()
        {
            _db = new DbRepository();
        }

        public ChicagoTiket CreateTiket(CreateTiketDto tiketDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CreateTiketDto, ChicagoTiket>()).CreateMapper();
            ChicagoTiket entity = mapper.Map<CreateTiketDto, ChicagoTiket>(tiketDto);
            _db.ChicagoTikets.Add(entity);
            return entity;
        }

        public ChicagoTiket GetTiket(string id)
        {
            var tiket = _db.ChicagoTikets.FindById(id);
            return tiket;
        }

        public void EditTiket(TiketDto tiketDto, string city)
        {
            if(city == City.Chicago.ToString())
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TiketDto, ChicagoTiket>()).CreateMapper();
                ChicagoTiket entity = mapper.Map<TiketDto, ChicagoTiket>(tiketDto);
                var baseTiket = _db.ChicagoTikets.FindById(entity.Id);
                entity.CreationDate = baseTiket.CreationDate;
                _db.ChicagoTikets.Update(entity);
            }
            if (city == City.Augistine.ToString())
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TiketDto, AugistineTiket>()).CreateMapper();
                AugistineTiket entity = mapper.Map<TiketDto, AugistineTiket>(tiketDto);
                var baseTiket = _db.AugistineTikets.FindById(entity.Id);
                entity.CreationDate = baseTiket.CreationDate;
                _db.AugistineTikets.Update(entity);
            }
        }

        public List<TiketDto> GetAllChicagoTikets()
        {
            var tikets = _db.ChicagoTikets.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ChicagoTiket, TiketDto>()).CreateMapper();
            var result = mapper.Map<List<ChicagoTiket>, List<TiketDto>>(tikets);
            return result;
        }

        public List<TiketDto> GetAllAugistineTikets()
        {
            var tikets = _db.AugistineTikets.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AugistineTiket, TiketDto>()).CreateMapper();
            var result = mapper.Map<List<AugistineTiket>, List<TiketDto>>(tikets);
            return result;
        }

        public List<TiketDto> GetTiketsByIds(List<string> ids)
        {
            List<ChicagoTiket> tikets = _db.ChicagoTikets.GetByListIds(ids);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ChicagoTiket, TiketDto>()).CreateMapper();
            var result = mapper.Map<List<ChicagoTiket>, List<TiketDto>>(tikets);
            return result;
        }
        public TiketDto GetChicagoTiketById(string id)
        {
            ChicagoTiket tiket = _db.ChicagoTikets.FindById(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ChicagoTiket, TiketDto>()).CreateMapper();
            var result = mapper.Map<ChicagoTiket, TiketDto>(tiket);
            return result;
        }

        public TiketDto GetAugistineTiketById(string id)
        {
            AugistineTiket tiket = _db.AugistineTikets.FindById(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AugistineTiket, TiketDto>()).CreateMapper();
            var result = mapper.Map<AugistineTiket, TiketDto>(tiket);
            return result;
        }

        public List<BuyerTicket> GetAllCustomerTikets()
        {
            var tikets = _db.CustomerTikets.GetBuyerTikets();
            return tikets;
        }
        public List<Сustomer> GetAllCustomers()
        {
            var cusomers = _db.Сustomers.GetAll();
            return cusomers;
        }

        public List<CustomerTiket> GetPurchasedTickets()
        {
            return _db.CustomerTikets.GetAllPurchased();
        }

        public CustomerTiket GetCustomerTiketInfo(string id)
        {
            return _db.CustomerTikets.FindById(id);
        }

        public List<Сustomer> GetCustomersByEmail(string email)
        {
            return _db.Сustomers.FindByEmail(email);
        }

        public List<Сustomer> GetCustomersByPhone(string phone)
        {
            return _db.Сustomers.FindByPhone(phone);
        }

        public List<Сustomer> GetCustomersByName(string name)
        {
            return _db.Сustomers.FindByName(name);
        }

        public List<Сustomer> GetCustomersBySurname(string surname)
        {
            return _db.Сustomers.FindBySurname(surname);
        }

        public List<Сustomer> GetCustomersPaginationAsync(int start, int step)
        {
            return _db.Сustomers.GetPagination(start, step);
        }

        public int CustomersCount()
        {
            return _db.Сustomers.GetCount();
        }

        public List<CustomerTiket> GetTiketByUserId(string id)
        {
            var bayerTickets = new List<CustomerTiket>();
            bayerTickets = _db.CustomerTikets.GetByUserId(id);
            return bayerTickets;
        }

        public void SetUsedTiket(string tiketId)
        {
            var tiket = _db.CustomerTikets.FindById(tiketId);
            if(tiket!= null)
            {
                tiket.IsUsed = true;
                _db.CustomerTikets.Update(tiket);
            }
        }
    }
}
