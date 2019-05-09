using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using De2_AI_Agent.TreeStore;
using De2_AI_Agent.Models;

namespace De2_AI_Agent.Controllers
{
    public class RecommendController : Controller
    {
        ConvertToText c2T;
        // GET: Recommend
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(string username,string password)
        {
            c2T = new ConvertToText();
            TreeNode treeNode = c2T.RetrieveTree();
            DFS dFS = new DFS();

            dFS.TreeTraversal(treeNode, "");

            return View();
        }

        public string GetRecommendations(string area, string incomegroup)
        {

            return null;
        }
    }
}