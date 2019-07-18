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
    public class FeaturesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeaturesController()
        {
            _context=new ApplicationDbContext();
        }


        [HttpPost]
        public ActionResult Calculate(FeatureViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Home/Score.cshtml", model);
            }

            //average score calculation
            var allscore_list = _context.Scores.Where(b => b.HumanId == AnswerData.human_id).Select(x => x.FinalScore).ToList();
            double score_average = allscore_list.Average();

            //difficulty calculation
            _context.Humen.Find(AnswerData.human_id).AverageScore = score_average;
            var userid = User.Identity.GetUserId();
            _context.Scores.Where(x => x.HumanId == AnswerData.human_id && x.ApplicationUserId == userid).FirstOrDefault().Difficulty = model.Difficulty;
            _context.SaveChanges();

            var difficulty_list = _context.Scores.Where(z=>z.HumanId== AnswerData.human_id).Select(z => z.Difficulty).ToList();
            double difficulty_average = difficulty_list.Average();

            _context.Humen.Find(AnswerData.human_id).Difficulty = difficulty_average;
            //popularity calculation
            var user_number = _context.Users.Count() - 1;
            var user_played_that_human = _context.Scores.Where(x => x.HumanId == AnswerData.human_id).ToList().Count();

            double popularity = ((double)user_played_that_human / (double)user_number) * 100;
            _context.Humen.Find(AnswerData.human_id).Popularity = popularity;


            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}