using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba_toka.Models
{
    public class User
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public String Name { get; set; }
        [Required]
        [StringLength(50)]
        public String Email { get; set; }
        [Required]
        [StringLength(50)]
        public String Password { get; set; }
        public virtual ICollection<Question> QuestionList { get; set; }
        public virtual ICollection<Answer> AnswerList { get; set; }
    }
}