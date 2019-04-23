using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace CodeFirstApi.Controllers
{
    [EnableCors("*", "*","*")]


    public class PrescriptionCtrl : Controller
    {
        // GET: Prescription
        public ActionResult Index()
        {
            return View();
        }
        public ContentResult SendPrescription()
        {
            return Content("From email: " + Request.Form["fromemail"] +
                " | To email: " + Request.Form["toemail"] +
                " | Prescription: " + Request.Form["prescription"]);
        }
    }
}