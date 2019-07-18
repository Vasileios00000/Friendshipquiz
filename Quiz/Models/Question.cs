using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiz.Models
{
    public class Question
    {

        public int Id { get; set; }

        public int QuestNumber { get; set; }

        public string MainQuestion { get; set; }

        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }

        public string CorrectAns { get; set; }

        public Human human { get; set; }


    }
}