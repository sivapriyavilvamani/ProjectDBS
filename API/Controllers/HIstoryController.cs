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
            return Ok(db.Histories.ToList());
        }
        [HttpPost]
        public IActionResult History(History h)
        {
            db.Histories.Add(h);
            db.SaveChanges();
            return Ok(h);
        }
        [HttpGet]
        [Route("GetcancelHistoryById{id}")]
        public IActionResult GetcancelHistoryById(int id)
        {
            var f = db.Histories.Find(id);
            return Ok(f);
        }
        [HttpGet]
        [Route("GetCusHistory{id}")]
        public IActionResult GetCusHistory(int id)
        {
            var Cancelledbooking = (from i in db.Histories
                           where i.CustId == id
                           select i).ToList();
            return Ok(Cancelledbooking);
        }
    }
}
