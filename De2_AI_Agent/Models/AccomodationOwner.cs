using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace De2_AI_Agent.Models
{
    public class AccomodationOwner
    {


        public int Id { get; set; }
        [Required]
        public int phoneNumber { get; set; }
        [Required]
        public int UsersId { get; set; }
        
        public virtual Users Users { get; set; }
        public ICollection<StudentAccomodation> StudentAccomodation { get; set; }
    }
}