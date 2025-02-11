using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAPI.Models;

namespace TaskAPI.Services.Models
{
   public class CreateAuthorDto
    {

        public int Id { get; set; }
        public string FullName { get; set; }

     
        public string AddressNo { get; set; }
       
        public string Street { get; set; }

       
        public string City { get; set; }

       
        public String JobRole { get; set; }

        public ICollection<createTodoDto> Todos { get; set; } = new List<createTodoDto>();


    }
}
