using Employee.Repositroy.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace EmployeeLayerdApp.MVC.Controllers
{
    public class DepartmenttsController : Controller
    {

        public async Task<IActionResult> Index()
        {
            Department department = new Department();
            using (var client=new HttpClient())
            {
                using(var respone= await client.GetAsync(""))
                {
                    string apiResponse=await respone.Content.ReadAsStringAsync();
                    department = JsonConvert.DeserializeObject<Department>(apiResponse);
                }
            }
            return View(department);
        }
    }
}
