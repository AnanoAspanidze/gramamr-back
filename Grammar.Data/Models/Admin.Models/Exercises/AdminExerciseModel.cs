using System;
using System.Collections.Generic;
using System.Text;

namespace Grammar.Data.Models.Admin.Models.Exercises
{
  public  class AdminExerciseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string SubCategory { get; set; }

        public string Type { get; set; }

        public bool IsSummaryExercise { get; set; }

        public bool IsActive { get; set; }
    }
}
