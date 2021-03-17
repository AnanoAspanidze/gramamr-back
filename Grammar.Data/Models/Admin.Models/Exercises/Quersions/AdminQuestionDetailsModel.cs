using Grammar.Data.Models.Admin.Models.Exercises.Answers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grammar.Data.Models.Admin.Models.Exercises.Quersions
{
    public class AdminQuestionDetailsModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string WrongAnswerText { get; set; }
        public string RightAnswerText { get; set; }
        public IEnumerable<AdminAnswerDetailsModel> Answers { get; set; }
    }
}
