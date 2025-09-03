using ChurchApi.Interfaces;
using ChurchApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
    }
}