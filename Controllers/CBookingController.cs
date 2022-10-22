using DBS_services.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DBS_services.Controllers
{
    public class CBookingController : Controller
    {
       
        public IActionResult Book()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Book(Booking b)
        {
            var bookobj = new Booking();
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(b), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("https://localhost:7016/api/CBooking", content))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    bookobj = JsonConvert.DeserializeObject<Booking>(apiresponse);
                }
               

            }
            Console.WriteLine("bookobj", bookobj);
            return RedirectToAction("CancelBook", bookobj );          
        
        }


        public async Task<IActionResult> CancelBook(Booking bookObj)
        {
          
            Booking book = new Booking();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7016/api/CBooking/GetbookingById" + bookObj.OrderId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    book = JsonConvert.DeserializeObject<Booking>(apiResponse);
                }
            }
            return View(book);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            TempData["OrderId"]=id;
            Booking cancel = new Booking();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7016/api/CBooking/GetbookingById"  + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cancel = JsonConvert.DeserializeObject<Booking>(apiResponse);
                }
            }
            return View(cancel);
        }


        [HttpPost]
        // [ActionName("DeleteFestival")]
        public async Task<ActionResult> Delete(Booking b)
        {
            int OrderId = Convert.ToInt32(TempData["OrderId"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:7016/api/CBooking?id"+ OrderId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("login","Customer");
        }

    }
}
