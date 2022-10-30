using Api_DBS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_DBS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CBookingController : ControllerBase
    {
        private readonly DBS_serviceContext db;
        public CBookingController(DBS_serviceContext _db)
        {
            db = _db;
        }
        [HttpGet]
        [Route("Getbooking{id}")]
        public IActionResult GetBooking(int id)
        {
            var booking = (from i in db.Bookings
                           where i.CustId == id && i.DelivaryDate >= DateTime.Now
                           select i).ToList();
            return Ok(booking);
        }
        [HttpPost]
        public IActionResult Booking(Booking b)
        {
            db.Bookings.Add(b);
            db.SaveChanges();
            return Ok(b);
        }
        [HttpGet]
        [Route("GetOrderById{id}")]
        public IActionResult GetOrderById(int id)
        {
            var f = db.Bookings.Find(id);
            return Ok(f);
        }
        [HttpPut]
        [Route("EditBooking{id}")]
        public IActionResult EditBooking(int id, Booking b)

        {
            db.Bookings.Update(b);
            db.SaveChanges();
            return Ok(b);
        }
        [HttpDelete]
        [Route("DeleteCancel{id}")]
        public IActionResult DeleteCancel(int id)
        {
            try
            {
                var f = db.Bookings.Find(id);
                // var h = db.Histories.Find(id);

                db.Bookings.Remove(f);

                db.SaveChanges();

                History h = new History();

                h.OrderId = f.OrderId;
                h.Source = f.Source;
                h.Destination = f.Destination;
                h.CustId = f.CustId;
                h.ExecId = f.ExecId;
                h.Weight = f.Weight;
                h.Price = f.Price;

                db.Histories.Add(h);

                db.SaveChanges();
                return Ok(f);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok();
            }
        }


    }
}
