using DBS_services.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DBS_services.Controllers
{
    public class CBookingController : Controller
    {
        public static List<Booking> BookingInfo = new List<Booking>();
      
        public async Task<IActionResult> Bookinglist()

        {
            var CName = HttpContext.Session.GetString("CName");
            //ViewBag.Myname = TempData["CName"];
            if (CName != null)
            {
                var CustId = HttpContext.Session.GetInt32("CustID");
                //var CustId = Convert.ToInt32(TempData["CustID"]);
                using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("https://localhost:7016/api/CBooking/Getbooking"+ CustId);
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
        public IActionResult Book()
        {
            var CName = HttpContext.Session.GetString("CName");
            //ViewBag.Myname = TempData["CName"];
            if (CName != null)
            {

                return View();
            }
            else
            {
                return RedirectToAction("login", "Customer");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Book(Booking b)
        {
            //b.CustId = TempData.customerId;
            var zone = b.Zone;
            if (zone == "Chennai-North")
            {
                b.ExecId=1;
            }
            else
            {
                b.ExecId = 2;
            }
            b.CustId = HttpContext.Session.GetInt32("CustID");

            //b.ExecId = Convert.ToInt32(TempData["ExecutiveId"]);
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
            //Console.WriteLine("bookobj", bookobj);
            return RedirectToAction("ViewBooking", bookobj);

        }


        public async Task<IActionResult> ViewBooking(Booking bookObj)
        {
            var CName = HttpContext.Session.GetString("CName");
            //ViewBag.MyId = TempData["customerId"];
            if (CName != null)
            {
                Booking book = new Booking();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7016/api/CBooking/GetOrderById" + bookObj.OrderId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    book=JsonConvert.DeserializeObject<Booking>(apiResponse);

                }
                return View(book);
            }
            }
            else
            {
                return RedirectToAction("login", "Customer");
            }
        }
        public async Task<IActionResult> EditBook(int id)
        {
            var CName = HttpContext.Session.GetString("CName");
            if (CName != null)
            {
                TempData["OrderId"]=id;
                Booking book = new Booking();
                //book.CustId = HttpContext.Session.GetInt32("CustID");
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://localhost:7016/api/CBooking/GetOrderById" + id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        book = JsonConvert.DeserializeObject<Booking>(apiResponse);
                    }
                }
                return View(book);
            }
            else
            {
                return RedirectToAction("login", "Customer");
            }
        }

        [HttpPost]
        public async Task<ActionResult> EditBooking(Booking b)
        {
            Booking receivedBookings = new Booking();
            int OrderId = Convert.ToInt32(TempData["OrderId"]);
            b.OrderId = OrderId;
            b.CustId = HttpContext.Session.GetInt32("CustID");
            var zone = b.Zone;
            if (zone == "Chennai-North")
            {
                b.ExecId=1;
            }
            else
            {
                b.ExecId = 2;
            }
            using (var httpClient = new HttpClient())
            {

                //int id = b.OrderId;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(b)
         , Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:7016/api/CBooking/EditBooking" + OrderId, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    receivedBookings = JsonConvert.DeserializeObject<Booking>(apiResponse);
                }
            }
            return RedirectToAction("Bookinglist");
        }



        public async Task<ActionResult> Cancel(int id, Booking book)
        {
            var CName = HttpContext.Session.GetString("CName");
            if (CName != null)
            {
                TempData["OrderId"]=id;
            Booking cancel = new Booking();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7016/api/CBooking/GetOrderById"+id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cancel = JsonConvert.DeserializeObject<Booking>(apiResponse);
                }
            }
            return View(cancel);
            }
            else
            {
                return RedirectToAction("login", "Customer");
            }
        }


        [HttpPost]
        // [ActionName("DeleteFestival")]
        public async Task<ActionResult> DeleteCancel(int id, Booking cancel)
        {
            int OrderId = Convert.ToInt32(TempData["OrderId"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:7016/api/CBooking/DeleteCancel"+ OrderId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Bookinglist");
        }


    }
}


