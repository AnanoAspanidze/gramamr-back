using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Grammar.Data.Entities
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string RegionName { get; set; }

        [MaxLength(50)]
        public string School { get; set; }

        [MaxLength(50)]
        [Required]
        public string Email { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Surname { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Roles Role { get; set; }

        public virtual ICollection<UsersAnswers> UsersAnswers { get; set; }

        public virtual ICollection<TeachersStudents> TeachersStudents { get; set; }

        public virtual ICollection<TeachersStudents> StudentsTeachers { get; set; }

        public virtual ICollection<Exercises> Exercises { get; set; }
    }
}
