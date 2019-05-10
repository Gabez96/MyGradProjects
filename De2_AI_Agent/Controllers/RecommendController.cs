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
        DataStorage db;
        // GET: Recommend
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(Login login)
        {
            c2T = new ConvertToText();
            db = new DataStorage();
            TreeNode treeNode = c2T.RetrieveTree();
            DFS dFS = new DFS();
            ChildNode goal = new ChildNode(login.password);
            goal.Id = login.username;

            List<string> recommendations = dFS.IterativeDeepeningSearch(treeNode,goal, 3);
            if (recommendations != null)
            {
                GetRecommendations(recommendations);
            }
            return View();
        }

        public string GetRecommendations(List<string> recomm)
        {
          List<StudentAccomodation> studentAccomodation = new List<StudentAccomodation>();
            StudentAccomodation studcom = new StudentAccomodation();
           for(int i  =0; i < recomm.Count; i++)
           {
                studcom = db.StudentAccomodation.Where(c => c.Name == recomm[i]).FirstOrDefault();
                studentAccomodation.Add(studcom);
           }
            return null;
        }
    }
}