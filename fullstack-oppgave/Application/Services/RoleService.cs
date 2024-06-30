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
    public class RoleService : IRoleService
    {
        private readonly IDBWrapper _dbWrapper;
        private readonly IMapper _mapper;

        public RoleService(IDBWrapper dbWrapper, IMapper mapper)
        {
            _dbWrapper = dbWrapper;
            _mapper = mapper;
        }

        public List<RoleDto> GetRoles()
        {
            var list = _dbWrapper.GetRoles();
            if (list == null)
            {
                return new List<RoleDto>();
            }
            var roleDtos = _mapper.Map<List<RoleDto>>(list);
            return roleDtos;
        }
    }
}
