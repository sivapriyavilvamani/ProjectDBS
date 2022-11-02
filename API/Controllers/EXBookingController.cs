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
            try
            {
                var booking = (from i in db.Bookings
                               where i.ExecId == id && i.DelivaryDate >= DateTime.Today && i.PicKupTime >= DateTime.Today
                               select i).ToList();
                return Ok(booking);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok();
            }


        }
        [HttpPost]
        public IActionResult Booking(Booking b)
        {
            try {
                db.Bookings.Add(b);
                db.SaveChanges();
                return Ok(b);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok();
            }


        }
        [HttpGet]
        [Route("GetBookingById{id}")]
        public IActionResult GetBookingById(int id)
        {
            try
            {
                var b = db.Bookings.Find(id);
                return Ok(b);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok();
            }

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
