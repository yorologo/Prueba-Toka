using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba_toka.Models
{
    public class Answer : Post
    {
        [Required]
        public int IdQuestion { get; set; }
        public virtual Question Question { get; set; }
        [Required]
        public bool Correct { get; set; }
    }
}