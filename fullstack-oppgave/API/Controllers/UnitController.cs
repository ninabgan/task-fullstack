using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;

        public UnitController( IUnitService unitService)
        {
            _unitService = unitService;
        }

        [HttpGet]
        public List<UnitDto> GetAllUnits()
        {
            return _unitService.GetUnits();
        }
    }
}
