using cloudscribe.Pagination.Models;
using Employee.Application;
using Employee.Repositroy.Models;
using Employee.Repositroy.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLayerdApp.MVC.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IService _service;
        public DepartmentsController(IService service)
        {
            _service = service;
        }
        // GET: DepartmentsController
        public ActionResult Index(int pagenumber=1, int pagesize=3)
        {
            var departments = _service.GetAllDepartments(pagenumber, pagesize);
            var result = new PagedResult<Department>()
            {
                Data = departments.ToList(),
                PageNumber = pagenumber,
                PageSize = pagesize,
                TotalItems = _service.CountDepartements()
            };
            return View(result);
        }

        // GET: Depatmen/Details/5
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmant = _service.GetDepartment(id);
            if (departmant == null)
            {
                return NotFound();
            }

            return View(departmant);
        }

        // GET: Depatmen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Depatmen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Department departmant)
        {
            if (ModelState.IsValid)
            {
                _service.PostDepartment(departmant);
                return RedirectToAction(nameof(Index));
            }
            return View(departmant);
        }

        // GET: Depatmen/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmant = _service.GetDepartment(id);
            if (departmant == null)
            {
                return NotFound();
            }
            return View(departmant);
        }

        // POST: Depatmen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Department departmant)
        {
            if (id != departmant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.PutDepartment(departmant);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepatmanExists(departmant.Id))
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
            return View(departmant);
        }

        // GET: Depatmen/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmant = _service.GetDepartment(id);
            if (departmant == null)
            {
                return NotFound();
            }

            return View(departmant);
        }

        // POST: Depatmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var departmant = _service.GetDepartment(id);
            if (departmant != null)
            {
                _service.DeleteDepartment(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool DepatmanExists(int id)
        {
            return _service.AnyDepartment(d => d.Id == id);
        }
    }
}
