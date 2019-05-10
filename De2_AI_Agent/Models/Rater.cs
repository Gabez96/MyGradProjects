using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace De2_AI_Agent.Models
{
    public class Rater
    {

        public int Id { get; set; }
        [Required]
        public int service { get; set; }
        public int safety { get; set; }

        public string review { get; set; }

        [Required]
        public int UsersId {get;set;}
        [Required]
        public int StudentAccomodationId { get; set; }

        public virtual Users Users { get; set; }
        public virtual StudentAccomodation StudentAccomodation { get; set; }
        
    }
}