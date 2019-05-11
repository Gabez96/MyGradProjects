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

        



        public ActionResult ShowRecom()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ShowRecom(RecoomendSuperclass.Percept percept)
        {
            c2T = new ConvertToText();
            TreeNode treeNode = c2T.RetrieveTree();
            DFS dFS = new DFS();
            ChildNode goal = new ChildNode(percept.Incomegroup);
            goal.Id = percept.area;
            RecoomendSuperclass recoomend;
            List<string> recommendations = dFS.IterativeDeepeningSearch(treeNode,goal, 3);
            if (recommendations != null)
            {
                GetRecommendations(recommendations);
            }
            if (studentAccomodation != null)
            {
                recoomend = new RecoomendSuperclass();
                recoomend.studentAccomodations = studentAccomodation;

                Session["RecommendationRating"] = recoomend;
                return RedirectToAction("ShowRecommendations", "Recommend");
               
            }
            return View();
        }

        public ActionResult ShowRecommendations()
        {

            RecoomendSuperclass studentAccomodations = (RecoomendSuperclass)Session["RecommendationRating"];

            if (studentAccomodations != null)
            {
                return View(studentAccomodations.studentAccomodations);
            }
            return null;
        }


        public string GetRecommendations(List<string> recomm)
        { 
            StudentAccomodation studcom = new StudentAccomodation();
           for(int i  =0; i < recomm.Count; i++)
           {
                string h = recomm[i];
                try
                {
                    studcom = db.StudentAccomodation.Where(c => c.Name == h).FirstOrDefault();
                    studentAccomodation.Add(studcom);
                }
                catch(Exception e)
                {
                    e.ToString();
                }           
           }
            return null;
        }
    }
}