using Employee.Application;
using Employee.Application.Pagination;
using Employee.Repositroy.Models;
using Employee.Repositroy.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeLayerdApp.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IService _service;
        public EmployeesController(IService service)
        {
            _service = service;
        }
        // GET: api/<EmployeesController>
        [HttpGet("GetAll")]
        public IEnumerable<Employe>  GetAll()
        {
            return _service.GetAllEmployees();
        }

        // using paging
        [HttpGet("GetAllAsPagination")]
        public async Task<ActionResult<IEnumerable<Employe>>> GetAll([FromQuery]PagingParameters pagingParameters)
        {
            return await _service.GetAllEmployeesPa(pagingParameters);
        }
        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public  Employe Get(int id)
        {
            return _service.GetEmployee(id);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public void Post([FromBody] Employe employe)
        {
            _service.PostEmployee(employe);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employe employe)
        {
            if (id!=employe.Id)
            {
                return BadRequest();
            }
            _service.PutEmployee(employe);
            return Ok(); 
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public  void Delete(int id)
        {
            _service.DeleteEmployee(id);
        }
    }
}
