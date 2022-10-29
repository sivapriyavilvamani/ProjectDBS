using DBS_services.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DBS_services.Controllers
{
    public class HistoryController : Controller
    {
        public static List<CancelHistory> CancelInfo = new List<CancelHistory>();

        public async Task<IActionResult> CancelCusHistory()

        {
            var CName = HttpContext.Session.GetString("CName");
            if (CName != null)
            {

                var CustId = HttpContext.Session.GetInt32("CustID");
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("https://localhost:7016/api/HIstory/GetCusHistory"+ CustId);
                    if (Res.IsSuccessStatusCode)
                    {
                        var bookingres = Res.Content.ReadAsStringAsync().Result;
                        CancelInfo = JsonConvert.DeserializeObject<List<CancelHistory>>(bookingres);
                    }
                }

                return View(CancelInfo);
            }
            else
            {
                return RedirectToAction("login", "Customer");
            }
        }
        //    [HttpPost]
        //    // [ActionName("DeleteFestival")]
        //    public async Task<ActionResult> DeleteCancel(int id, Booking cancel)
        //    {
        //        int OrderId = Convert.ToInt32(TempData["OrderId"]);
        //        using (var httpClient = new HttpClient())
        //        {
        //            using (var response = await httpClient.DeleteAsync("https://localhost:7016/api/CBooking/DeleteCancel"+ OrderId))
        //            {
        //                string apiResponse = await response.Content.ReadAsStringAsync();
        //            }
        //        }

        //        return RedirectToAction("login", "Customer");
        //    }


    }
}

