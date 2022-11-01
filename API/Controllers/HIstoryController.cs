using Api_DBS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_DBS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HIstoryController : ControllerBase
    {
        private readonly DBS_serviceContext db;
        public HIstoryController(DBS_serviceContext _db)
        {
            db = _db;

        }
        [HttpGet]
        public IActionResult GetHistory()
        {
            try
            {
                return Ok(db.Histories.ToList());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok();
            }

        }
        [HttpPost]
        public IActionResult History(History h)
        {
            try
            {
                db.Histories.Add(h);
                db.SaveChanges();
                return Ok(h);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok();
            }

        }
        [HttpGet]
        [Route("GetcancelHistoryById{id}")]
        public IActionResult GetcancelHistoryById(int id)
        {
            try
            {
                var f = db.Histories.Find(id);
                return Ok(f);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok();
            }

        }
        [HttpGet]
        [Route("GetCusHistory{id}")]
        public IActionResult GetCusHistory(int id)
        {
            try
            {
                var Cancelledbooking = (from i in db.Histories
                                        where i.CustId == id
                                        select i).ToList();
                return Ok(Cancelledbooking);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok();
            }

        }
    }
}
