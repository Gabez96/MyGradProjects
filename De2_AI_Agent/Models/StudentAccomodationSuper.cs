using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace De2_AI_Agent.Models
{
    public class StudentAccomodationSuper
    {
        public List<StudentAccomodation> overalRecommendations { get; set; }
        public  List<StudentAccomodation> basedOnsentiment { get; set; }
        public  List<StudentAccomodation> basedOnSafety { get; set; }
       




    }
}