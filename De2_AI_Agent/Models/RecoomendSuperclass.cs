using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace De2_AI_Agent.Models
{
    public class RecoomendSuperclass
    {


        public List<Rater> raters { get; set; }
       
        public List<StudentAccomodation> studentAccomodations { get; set; }
        public Percept percept { get; set; }
        public class Percept
        {
            public string area { get; set; }
            public string Incomegroup { get; set; }

        } 
    }
}