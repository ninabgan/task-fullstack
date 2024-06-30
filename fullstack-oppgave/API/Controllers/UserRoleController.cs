using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos;
using Application.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;

        }

        [HttpGet]
        public List<UserRoleDto> GetAllUserRoles()
        {
            return _userRoleService.GetUserRoles();
        }

        //[HttpGet]
        //public List<UserRoleDto> GetValidAllUserRoles(int userId, int unitId, DateTime? date)
        //{
        //    return _userRoleService.GetValidUserRoles(userId, unitId, date);
        //}

        [HttpPost]
        public UserRoleDto CreateUserRole(UserRoleDto userRoleDto)
        {
            var response = _userRoleService.CreateUserRole(userRoleDto);
            return response;
        }
    }
}
