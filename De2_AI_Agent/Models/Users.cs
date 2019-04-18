using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace De2_AI_Agent.Models
{
    public class Users
    {

        public int Id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        
        public ICollection<Rater> Rater { get; set; }
        public ICollection<Student> Student { get; set; }
        public ICollection<AccomodationOwner> AccomodationOwner { get; set; }

    }
}