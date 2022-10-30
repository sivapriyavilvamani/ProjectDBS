using Api_DBS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_DBS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EXBookingController : ControllerBase
    {
        private readonly DBS_serviceContext db;
        public EXBookingController(DBS_serviceContext _db)
        {
            db = _db;
        }
        [HttpGet]
        [Route("Getbooking{id}")]
        public IActionResult GetBooking(int id)
        {
            var booking = (from i in db.Bookings
                           where i.ExecId == id && i.DelivaryDate >= DateTime.Now
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
        [Route("GetBookingById{id}")]
        public IActionResult GetBookingById(int id)
        {
            var b = db.Bookings.Find(id);
            return Ok(b);
        }
       
        //[HttpPut]
        //public IActionResult EditBooking(int id, Booking b)

        //{
        //    db.Bookings.Update(b);
        //    db.SaveChanges();
        //    return Ok(b);
        //}

        //[HttpDelete]
        //[Route("DeleteBooking{id}")]
        //public IActionResult DeleteBooking(int id)
        //{
        //    var b = db.Bookings.Find(id);
        //    db.Bookings.Remove(b);
        //    db.SaveChanges();
        //    return Ok(b);
        //}



    }
}
