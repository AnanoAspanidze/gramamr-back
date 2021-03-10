using System;
using System.Collections.Generic;
using System.Text;

namespace Grammar.Data.Models.Admin.Models
{
    public class AdminSubCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public string Category { get; set; }
      
    }
}
