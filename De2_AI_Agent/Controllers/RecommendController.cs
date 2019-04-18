using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace De2_AI_Agent.Controllers
{
    public class RecommendController : Controller
    {
        // GET: Recommend
        public ActionResult Index()
        {
            return View();
        }

        public string GetRecommendations(string area, string incomegroup)
        {

            return null;
        }
    }
}