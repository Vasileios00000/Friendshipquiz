using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiz.DTOs
{
    public class AnswerData
    {
        static public int CorrectAnswers { get; set; } = 0;

        static public int QuestionNumber { get; set; } = 0;

        static public int human_id { get; set; } = 0;
    }
}