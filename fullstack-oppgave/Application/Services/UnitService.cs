using Application.Dtos;
using AutoMapper;
using Persistence.Data.DBWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UnitService : IUnitService
    {
        private readonly IDBWrapper _dbWrapper;
        private readonly IMapper _mapper;

        public UnitService(IDBWrapper dBWrapper, IMapper mapper)
        {
            _dbWrapper = dBWrapper;
            _mapper = mapper;
        }
        public List<UnitDto> GetUnits()
        {
            var list = _dbWrapper.GetUnits();
            if (list == null)
            {
                return new List<UnitDto>();
            }
            var unitDtos = _mapper.Map<List<UnitDto>>(list);
            return unitDtos;
        }
    }
}
