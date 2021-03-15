using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Grammar.Data.Entities
{
    public class Questions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public bool IsActive { get; set; }=true;

        public string WrongAnswerText { get; set; }

        public string RightAnswerText { get; set; }

        [Required]
        public int ExerciseId { get; set; } 

        [ForeignKey("ExerciseId")]
        public virtual Exercises Exercise { get; set; }

        public virtual ICollection<Answers> Answers { get; set; }

        public virtual ICollection<UsersAnswers> UsersAnswers { get; set; }
    }
}
