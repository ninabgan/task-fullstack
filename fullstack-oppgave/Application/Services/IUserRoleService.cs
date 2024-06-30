using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUserRoleService
    {
        List<UserRoleDto> GetUserRoles();
        List<UserRoleDto> GetValidUserRoles(int userId, int unitId, DateTime? date);
        UserRoleDto CreateUserRole(UserRoleDto userRoleDto);
        UserRoleDto UpdateUserRole(UserRoleDto userRoleDto);
    }
}
