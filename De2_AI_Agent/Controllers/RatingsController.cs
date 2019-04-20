using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using De2_AI_Agent.Models;

namespace De2_AI_Agent.Controllers
{
    public class RatingsController : Controller
    {
        // GET: Ratings
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index(Rater rateings)
        {


            return View();
        }
    }
}