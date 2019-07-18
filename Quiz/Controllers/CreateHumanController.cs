using Microsoft.AspNet.Identity;
using Quiz.Models;
using Quiz.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiz.Controllers
{
    public class CreateHumanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CreateHumanController()
        {
            _context = new ApplicationDbContext();

        }


        // GET: CreatePerson
        public ActionResult CreateHuman()
        {
            AddHumanViewModel addHumanViewModel = new AddHumanViewModel();

            return View(addHumanViewModel);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult CreateHuman(AddHumanViewModel model, HttpPostedFileBase photo1)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateHuman", model);
            };

            string name = model.FirstName + " " + model.LastName;

            string path ="";
            if (photo1 != null)
            {
                path = Path.Combine(Server.MapPath("~/Photos"), $"{Guid.NewGuid()}{Path.GetExtension(photo1.FileName)}");
                photo1.SaveAs(path);
            }

            Human human = new Human(){ Name = name, Photo1 = Path.GetFileName(path),ApplicationUserId=User.Identity.GetUserId() };
            _context.Humen.Add(human);
            _context.SaveChanges();

            return RedirectToAction("CreateQuestion", "CreateQuestion", new { id = human.Id });
        }







    }
}