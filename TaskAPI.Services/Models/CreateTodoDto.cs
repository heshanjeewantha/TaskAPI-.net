using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAPI.Models;

namespace TaskAPI.Services.Models
{
    public class createTodoDto
    {
       

        
        public string Title { get; set; }

        
        public string Description { get; set; }

        

      
        public DateTime Due { get; set; }
    
        public TodoStatus Status { get; set; } // New , Inprogress, Completed

        
       

    }
}
