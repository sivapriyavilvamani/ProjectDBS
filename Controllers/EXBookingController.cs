using DBS_services.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DBS_services.Controllers
{
    public class EXBookingController : Controller
    {
        public static List<Booking> BookingInfo = new List<Booking>();

        public async Task<IActionResult> Bookings()

        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("https://localhost:7016/api/EXBooking");
                if (Res.IsSuccessStatusCode)
                {
                    var bookingres = Res.Content.ReadAsStringAsync().Result;
                    BookingInfo = JsonConvert.DeserializeObject<List<Booking>>(bookingres);
                }
            }

            return View(BookingInfo);
        }
    }
}
