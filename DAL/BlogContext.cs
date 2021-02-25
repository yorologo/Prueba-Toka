using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using prueba_toka.Models;

namespace Prueba_Toka.DAL
{
    public class BlogContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }
    }
}