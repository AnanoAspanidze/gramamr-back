using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Grammar.Data.Entities
{
    public class Exercises
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool IsSummaryExercise { get; set; }

        [Required]
        public bool IsActive { get; set; }

        //[Required]
        public DateTime Date { get; set; }

        [Required]
        public int SubCategoryId { get; set; }

        [ForeignKey("SubCategoryId")]
        public virtual SubCategories SubCategory { get; set; }

        [Required]
        public int TypeId { get; set; }

        [ForeignKey("TypeId")]
        public virtual Types Type { get; set; }
    
        //[Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Users User { get; set; }

        public virtual ICollection<Questions> Questions { get; set; }
    }
}
