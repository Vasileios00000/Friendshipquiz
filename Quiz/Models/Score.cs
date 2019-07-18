using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quiz.Models
{
    public class Score
    {
        [Key]
        [Column(Order = 0)]
        public int HumanId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string ApplicationUserId { get; set; }


        public int FinalScore { get; set; }

        public int Difficulty { get; set; }

        public virtual Human human { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }



    

    }
}