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
        StudentAccomodationSuper accomodationSuper;
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
            accomodationSuper = new StudentAccomodationSuper();
            DFS dFS = new DFS();
            RecoomendSuperclass.Percept percepts = new RecoomendSuperclass.Percept();
            percepts.Incomegroup = percept.Incomegroup;
            percepts.area = percept.area;
            

            List<string> recommendations = dFS.IterativeDeepeningSearch(treeNode,percepts, 3,1);
            List<string> recommendations_safety = dFS.IterativeDeepeningSearch(treeNode, percepts, 3, 2);
            List<string> recommendations_sentiment = dFS.IterativeDeepeningSearch(treeNode, percepts, 3, 3);

            if (recommendations != null)
            {
                GetRecommendations(recommendations);
            }
            accomodationSuper.overalRecommendations = studentAccomodation;
            if (recommendations_safety != null)
            {
                GetRecommendations(recommendations_safety);
            }
            accomodationSuper.basedOnSafety = studentAccomodation;
            if (recommendations_sentiment != null)
            {
                GetRecommendations(recommendations_sentiment);
            }
            

            if (studentAccomodation != null)
            {
               accomodationSuper.basedOnsentiment = studentAccomodation;

                Session["RecommendationRating"] = accomodationSuper;
                return RedirectToAction("ShowRecommendations", "Recommend");
               
            }
            return View();
        }

        public ActionResult ShowRecommendations()
        {

            StudentAccomodationSuper studentAccomodations = (StudentAccomodationSuper)Session["RecommendationRating"];

            if (studentAccomodations != null)
            {
                return View(studentAccomodations);
            }
            return null;
        }


        public string GetRecommendations(List<string> recomm)
        {
            if (studentAccomodation.Count !=0)
            {
                studentAccomodation = null;
                studentAccomodation = new List<StudentAccomodation>();
            }
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