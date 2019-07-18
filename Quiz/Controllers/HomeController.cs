using Microsoft.AspNet.Identity;
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
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult Index()
        {
            AnswerData.QuestionNumber = 0;
            AnswerData.CorrectAnswers = 0;
            AddQuestionNumber.QuestionNumber = 0;

            List<Human> humen = new List<Human>();

            var humen_all  = _context.Humen.ToList();       
            foreach (var item in humen_all)
            {
                var list = _context.Questions.Where(x => x.human.Id == item.Id).ToList();
                if (list.Count() == 10)
                {
                    humen.Add(item);
                };

            }           
            return View(humen);
        }

        public ActionResult HighScores(int id)
        {
            var scores = _context.Scores.Where(x => x.HumanId == id).OrderByDescending(y=>y.FinalScore).ToList();

            return View(scores);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
        public ActionResult StartQuiz(int Id)
        {
            var userid = User.Identity.GetUserId();
            var score = _context.Scores.Any(x => x.HumanId == Id && x.ApplicationUserId == userid);
            if (score)
            {
                return View("AlreadyPLayed");
            }

            var quest = _context.Questions.Where(x => x.human.Id == Id).OrderBy(b => b.QuestNumber).ToList();
            AnswerData.human_id = Id;

            int ind = AnswerData.QuestionNumber;
            if (ind == 10)
            {
                ind = 0;
            }


            return View("ShowQuestion", quest[ind]);
           
        }

        [HttpPost]
        public ActionResult GetAnswer(string answer)
        {
            int a = AnswerData.QuestionNumber;
            int Id = AnswerData.human_id;
            var quest = _context.Questions.Where(x => x.human.Id == Id).OrderBy(b => b.QuestNumber).ToList();

            if (quest[a].CorrectAns == answer)
            {
                AnswerData.CorrectAnswers = AnswerData.CorrectAnswers + 1;
            }

            AnswerData.QuestionNumber = AnswerData.QuestionNumber + 1;

            if (AnswerData.QuestionNumber > 9)
            {
                var userid = User.Identity.GetUserId();
                var user = _context.Users.Find(userid);

                Score score = new Score()
                {
                    HumanId = Id,
                    ApplicationUserId = userid,
                    FinalScore = AnswerData.CorrectAnswers,
                };
                _context.Scores.Add(score);
                _context.SaveChanges();


                ViewBag.FinalScore = AnswerData.CorrectAnswers;
                AnswerData.QuestionNumber = 0;
                AnswerData.CorrectAnswers = 0;

                FeatureViewModel model = new FeatureViewModel();

                model.Name = _context.Humen.Find(Id).Name;

                return View("Score",model);
            }

            return RedirectToAction("StartQuiz", "Home",new { id=Id});

        }

        public ActionResult Delete(int humanid)
        {
            //remove scores
            var score_list = _context.Scores.Where(x => x.HumanId==humanid);
            foreach (var item in score_list)
            {
                _context.Scores.Remove(item);

            }
            _context.SaveChanges();

            //remove questions
            var question_list = _context.Questions.Where(c => c.human.Id == humanid);
            foreach (var item in question_list)
            {
                _context.Questions.Remove(item);

            }
            _context.SaveChanges();

            //remove human    
            var human=_context.Humen.Find(humanid);
            NameDTO name = new NameDTO()
            {
                Name = human.Name
            };
            _context.Humen.Remove(human);
            _context.SaveChanges();
                
            return View("~/Views/Home/SuccessfullyDeleted.cshtml", name);


        }
       

    }
}