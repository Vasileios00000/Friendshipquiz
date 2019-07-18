using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quiz.ViewModels
{


    public class FeatureViewModel
    {
        [Required]
        [Range(0,10,ErrorMessage ="Please enter a valid number between 0 and 10")]
        public int Difficulty { get; set; }

        public string Name { get; set; }
        
    }
}