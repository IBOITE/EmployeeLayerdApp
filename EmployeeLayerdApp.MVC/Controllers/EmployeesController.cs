using cloudscribe.Pagination.Models;
using Employee.Application;
using Employee.Data;
using Employee.Repositroy.Models;
using Employee.Repositroy.Repositories;
using EmployeeLayerdApp.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLayerdApp.MVC.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly IService _service;
        private readonly ApplicationDbContext _applicationDbContext;
        public EmployeesController(IService service, ApplicationDbContext applicationDbContext)
        {
            _service = service;
            _applicationDbContext = applicationDbContext;
        }
        // GET: EmployeesController
        public ActionResult Index(int pagenumber = 1, int pagesize = 3)
        {
            var employees = _service.GetAllEmployees(pagenumber, pagesize);
            var result = new PagedResult<Employe>()
            {
                Data = employees.ToList(),
                PageNumber = pagenumber,
                PageSize = pagesize,
                TotalItems = _service.CountEmployees()
            };
            return View(result);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _service.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_applicationDbContext.Departments, "Id", "DepartmentName");
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Employe employee)
        {

            if (ModelState.IsValid)
            {
                _service.PostEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_applicationDbContext.Departments, "Id", "Id", employee.DepartmentId);

            return View(employee);
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _service.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_applicationDbContext.Departments, "Id", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employe employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.PutEmployee(employee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_applicationDbContext.Departments, "Id", "Id", employee.DepartmentId);
            return View(employee);
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _service.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var employee = _service.GetEmployee(id);
            if (employee != null)
            {
                _service.DeleteEmployee(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _service.AnyEmployee(d => d.Id == id);
        }
    }
}
