using System;
using System.ComponentModel.DataAnnotations;

namespace prueba_toka.Models
{
    public class Question : Post
    {

        [Required]
        [StringLength(50)]
        public String Tittle { get; set; }
    }
}