using System;
using System.Collections.Generic;
using System.Text;

namespace Grammar.Data.Models.Admin.Models.Exercises
{
   public  class AdminExerciseCreateModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsSummaryExercise { get; set; }
        public IEnumerable<AdminCreateQuestionModel> Questions { get; set; }
        public int SubCategoryId { get; set; }
        public int TypeId { get; set; }
    }
}
