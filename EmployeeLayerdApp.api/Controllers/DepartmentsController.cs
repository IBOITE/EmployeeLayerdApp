using Employee.Repositroy.Models;
using Employee.Repositroy.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLayerdApp.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IBaseRepository<Department> _departmentRepository;
        public DepartmentsController(IBaseRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        /*
        [HttpGet("getbyid")]
        public IActionResult GetById()
        {
            return Ok(_departmentRepository.GetByID(1));
        }
        
        [HttpGet]
        public IEnumerable<Department> GetAll()
        {
            return _departmentRepository.GetAll();
        }
        */

        [HttpGet("GetAll")]
        public Task<IEnumerable<Department>> GetAll()
        {
            return _departmentRepository.List();
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<Department> Get(int id)
        {
            return await _departmentRepository.Get(id);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public void Post([FromBody] Department department)
        {
            _departmentRepository.Insert(department);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }
            return (IActionResult)await _departmentRepository.Update(department);
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _departmentRepository.Delete(id);
        }
    }
}
