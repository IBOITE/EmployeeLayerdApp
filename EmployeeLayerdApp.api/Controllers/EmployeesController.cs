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
        private readonly IBaseRepository<Employe> _employeeRepository;
        public EmployeesController(IBaseRepository<Employe> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        // GET: api/<EmployeesController>
        [HttpGet("GetAll")]
        public Task<IEnumerable<Employe>>  GetAll()
        {
            return _employeeRepository.List();
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<Employe> Get(int id)
        {
            return await _employeeRepository.Get(id);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public void Post([FromBody] Employe employe)
        {
            _employeeRepository.Insert(employe);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Employe employe)
        {
            if (id!=employe.Id)
            {
                return BadRequest();
            }
            return (IActionResult)await _employeeRepository.Update(employe);
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _employeeRepository.Delete(id);
        }
    }
}
