using DBS_services.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DBS_services.Controllers
{
    public class EXBookingController : Controller
    {
        public static List<Booking> BookingInfo = new List<Booking>();

        public async Task<IActionResult> Bookings()

        {
            var EName = HttpContext.Session.GetString("EName");
            if(EName != null)
            {
                var ExecId = HttpContext.Session.GetInt32("ExecID");
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("https://localhost:7016/api/EXBooking/Getbooking"+ExecId);
                    if (Res.IsSuccessStatusCode)
                    {
                        var bookingres = Res.Content.ReadAsStringAsync().Result;
                        BookingInfo = JsonConvert.DeserializeObject<List<Booking>>(bookingres);
                    }
                }

                return View(BookingInfo);

            }
            else
            {
                return RedirectToAction("login", "Customer");
            }

        }
           
        //public async Task<IActionResult> Details(int id)
        //{
        //    Booking book = new Booking();
        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = await httpClient.GetAsync("https://localhost:7016/api/EXBooking?id" + id))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            book = JsonConvert.DeserializeObject<Booking>(apiResponse);
        //        }
        //    }
        //    return View(book);
        //}


    }
}
