using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace De2_AI_Agent.Models
{
    public class StudentAccomodation
    {
        public int Id { get; set; }
        public string Name {get;set;}
        public string location { get; set; }
        public string IncomeGroup { get; set; }
        [Required]
        public int AccomodationOwnerUsersId { get; set; }

        public virtual AccomodationOwner AccomodationOwner { get; set; }
        public ICollection<Rater> Rater { get; set; }

    }
}