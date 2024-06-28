using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUserService
    {
        List<UserDto> GetUsers();

        List<UserDto> GetUsersByUnitId(int unitId);
        UserDto CreateUser(UserDto userDto);
        UserDto UpdateUser(UserDto userDto);
        DeleteUserResponseDto DeleteUser(int id, int version);

    }
}
