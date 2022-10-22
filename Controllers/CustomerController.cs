using DBS_services.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DBS_services.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(CRegistration r)
        {
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(r), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("https://localhost:7016/api/Customer", content))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    var regobj = JsonConvert.DeserializeObject<CRegistration>(apiresponse);
                }
            }
            return RedirectToAction("login");

        }

        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> login(CRegistration r)
        {
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(r), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("https://localhost:7016/api/Clogin", content))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    var registration = JsonConvert.DeserializeObject<EXRegistration>(apiresponse);
                }

            }
            return RedirectToAction("Book", "CBooking");

        }
    }
}
