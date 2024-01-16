using Employee.Repositroy.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeLayedApp.MVC.Controllers
{
    public class DepartmentsController : Controller
    {
        public async Task<IActionResult>  Index()
        {
            List <Department> department = new List<Department>();
            using(var client=new HttpClient())
            {
                using(var response=await client.GetAsync("https://localhost:7060/api/Departments/GetAll"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    department = JsonConvert.DeserializeObject<List<Department>>(apiResponse);
                }
            }
            return View(department);
        }
        // GET: EmployeesController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            Department department = new Department();
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:7060/api/Departments/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    department = JsonConvert.DeserializeObject<Department>(apiResponse);
                }
            }
            return View(department);
        }

        // GET: EmployeesController/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: EmployeesController/Create
        [HttpPost]
        public async Task<ActionResult> Create( Department department)
        {
            /*
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7060/api/Departments");

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
                using (var response = await client.PostAsJsonAsync("https://localhost:7060/api/Departments", department))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Department result=  JsonConvert.DeserializeObject<Department>(apiResponse);
                    return RedirectToAction("Index");
                }
            }
            //return View(department);
            
        }

        
        

        // GET: EmployeesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Department department = new Department();
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:7060/api/Departments/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    department = JsonConvert.DeserializeObject<Department>(apiResponse);
                }
            }
            return View(department);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Department department)
        {

            using (var client = new HttpClient())
            {
                using (var response = await client.PutAsJsonAsync("https://localhost:7060/api/Departments/" + id, department))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    department = JsonConvert.DeserializeObject<Department>(apiResponse);
                }
            }
            return View(department);
        }

        // GET: EmployeesController/Delete/5

        public async Task<ActionResult> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7060/api/");
                var response = await client.DeleteAsync($"Departments/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
        }

        //public async Task Delete(int id)
        //{

        //    using (var client = new HttpClient())
        //    {

        //        using (var response = await client.DeleteAsync("https://localhost:7060/api/Departments/" + id))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            JsonConvert.DeserializeObject<Department>(apiResponse);
        //        }
        //    }

        //}
    }
}
