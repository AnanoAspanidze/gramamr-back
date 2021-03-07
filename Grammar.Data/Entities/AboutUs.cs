using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Grammar.Data.Entities
{
   public class AboutUs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AboutProject { get; set; }
        public string UsingTerms { get; set; }
        public string Confidentiality { get; set; }
        public string FBPage { get; set; }
        public string FBGroup { get; set; }
    }
}
