using cloudscribe.Pagination.Models;
using Employee.Repositroy.Models;
using Employee.Repositroy.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLayerdApp.MVC.Controllers
{
    public class DepartmentsController : Controller
    {

        private readonly IBaseRepository<Department> _departmentRepository;
        public DepartmentsController(IBaseRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        // GET: DepartmentsController
        public ActionResult Index(int pagenumber=1, int pagesize=3)
        {
            var departments = _departmentRepository.List(pagenumber, pagesize);
            var result = new PagedResult<Department>()
            {
                Data = departments.ToList(),
                PageNumber = pagenumber,
                PageSize = pagesize,
                TotalItems = _departmentRepository.Count()
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

            var departmant = _departmentRepository.Get(id);
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
                _departmentRepository.Insert(departmant);
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

            var departmant = _departmentRepository.Get(id);
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
                    _departmentRepository.Update(departmant);
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

            var departmant = _departmentRepository.Get(id);
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
            var departmant = _departmentRepository.Get(id);
            if (departmant != null)
            {
                _departmentRepository.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool DepatmanExists(int id)
        {
            return _departmentRepository.Any(d => d.Id == id);
        }
    }
}
