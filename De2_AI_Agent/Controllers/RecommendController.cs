using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using De2_AI_Agent.TreeStore;
using De2_AI_Agent.Models;
using System.Threading.Tasks;

namespace De2_AI_Agent.Controllers
{
    public class RecommendController : Controller
    {
        ConvertToText c2T;
        DataStorage db = new DataStorage();
        List<StudentAccomodation> studentAccomodation = new List<StudentAccomodation>();
        RecoomendSuperclass recoomendSuperclass;
        // GET: Recommend
        public ActionResult Index()
        {
            
            recoomendSuperclass = new RecoomendSuperclass();
            //List<StudentAccomodation> studentAccomodat = new List<StudentAccomodation>();

            recoomendSuperclass.studentAccomodations = db.StudentAccomodation.Take(10).ToList();
            //
            return View(recoomendSuperclass);
        }

        


        [HttpPost]
        public ActionResult Index(string income, string area)
        {
            c2T = new ConvertToText();
            TreeNode treeNode = c2T.RetrieveTree();
            DFS dFS = new DFS();
            ChildNode goal = new ChildNode(income);
            goal.Id = area;

            List<string> recommendations = dFS.IterativeDeepeningSearch(treeNode,goal, 3);
            if (recommendations != null)
            {
                GetRecommendations(recommendations);
            }
            if (studentAccomodation != null)
            {
                return Json(studentAccomodation, JsonRequestBehavior.AllowGet);
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public string GetRecommendations(List<string> recomm)
        {
          
            StudentAccomodation studcom = new StudentAccomodation();
           for(int i  =0; i < recomm.Count; i++)
           {
                try
                {
                    studcom = db.StudentAccomodation.Where(c => c.Name == recomm[i]).FirstOrDefault();
                    studentAccomodation.Add(studcom);
                }
                catch(Exception e)
                {
                    return null;
                }
           
           }
            return null;
        }
    }
}