using API.Model;
using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public List<UserDto> GetAllUsersMock()
        {
            return new List<UserDto>
            {
                new UserDto
                {
                    Id = 1,
                    Version = 1,
                    Name = "Nina"
                },
                new UserDto
                {
                    Id = 2,
                    Version = 2,
                    Name = "Helene"
                },
                new UserDto
                {
                    Id = 3,
                    Version = 1,
                    Name = "Carina"
                }
            };
        }

        // [HttpGet]
        // public List<UserDto> GetAllUsers()
        // {
        //     return _userService.GetUsers();
        // }

        [HttpGet("{unitId}")]
        public List<UserDto> GetAllUsersByUnit(int unitId)
        {
            return _userService.GetUsersByUnitId(unitId);
        }

        [HttpPut]
        public UserDto UpdateUser(UserDto userDto)
        {
            var response = _userService.UpdateUser(userDto);
            return response;
        }

        [HttpPost]
        public UserDto CreateUser(UserDto userDto)
        {
            var response = _userService.CreateUser(userDto);
            return response;
        }

        [HttpDelete("{id}")]
        public DeleteUserResponse DeleteUser(int id, int version)
        {
            var responseDto = _userService.DeleteUser(id, version);
            var response = new DeleteUserResponse
            {
                Status = responseDto.Status,
                StatusMessage = responseDto.StatusMessage,
                Succeeded = responseDto.Succeeded
            };
            return response;
        }
    }
}
