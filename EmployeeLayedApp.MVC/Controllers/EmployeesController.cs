using Employee.Repositroy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeLayedApp.MVC.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Employe> employe = new List<Employe>();
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:7060/api/Employees/GetAll"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    employe = JsonConvert.DeserializeObject<List<Employe>>(apiResponse);
                }
            }
            return View(employe);
        }

        // GET: EmployeesController/Details/5
        [HttpGet]
        public async Task<ActionResult>  Details(int id)
        {
            Employe employe = new Employe();
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:7060/api/Employees/"+id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    employe = JsonConvert.DeserializeObject<Employe>(apiResponse);
                }
            }
            return View(employe);
        }

        // GET: EmployeesController/Create
        [HttpPost]
        public async Task<ActionResult> Create(Employe employee)
        {
            /*
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7060/api/Employees");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Employe>("employe", employe);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(employe);
            */
            
            using (var client = new HttpClient())
            {
                using (var response = await client.PostAsJsonAsync("https://localhost:7060/api/Employees",employee))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    employee = JsonConvert.DeserializeObject<Employe>(apiResponse);
                }
            }
            return View(employee);
        }

        // POST: EmployeesController/Create
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */

        // GET: EmployeesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Employe employe = new Employe();
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:7060/api/Employees/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    employe = JsonConvert.DeserializeObject<Employe>(apiResponse);
                }
            }
            return View(employe);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Employe employe)
        {
            
            using (var client = new HttpClient())
            {
                using (var response = await client.PutAsJsonAsync("https://localhost:7060/api/Employees/" + id, employe))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    employe = JsonConvert.DeserializeObject<Employe>(apiResponse);
                }
            }
            return View(employe);
        }

        // GET: EmployeesController/Delete/5
        public  async void  Delete(int id)
        {
            using (var client = new HttpClient())
            {
                Employe employe = new Employe();
                using (var response = await client.DeleteAsync("https://localhost:7060/api/Employees/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    employe = JsonConvert.DeserializeObject<Employe>(apiResponse);
                }
            }
            
        }
        
        /*
        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
