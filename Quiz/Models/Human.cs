using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiz.Models
{


    public class Human
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Photo1 { get; set; }

        public string Photo2 { get; set; }

        public string Photo3 { get; set; }

        public double Popularity { get; set; }

        public double Difficulty { get; set; }

        public double AverageScore { get; set; }

        public string ApplicationUserId {get;set;}


    }
}