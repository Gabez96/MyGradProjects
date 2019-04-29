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
        StudentAccomodation studentAccomodation;
        TreeNode treeNode;
        ConvertToText c2t;
        // GET: Ratings
        public ActionResult Index()
        {
            return View();
        }

       [HttpPost]
        public ActionResult Index(Rater rateings)
        {
            rateings.UsersId = 1;
            rateings.StudentAccomodationId = 1;

            if (ModelState.IsValid)
            {
                try
                {
                    studentAccomodation = treedatStore.StudentAccomodation.Where(c => c.Id == rateings.StudentAccomodationId).FirstOrDefault();
                    treedatStore.Rater.Add(rateings);
                    treedatStore.SaveChanges();
                    
                }
                catch(Exception ex)
                {
                    ex.ToString();
                }

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
                                    if(studentAccomodation.Name== acomodation.data)
                                    {

                                        acomodation.Id = Convert.ToString(rateings.safety + rateings.service);
                                        
                                        var t = treeNode;
                                    }



                                }
                            }


                        }
                    }

                   
                }
                
                

            }

            
            return View();
        }
    }
}