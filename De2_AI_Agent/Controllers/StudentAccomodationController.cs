using De2_AI_Agent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace De2_AI_Agent.Controllers
{
    public class StudentAccomodationController : Controller
    {
        // GET: StudentAccomodation
        public ActionResult Index()
        {


            return View();
        }


        [HttpPost]
        public async  Task<ActionResult> Index(StudentAccomodation studentAccomodation)
        {

            TreeNode treeNode = new TreeNode("Root");
            ChildNode low = new ChildNode("Low");
            ChildNode medium = new ChildNode("Medium");
            ChildNode High = new ChildNode("High");
            treeNode.ChildNodes.Add(low);
            treeNode.ChildNodes.Add(medium);
            treeNode.ChildNodes.Add(High);

            int t = treeNode.ChildNodes.Count();

            if(studentAccomodation.IncomeGroup == "Low")
            {
                ChildNode lower = treeNode.ChildNodes.Where(c => c.data == "Low").FirstOrDefault();
                
                if(lower.Child.Count() == 0)
                {
                    treeNode.ChildNodes.Remove(lower);
                    string local = studentAccomodation.location;
                    ChildNode area1 = new ChildNode(local);
                    lower.Child.Add(area1);
                    treeNode.ChildNodes.Add(lower);
                    
                    

                }
                

            }
            else if(studentAccomodation.IncomeGroup == "Medium")
            {
                ChildNode middle = treeNode.ChildNodes.Where(c => c.data == "Medium").FirstOrDefault();
                if (middle.Child.Count() == 0)
                {
                    treeNode.ChildNodes.Remove(middle);
                    string mid = studentAccomodation.location;
                    ChildNode area1 = new ChildNode(mid);
                    middle.Child.Add(area1);
                    treeNode.ChildNodes.Add(middle);
                    ChildNode studcom = middle.Child.Where(c => c.data == mid).FirstOrDefault();

                    if (studcom.Child.Count()==0)
                    {
                        treeNode.ChildNodes.Remove(middle);
                        middle.Child.Remove(studcom);
                        string accom = studentAccomodation.Name;
                        ChildNode staccom = new ChildNode(accom);
                        studcom.Child.Add(staccom);
                        middle.Child.Add(studcom);
                        treeNode.ChildNodes.Add(middle);
                        dynamic tu = treeNode;
                    }
                    else
                    {
                        studcom.Child.ToList();
                    }
                    

                }
            }
            else
            {

                ChildNode higher = treeNode.ChildNodes.Where(c => c.data == "High").FirstOrDefault();
                if (higher.Child.Count()==0)
                {
                    treeNode.ChildNodes.Remove(higher);
                    string high = studentAccomodation.location;
                    ChildNode highIncomeArea = new ChildNode(high);
                    higher.Child.Add(highIncomeArea);
                    treeNode.ChildNodes.Add(higher);

                    return View();
                }
            }

            return View();

            
        }


        public StudentAccomodation ViewAccomodation(int AccomId)
        {

            return null;
        }

        public void AddAccomodation(StudentAccomodation data)
        {

        }

    }
}