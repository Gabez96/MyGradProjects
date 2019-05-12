using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using De2_AI_Agent.Models;
using De2_AI_Agent.TreeStore;

namespace De2_AI_Agent.Controllers
{
    public class RatingsController : Controller
    {
        DataStorage treedatStore = new DataStorage();
        
        TreeNode treeNode;
        ConvertToText c2t;
        // GET: Ratings
        int Id;

        public ActionResult GetAllStudentAccomodations()
        {
            List<StudentAccomodation> stu = null;
            try
            {

                stu = new List<StudentAccomodation>();

                stu = treedatStore.StudentAccomodation.ToList();

                return View(stu);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return View(stu);
        }


        public ActionResult RateAccomodation(int RateId)
        {
            StuAccomRatings stuaccomratings = new StuAccomRatings();
            try
            {

                var  stu = treedatStore.StudentAccomodation.Where(c => c.Id == RateId).FirstOrDefault();
                Id = stu.Id;
                stuaccomratings.Name = stu.Name;
                stuaccomratings.IncomeGroup = stu.IncomeGroup;
                stuaccomratings.location = stu.location;
                stuaccomratings.ImageUrl = stu.ImageUrl;
                stuaccomratings.Description = "mnjhbvfjdksld sdmckvjhcdjkfv dkcjhdnjcvhbgd";

                return View(stuaccomratings);
            }catch(Exception e)
            {

                e.ToString();
            }

            return View();
        }

        [HttpPost]
        public ActionResult RateAccomodation(StuAccomRatings stuAccomRatings)
        {
            if (ModelState.IsValid)
            {

                Rater r = new Rater();

                r.safety = stuAccomRatings.safety;
                r.service = stuAccomRatings.service;
                r.StudentAccomodationId = Id;
                r.UsersId = 19;
                r.review = stuAccomRatings.review;

                try
                {
                    //treedatStore.Rater.Add(r);
                    //treedatStore.SaveChanges();

                    SaveRating(r, stuAccomRatings);
                }
                catch(Exception e)
                {
                    e.ToString();
                }
               
            }

            return View();
        }



        public int SaveRating(Rater rateings, StuAccomRatings studentAccomodation)
        {
            SentimentAnalysis sentiment = new SentimentAnalysis();

            if (ModelState.IsValid)
            {              
                c2t = new ConvertToText();
                treeNode = c2t.RetrieveTree();
             
                foreach(ChildNode node in treeNode.ChildNodes)
                {
                    if (node.data == studentAccomodation.IncomeGroup)
                    {

                        foreach(ChildNode area in node.Child)
                        {
                            if(area.data == studentAccomodation.location)
                            {

                                foreach(ChildNode acomodation in area.Child)
                                {
                                    if(studentAccomodation.Name == acomodation.data)
                                    {
                                        int val = acomodation.Id;
                                        if(val > 0)
                                        {
                                            acomodation.Id = (val + (rateings.safety + rateings.service)) / 2;
                                        }
                                        else
                                        {
                                            acomodation.Id = rateings.safety + rateings.service;
                                        }
                                        acomodation.safety = rateings.safety;

                                        acomodation.sentiment = sentiment.DeterminePolarity(studentAccomodation.review);

                                        var t = treeNode;


                                        c2t.SaveTree(treeNode);
                                        break;
                                    }
                                }
                            }


                        }
                    }   
                }
                return 1;      
            }
          
            return -1;
        }
    }
}