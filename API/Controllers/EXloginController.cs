using Api_DBS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_DBS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EXloginController : ControllerBase
    {
        //private readonly ISession session;
        private readonly DBS_serviceContext db;

        public EXloginController(DBS_serviceContext _db )
        {
            db = _db;
            //session = httpContextAccessor.HttpContext.Session;
        }
        [HttpGet]
            public IActionResult Getlogin()
            {
                return Ok(db.Eregistrations.ToList());
            }
            [HttpPost]
            public IActionResult login(Eregistration r)
            {
                var result = (from i in db.Eregistrations
                              where i.ExecName==r.ExecName&&i.Password==r.Password
                              select i).SingleOrDefault();
                if (result!=null)
                {
                    //HttpContext.Session.SetString("uname", r.ExecName);
                    return Ok(result);
                }
                else
                {
                    return Unauthorized();
                }

            }

        
    }
}
