using ChurchApi.DTOs.Departament;
using ChurchApi.Interfaces;
using ChurchApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChurchApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartamentController : ControllerBase
    {
        private readonly IDepartamentInterface _departamentInterface;

        public DepartamentController(IDepartamentInterface departamentInterface)
        {
            _departamentInterface = departamentInterface;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ResponseModel<List<DepartamentModel>>>> GetDepartaments()
        {
            var departaments = await _departamentInterface.GetDepartaments();
            return Ok(departaments);
        }

        [HttpGet("GetDepartamentById")]
        public async Task<ActionResult<ResponseModel<DepartamentModel>>> GetDepartamentById(int departamentId)
        {
            var departament = await _departamentInterface.GetDepartamentById(departamentId);
            return Ok(departament);
        }

        [HttpPost("DepartamentCreate")]
        public async Task<ActionResult<ResponseModel<DepartamentModel>>> DepartamentCreate(DepartamentCreateDTO departamentCreateDto)
        {
            var departament = await _departamentInterface.CreateDepartament(departamentCreateDto);
            return Ok(departament);
        }
    }
}