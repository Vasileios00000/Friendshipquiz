using Quiz.DTOs;
using Quiz.Models;
using Quiz.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiz.Controllers
{
    public class CreateQuestionController : Controller
    {
        protected readonly ApplicationDbContext _context;

        public CreateQuestionController()
        {
            _context = new ApplicationDbContext();
        }

       

        public ActionResult CreateQuestion(int id)
        {
            CreateQuestionViewModel createquestionviewmodel = new CreateQuestionViewModel();

            createquestionviewmodel.humanId = id;
            AddQuestionNumber.QuestionNumber = AddQuestionNumber.QuestionNumber + 1;
            createquestionviewmodel.Number = AddQuestionNumber.QuestionNumber;

            if (createquestionviewmodel.Number > 10)
            {
                return View("QuestionsSubmitted");
            }


            return View(createquestionviewmodel);
        }

        [HttpPost]
        public ActionResult CreateQuestion(CreateQuestionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateQuestion", model);
            }

            Human human = _context.Humen.Find(model.humanId);

            Question question = new Question()
            {
                QuestNumber = model.Number,
                MainQuestion = model.MainQuestion,
                Answer1 = model.Answer1,
                Answer2 = model.Answer2,
                Answer3 = model.Answer3,
                Answer4 = model.Answer4,
                CorrectAns = model.CorrectAns,
                human = human
            };

            _context.Questions.Add(question);
            _context.SaveChanges();

            return RedirectToAction("CreateQuestion", "CreateQuestion",new { id=model.humanId});

        }
    }
}