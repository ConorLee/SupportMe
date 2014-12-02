using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SupportMe.Service;
using SupportMe.Service.Model;

namespace Portal.Controllers
{
    /// <summary>
    /// The Home Controller
    /// </summary>
    public class PresentationController : Controller
    {
 

        public PresentationController(PresentationService service)
        {
            if (service == null) throw new ArgumentNullException("service");
            this.service = service;
        }

        private readonly PresentationService service;

        //
        //GET : Add

        [HttpGet]
        public ActionResult Add()
        {
            return View(new Presentation());
        }

        //
        //POST : Add
        [HttpPost]
        public ActionResult Add(Presentation ip, Boolean complete, string action)
        {
            if(action.ToLower() == "create")
            {
                if (complete == false || complete == null)
                {
                    ViewBag.ErrorMessage = "An error has been detected!";
                    return View(ip);
                }
                else
                {

                    service.InsertPresentation(ip);

                    TempData.Add("SuccessNotice", "Person has been added!");
                    return RedirectToAction("Index");
                }
            }

            return HttpNotFound();
        }

    }
}