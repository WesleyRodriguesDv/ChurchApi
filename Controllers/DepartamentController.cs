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

        [HttpGet("GetBy/{departamentId}")]
        public async Task<ActionResult<ResponseModel<DepartamentModel>>> GetDepartamentById(int departamentId)
        {
            var departament = await _departamentInterface.GetDepartamentById(departamentId);
            return Ok(departament);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ResponseModel<DepartamentModel>>> CreateDepartament(DepartamentDTO departamentDto)
        {
            var departament = await _departamentInterface.CreateDepartament(departamentDto);
            return Ok(departament);
        }

        [HttpPut("Edit")]
        public async Task<ActionResult<DepartamentModel>> EditDepartament(DepartamentDTO departamentDto)
        {
            var departament = await _departamentInterface.EditDepartament(departamentDto);
            return Ok(departament);
        }

        [HttpDelete("Delete/{departamentId}")]
        public async Task<ActionResult<DepartamentModel>> DeleteDepartament(int departamentId)
        {
            var departament = await _departamentInterface.DeleteDepartament(departamentId);
            return Ok(departament);
        }
    }
}