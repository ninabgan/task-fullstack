using Application.Dtos;
using AutoMapper;
using Entities;
using Persistence.Data.DBWrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IDBWrapper _dbWrapper;
        private readonly IMapper _mapper;

        public UserRoleService(IDBWrapper dbWrapper, IMapper mapper)
        {
            _dbWrapper = dbWrapper;
            _mapper = mapper;
        }

        public UserRoleDto CreateUserRole(UserRoleDto userRoleDto)
        {
            if (userRoleDto.ValidTo < userRoleDto.ValidFrom || userRoleDto.ValidTo < DateTime.Now)
            {
                throw new ArgumentException("Invalid dates"); // should prepare better error message
            }

            UserRole userRole = _mapper.Map<UserRole>(userRoleDto);
            var response = _dbWrapper.CreateUserRole(userRole);
            var responseDto = _mapper.Map<UserRoleDto>(response);
            return responseDto;
        }

        public List<UserRoleDto> GetUserRoles()
        {
            var list = _dbWrapper.GetUserRoles();
            if (list == null)
            {
                return new List<UserRoleDto>();
            }

            var userRoleDtos = _mapper.Map<List<UserRoleDto>>(list);
            return userRoleDtos;

        }

        public List<UserRoleDto> GetValidUserRoles()
        {
            throw new NotImplementedException();
        }

        public UserRoleDto UpdateUserRole(UserRoleDto userRoleDto)
        {
            var currentUserRole = _dbWrapper.GetUserRoles().Where(x => x.Id == userRoleDto.Id).FirstOrDefault();

            if (currentUserRole.Version != userRoleDto.Version)
            {
                throw new ArgumentException("Version mismatch");
            } 

            var userRole = _mapper.Map<UserRole>(userRoleDto);
            var response = _dbWrapper.UpdateUserRole(userRole);
            var responseDto = _mapper.Map<UserRoleDto>(response);
            return responseDto;
        }
    }
}
