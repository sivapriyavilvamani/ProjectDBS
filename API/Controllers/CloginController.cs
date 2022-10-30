using Api_DBS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_DBS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CloginController : ControllerBase
    {
        private readonly DBS_serviceContext db;
        public CloginController(DBS_serviceContext _db)
        {
            db=_db;
        }
        [HttpGet]
        public IActionResult Getlogin()
        {
            return Ok(db.Cregistrations.ToList());
        }
        [HttpPost]
        public IActionResult login(Cregistration r)
        {
            var result = (from i in db.Cregistrations
                          where i.FirstName==r.FirstName && i.Password==r.Password
                          select i).SingleOrDefault();
            if (result!=null)
            {
                
                return Ok(result);
            }
            else
            {
                return Unauthorized();
            }

        }
    }
}
