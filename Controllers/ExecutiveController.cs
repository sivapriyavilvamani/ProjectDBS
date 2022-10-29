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
            EXRegistration logindata = new EXRegistration();
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(r), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("https://localhost:7016/api/EXlogin", content))
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        {
                            string apiresponse = await response.Content.ReadAsStringAsync();
                            logindata = JsonConvert.DeserializeObject<EXRegistration>(apiresponse);
                        }
                        HttpContext.Session.SetInt32("ExecID", logindata.ExecId);
                        HttpContext.Session.SetString("EName", logindata.ExecName);

                        return RedirectToAction("Bookings", "EXBooking");
                    }
                    else
                    {
                        HttpContext.Session.SetString("Error", "Error");
                      
                        // ViewBag.LoginError = "Unable to login...! Please try again";
                        return RedirectToAction("login");
                    }
            }

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            //TempData.Clear();
            return RedirectToAction("login");
        }
    }
}
