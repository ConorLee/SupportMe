using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Controllers
{
    /// <summary>
    /// The Home Controller
    /// </summary>
    public class HomeController : Controller
    {

        //
        // GET: Index 

        public ActionResult Index()
        {
            return View();
        }
    }
}