using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba_toka.Models
{
    public abstract class Post
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public String IdUser { get; set; }
        [Required]
        [StringLength(280)]
        public String Body { get; set; }
    }
}