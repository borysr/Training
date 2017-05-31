using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Identity.Controllers
{
    [Authorize]
    public class SecretController : Controller
    {
        // GET: Secret
        public ContentResult Secret()
        {
            return Content("This is srcret..."); ;
        }
        [AllowAnonymous]
        public ContentResult Overt()
        {
            return Content("This is not secret...");
        }
    }
}