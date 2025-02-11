using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskAPI.Models;

namespace TaskAPI.DataAccess
{
    public class TodoDbContext:DbContext
    {
       
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=MyTodoDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   modelBuilder.Entity<Author>().HasData(new Author[] { 
           new Author { Id = 1, FullName = "John Doe" },
           new Author { Id = 2, FullName = "Jane Doe" },
           new Author { Id = 3, FullName = "John Smith" },
           new Author { Id = 4, FullName = "Jane Smith" }



        });
            modelBuilder.Entity<Todo>().HasData(new Todo[]
            {
                new Todo
                {
                    Id = 1,
                    Title = "First Todo",
                    Description = "This is the first todo",
                    Created = new DateTime(2025, 2, 1, 10, 0, 0),  // Use a fixed date
                    Due = new DateTime(2025, 2, 2, 10, 0, 0),      // Use a fixed date
                    Status = TodoStatus.New,
                    AuthorId=1
                },
                new Todo
                {
                    Id = 2,
                    Title = "Second Todo",
                    Description = "This is the second todo",
                    Created = new DateTime(2025, 2, 1, 10, 0, 0),  // Use a fixed date
                    Due = new DateTime(2025, 2, 2, 10, 0, 0),      // Use a fixed date
                    Status = TodoStatus.New,
                    AuthorId=1
                },
                new Todo
                {
                    Id = 3,
                    Title = "Third Todo",
                    Description = "This is the third todo",
                    Created = new DateTime(2025, 2, 1, 10, 0, 0),  // Use a fixed date
                    Due = new DateTime(2025, 2, 2, 10, 0, 0),      // Use a fixed date
                    Status = TodoStatus.New,
                    AuthorId=1
                },

                });
        }


    }

}
