﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAPI.Models
{
    public class Author
    {

        public int Id { get; set; }

        [Required] //data anotation
        [MaxLength(250)]
        public string FullName { get; set; }

        [MaxLength(10)]
        public string AddressNo { get; set; }
        [MaxLength(200)]
        public string Street { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(50)]
        public String JobRole { get; set; }


        public ICollection<Todo> Todos { get; set; }=new List<Todo>();
        
    }
}
