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
            if (recommendations != null)
            {
                GetRecommendations(recommendations);
                //accomodationSuper.overalRecommendations = studentAccomodation;
                TempData["nullOverall"] = false;
            }
            else
            {
                TempData["nullOverall"] = true;
            }

            
            //List<string> recommendations_safety = dFS.IterativeDeepeningSearch(treeNode, percepts, 3, 2);
            //if (recommendations_safety != null)
            //{
            //    GetURecommendations(recommendations_safety);
            //    //accomodationSuper.basedOnSafety = studentAccomodation;
            //}
            //else
            //{
                
            //    TempData["nullSafety"] = true;
            //}
           
            List<string> recommendations_sentiment = dFS.IterativeDeepeningSearch(treeNode, percepts, 3, 3);

            if (recommendations_sentiment != null)
            {
                GetTRecommendations(recommendations_sentiment);
                // accomodationSuper.basedOnsentiment = studentAccomodation;

                TempData["nullSentiment"] = false;
            }
            else
            {

                TempData["nullSentiment"] = true;
            }

            if (accomodationSuper != null)
            {
              
                Session["RecommendationRating"] = accomodationSuper;
                return RedirectToAction("ShowRecommendations", "Recommend");  
            }
            return View();
        }

        public ActionResult ShowRecommendations()
        {
            

            StudentAccomodationSuper studAccomodations = (StudentAccomodationSuper)Session["RecommendationRating"];

            if (studAccomodations != null)
            {
                return View(studAccomodations);
            }
            return null;
        }


        public string GetRecommendations(List<string> recomm)
        {
            if (studentAccomodation.Count !=0)
            {
               
                studentAccomodation = new List<StudentAccomodation>();
            }
            StudentAccomodation studcom = new StudentAccomodation();
           for(int i  =0; i < recomm.Count; i++)
           {
                string h = recomm[i];
                try
                {
                    accomodationSuper.overalRecommendations = new List<StudentAccomodation>();

                    studcom = db.StudentAccomodation.Where(c => c.Name == h).FirstOrDefault();
                    accomodationSuper.overalRecommendations.Add(studcom);
                }
                catch(Exception e)
                {
                    e.ToString();
                }           
           }
            return null;
        }
        public string GetURecommendations(List<string> recomm)
        {
            
            StudentAccomodation studsafety = new StudentAccomodation();
            for (int i = 0; i < recomm.Count; i++)
            {
                string h = recomm[i];
                try
                {
                    accomodationSuper.basedOnSafety = new List<StudentAccomodation>();
                    studsafety = db.StudentAccomodation.Where(c => c.Name == h).FirstOrDefault();
                    accomodationSuper.basedOnSafety.Add(studsafety);
                }
                catch (Exception e)
                {
                    e.ToString();
                }
            }
            return null;
        }
        public string GetTRecommendations(List<string> recomm)
        {
            
            StudentAccomodation studm = new StudentAccomodation();
            for (int i = 0; i < recomm.Count; i++)
            {
                string h = recomm[i];
                try
                {
                    accomodationSuper.basedOnsentiment = new List<StudentAccomodation>();
                    studm = db.StudentAccomodation.Where(c => c.Name == h).FirstOrDefault();
                    accomodationSuper.basedOnsentiment.Add(studm);
                }
                catch (Exception e)
                {
                    e.ToString();
                }
            }
            return null;
        }

        public ActionResult ViewAccomo (int ViewId)
        {
            StudentAccomodation accomodationStud;
            List<Rater> rater;
            RecoomendSuperclass recmSuper;
            try
            {
                accomodationStud = new StudentAccomodation();
                rater = new List<Rater>();
                recmSuper = new RecoomendSuperclass();
                accomodationStud = db.StudentAccomodation.Where(c => c.Id == ViewId).FirstOrDefault();

                rater = db.Rater.Where(c => c.StudentAccomodationId == accomodationStud.Id).ToList();



                accomodationStud.Rater = rater;

                return View(accomodationStud);


            }catch(Exception e)
            {



            }
            return View();
        }



    }
}