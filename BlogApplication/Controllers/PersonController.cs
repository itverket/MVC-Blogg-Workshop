using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicationModel.Models;
using BlogApplication.Models;

namespace BlogApplication.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View(new PersonViewModel
            {
                Id = 1,
                FirstName = "Donald",
                LastName = "Duck",
                Age = 30,
                Gender = Gender.Male,
                Children = new List<Child>
                {
                    new Child {Id = 1, FirstName = "Ole", Gender = Gender.Male, Age = 2},
                    new Child {Id = 2, FirstName = "Dole", Gender = Gender.Male, Age = 4},
                    new Child {Id = 3, FirstName = "Doffen", Gender = Gender.Male, Age = 6},
                    new Child {Id = 4, FirstName = "Hetti", Gender = Gender.Female, Age = 2},
                    new Child {Id = 5, FirstName = "Letti", Gender = Gender.Female, Age = 4},
                    new Child {Id = 6, FirstName = "Netti", Gender = Gender.Female, Age = 6}
                }
            });
        }
    }
}