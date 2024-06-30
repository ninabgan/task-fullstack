using Application.Dtos;
using AutoMapper;
using Entities;
using Persistence.Data.DBWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IDBWrapper _dbWrapper;
        private readonly IMapper _mapper;

        public UserService(IDBWrapper dBWrapper, IMapper mapper)
        {
            _dbWrapper = dBWrapper;
            _mapper = mapper;
        }

        public UserDto CreateUser(UserDto userDto)
        {
            
            var userList = _dbWrapper.GetUsers();
            var highestId = userList.MaxBy(x => x.Id).Id;
            var user = new User
            {
                Name = userDto.Name,
                Version = 1,
                Id = highestId + 1,
            };

            var response = _dbWrapper.CreateUser(user);

            return new UserDto
            {
                Name = user.Name,
                Id = user.Id,
                Version = user.Version
            };
        }

        public DeleteUserResponseDto DeleteUser(int id, int version)
        {
            var user = _dbWrapper.GetUsers().Where(x => x.Id == id).FirstOrDefault();

            if (user.Version != version)
            {
                throw new ArgumentException("Version mismatch");
            }

            // only delete if no user roles for that user
            var userRoles = _dbWrapper.GetUserRoles().Where(x => x.UserId == id);
            //var userRole = allUserRoles.Where(x => x.UserId == id);
            if (userRoles.Count() >= 0)
            {
                return new DeleteUserResponseDto
                {
                    Status = 404,
                    Succeeded = false,
                    StatusMessage = "The given user have valid user roles and can not be deleted"
                };
            }

            var deleteResponse = _dbWrapper.DeleteUser(id);
            var deleteResponseDto = new DeleteUserResponseDto
            {
                Status = deleteResponse.Status,
                StatusMessage = deleteResponse.StatusMessage,
                Succeeded = deleteResponse.Succeeded,
            };
            return deleteResponseDto;
        }

        public List<UserDto> GetUsers()
        {
            var list = _dbWrapper.GetUsers();
            if (list == null)
            {
                return new List<UserDto>();
            }
            var userDtos = _mapper.Map<List<UserDto>>(list);
            return userDtos;
        }

        public List<UserDto> GetUsersByUnitId(int unitId)
        {
            var userRolelist = _dbWrapper.GetUserRoles().Where(x => x.UnitId == unitId);
            var userList = new List<User>();
            foreach (var role in userRolelist)
            {
                if (role.ValidTo > DateTime.Now)
                {
                    var user = _dbWrapper.GetUser(role.UserId);
                    userList.Add(user);
                }
            }
            var userDtos = _mapper.Map<List<UserDto>>(userList);

            return userDtos;
        }

        public UserDto UpdateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var response = _dbWrapper.UpdateUser(user);
            var responseDto = _mapper.Map<UserDto>(response);
            return responseDto;
        }

    }
}
