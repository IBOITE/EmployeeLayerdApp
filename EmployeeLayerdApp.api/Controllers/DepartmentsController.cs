using Employee.Application;
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
        private readonly IService _service;
        public DepartmentsController( IService service)
        {
            _service = service;
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
        public IEnumerable<Department> Departments()
        {
            return _service.GetAllDepartments();
        }
   
        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public  Department Get(int id)
        {
            return  _service.GetDepartment(id);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public void Post([FromBody] Department department)
        {
            _service.PostDepartment(department);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public  IActionResult Put(int id, [FromBody] Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }
             _service.PutDepartment(department);
            return Ok();   
        }


        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
             _service.DeleteDepartment(id);
        }
    }
}
