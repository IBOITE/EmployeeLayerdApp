using Employee.Data;
using Employee.Repositroy.Models;
using Employee.Repositroy.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLayerdApp.MVC.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly IBaseRepository<Employe> _employeeRepository;
        private readonly ApplicationDbContext _applicationDbContext;
        public EmployeesController(IBaseRepository<Employe> employeeRepository, ApplicationDbContext applicationDbContext)
        {
            _employeeRepository = employeeRepository;
            _applicationDbContext = applicationDbContext;
        }
        // GET: EmployeesController
        public ActionResult Index()
        {
            return View(_employeeRepository.List());
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employeeRepository.Get(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_applicationDbContext.Departments, "Id", "Id");
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employe employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Insert(employee);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_applicationDbContext.Departments, "Id", "Id",employee.DepartmentId);

            return View(employee);
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employeeRepository.Get(id);
            if (employee == null)
            {
                return NotFound();
            }
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
                    _employeeRepository.Update(employee);
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
            return View(employee);
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employeeRepository.Get(id);
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
            var employee = _employeeRepository.Get(id);
            if (employee != null)
            {
                _employeeRepository.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _employeeRepository.Any(d => d.Id == id);
        }
    }
}
