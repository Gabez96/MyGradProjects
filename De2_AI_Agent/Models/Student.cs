using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace De2_AI_Agent.Models
{
    public class Student
    {

        public int Id { get; set; }
        public string University { get; set; }

        [Required]
        public int UsersId { get; set; }

        public virtual Users Users { get; set; }
        
        public ICollection<Rater> Rater { get; set; }

        
    }
}