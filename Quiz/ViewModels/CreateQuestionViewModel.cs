using Quiz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quiz.ViewModels
{
    public class CreateQuestionViewModel
    {
        public int Number { get; set; } = 0;

        
        public string MainQuestion { get; set; }

        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }

        [Required]
        [Display(Name = "Correct Answer")]
        public string CorrectAns { get; set; }

        public int humanId { get; set; }




    }
}