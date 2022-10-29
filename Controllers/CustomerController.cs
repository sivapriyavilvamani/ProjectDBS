using DBS_services.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DBS_services.Controllers
{
    public class CustomerController : Controller
    {
        //private readonly ISession session;
        //public CustomerController(IHttpContextAccessor httpContextAccessor)
        //{
        //    session = httpContextAccessor.HttpContext.Session;
        //}
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
            //HttpContext.Session.SetString("Error", "null");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> login(CRegistration r)
        {
            CRegistration logindata = new CRegistration();
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(r), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("https://localhost:7016/api/Clogin", content))
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        {
                            string apiresponse = await response.Content.ReadAsStringAsync();
                            logindata = JsonConvert.DeserializeObject<CRegistration>(apiresponse);

                        }
                        HttpContext.Session.SetInt32("CustID", logindata.CustId);
                        HttpContext.Session.SetString("CName", logindata.FirstName);
                        //HttpContext.Session.SetString("Error", "null");
                        //TempData["customerId"]=logindata.CustId;
                        //TempData["CName"]=logindata.FirstName;



                        return RedirectToAction("Bookinglist", "CBooking");
                    }
                    else
                    {
                        HttpContext.Session.SetString("Error", "Error");
                       // TempData["Error"] = "Unable to login...! Please try again";
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

