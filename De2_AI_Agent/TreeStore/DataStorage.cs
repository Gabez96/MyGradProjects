using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using De2_AI_Agent.Models;
using System.Web;
using System.Web.Configuration;

namespace De2_AI_Agent.TreeStore
{
    public class DataStorage : DbContext
    {
       public  DbSet<AccomodationOwner> AccomodationOwner { get; set; }
       public   DbSet<Rater> Rater {get;set; }
       public DbSet<Student> Student { get; set; }
       public  DbSet<StudentAccomodation> StudentAccomodation { get; set; }
       public  DbSet<Users> Users { get; set; }

    }
}