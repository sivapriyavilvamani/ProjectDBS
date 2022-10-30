using Api_DBS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_DBS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DBS_serviceContext db;
        public CustomerController(DBS_serviceContext _db)
        {
            db=_db;
        }
        [HttpGet]
        public IActionResult GetCRegistration()
        {
            return Ok(db.Cregistrations.ToList());
        }
        [HttpPost]
        public IActionResult AddRegistertration(Cregistration r)
        {
            db.Cregistrations.Add(r);
            db.SaveChanges();
            return Ok(r);
        }
       
    }
}
