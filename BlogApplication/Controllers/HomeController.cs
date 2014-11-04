using System;
using System.Web.Mvc;
using ApplicationModel;
using ApplicationModel.Repositories;
using BlogApplication.Models;
using Microsoft.Ajax.Utilities;

namespace BlogApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly AboutRepository _repository = new AboutRepository();

        public ActionResult About()
        {
            var repository = new AboutRepository();

            var aboutInformation = repository.GetAboutInformation();
            var model = new AboutInformationViewModel();
            if (aboutInformation != null)
            {
                model.AboutMe = aboutInformation.AboutMe;
                model.BirthDate = aboutInformation.BirthDate;
                model.FirstName = aboutInformation.FirstName;
                model.LastName = aboutInformation.LastName;
            }
           
            return View(model);
        }

        [HttpGet]
        public ActionResult EditAbout()
        {
            var repository = new AboutRepository();
            var aboutInformation = repository.GetAboutInformation();
            if (aboutInformation == null)
            {
                return View(new AboutInformationViewModel());
            }
            var model = new AboutInformationViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult EditAbout(AboutInformationViewModel viewmodel)
        {
            return null;
        }
    
    }
}