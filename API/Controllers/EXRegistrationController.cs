using Api_DBS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_DBS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EXRegistrationController : ControllerBase
    {
        private readonly DBS_serviceContext db;

        public EXRegistrationController(DBS_serviceContext _db)
        {
            db=_db;
        }
        [HttpGet]
        public IActionResult GetERegistration()
        {
            return Ok(db.Eregistrations.ToList());
        }
        [HttpPost]
        public IActionResult AddRegistertration(Eregistration r)
        {
            db.Eregistrations.Add(r);
            db.SaveChanges();
            return Ok(r);
        }
       




    }



}
