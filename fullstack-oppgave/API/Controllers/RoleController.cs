using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService; 
        }

        [HttpGet]
        public List<RoleDto> GetAllRoles()
        {
            return _roleService.GetRoles();
        }
    }
}
