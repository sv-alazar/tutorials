using MVC2.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC2.Controllers
{
    public class CuisineController : Controller
    {
 
       // [Authorize]//user must be logged
        [Log]
        public ActionResult Search(string name="french")
        {
       //     throw new Exception("fatal error");

            var message = Server.HtmlEncode(name);
            return Content(message);

        }
    }
}
