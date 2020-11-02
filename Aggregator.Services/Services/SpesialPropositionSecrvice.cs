using Aggregator.Domain.Models;
using Aggregator.Repository.Repositories.Base;
using Aggregator.Services.ModelsDto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aggregator.Services
{
    public class SpesialPropositionSecrvice
    {

        private readonly DbRepository _db;
        public SpesialPropositionSecrvice()
        {
            _db = new DbRepository();
        }

        public void Create( CreateSpesialPropositionDto model )
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CreateSpesialPropositionDto, SpecialProposition>()).CreateMapper();
            SpecialProposition specialProposition = mapper.Map<CreateSpesialPropositionDto, SpecialProposition>(model);
             _db.SpecialPropositions.Add(specialProposition);
        }

        public  List<SpesialPropositionDto> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SpecialProposition, SpesialPropositionDto>()).CreateMapper();
            var spesialPropositions =  _db.SpecialPropositions.GetAll();
            var result = mapper.Map<List<SpecialProposition>, List<SpesialPropositionDto>>(spesialPropositions);
            return result;
        }

        public SpesialPropositionDto GetById(string specialPropositionId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SpecialProposition, SpesialPropositionDto>()).CreateMapper();
            var spesialProposition = _db.SpecialPropositions.FindById(specialPropositionId);
            var result = mapper.Map<SpecialProposition, SpesialPropositionDto>(spesialProposition);
            return result;
        }

        public void Edit(EditSpesialPropositionDto editSpesial)
        {
            var spesialProposition = _db.SpecialPropositions.FindById(editSpesial.Id);
            if(spesialProposition != null)
            {
                spesialProposition.Text = editSpesial.Text;
                spesialProposition.ImageId = editSpesial.ImageId == null? spesialProposition.ImageId : editSpesial.ImageId;

                _db.SpecialPropositions.Update(spesialProposition);
            }
        }
    }
}
