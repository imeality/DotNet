using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWebApi.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult index()
        {
            return Redirect("~/index.html");
        }
    }
}