using DBS_services.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DBS_services.Controllers
{
    public class ExecutiveController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(EXRegistration r)
        {
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(r), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("https://localhost:7016/api/EXRegistration", content))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    var regobj = JsonConvert.DeserializeObject<EXRegistration>(apiresponse);
                }
            }
            return RedirectToAction("login");

        }

        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> login(EXRegistration r)
        {
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(r), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("https://localhost:7016/api/EXlogin", content))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    var registration = JsonConvert.DeserializeObject<EXRegistration>(apiresponse);
                }

            }
            return RedirectToAction("Bookings","EXBooking");

        }
    }
}
