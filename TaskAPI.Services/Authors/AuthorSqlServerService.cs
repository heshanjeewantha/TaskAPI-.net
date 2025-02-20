﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAPI.Models;
using TaskAPI.DataAccess;
namespace TaskAPI.Services.Authors
{
    public class AuthorSqlServerService : IAuthorRepository
    {

        private readonly TodoDbContext _context=new TodoDbContext();

        public List<Author> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }


        public List<Author> GetAllAuthors(string job ,string search)
        {
            if(string.IsNullOrWhiteSpace(job) && string.IsNullOrWhiteSpace(search)) 
            { 
              return GetAllAuthors();

            }
            var authorCollection = _context.Authors as IQueryable<Author>;

            if (!string.IsNullOrWhiteSpace(job) )
            {
                job = job.Trim();
                authorCollection = authorCollection.Where(a => a.JobRole == job);

            }
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();
                authorCollection = authorCollection.Where(a => a.FullName.Contains(search));
            }



            return authorCollection.ToList();

        }
        public Author GetAuthor(int id)
        {
            return _context.Authors.Find(id);
        }
        public Author AddAuthor(Author author)
        {
            // Ensure the Id is not set manually
            author.Id = 0; // or simply do not set the Id at all
            _context.Authors.Add(author);
            _context.SaveChanges();
            return author;
        }
    }
}
