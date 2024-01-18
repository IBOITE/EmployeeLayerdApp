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
        [HttpPut("{id}")]
        public void updatee(int id, [FromBody] Department department)
        {
            if (id != department.Id)
            {
                 BadRequest();
            }
              _departmentRepository.Update(department);
        }
        */

        [HttpGet("GetAll")]
        public IEnumerable<Department> GetAll()
        {
            return _departmentRepository.List();
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public  Department Get(int id)
        {
            return  _departmentRepository.Get(id);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public void Post([FromBody] Department department)
        {
            _departmentRepository.Insert(department);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public  IActionResult Put(int id, [FromBody] Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }
             _departmentRepository.Update(department);
            return Ok();   
        }


        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
             _departmentRepository.Delete(id);
        }
    }
}
