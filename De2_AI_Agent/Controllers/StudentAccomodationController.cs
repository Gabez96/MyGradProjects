using De2_AI_Agent.Models;
using De2_AI_Agent.TreeStore;
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
        private ConvertToText c2t = new ConvertToText();
        // GET: StudentAccomodation
        public ActionResult Index()
        {

            return View();
        }


        [HttpPost]
        public async  Task<ActionResult> Index(StudentAccomodation studentAccomodation)
        {


            TreeNode treeNode = c2t.RetrieveTree();

            if (treeNode == null)
            {
                ChildNode low = new ChildNode("Low");
                ChildNode medium = new ChildNode("Medium");
                ChildNode High = new ChildNode("High");
                treeNode.ChildNodes.Add(low);
                treeNode.ChildNodes.Add(medium);
                treeNode.ChildNodes.Add(High);
            }


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

                   ChildNode acc = lower.Child.Where(c => c.data == local).FirstOrDefault();

                    if (acc.Child.Count() == 0)
                    {

                        treeNode.ChildNodes.Remove(lower);
                        lower.Child.Remove(area1);
                        string name = studentAccomodation.Name;
                        ChildNode namelow = new ChildNode(name);
                        acc.Child.Add(namelow);
                        lower.Child.Add(acc);
                        treeNode.ChildNodes.Add(lower);
                       c2t.SaveTree(treeNode);
                        
                        //TreeNode trees = c2t.RetrieveTree();
                        //var h = trees;
                       AddAccomodation(studentAccomodation);
                    }
                    else
                    {

                    }
                    
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

                        c2t.SaveTree(treeNode);

                      // TreeNode tre = c2t.RetrieveTree();
                       //var tu = tre;
                        //dynamic tu = treeNode;
                       AddAccomodation(studentAccomodation);
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
                    ChildNode childNodehigher = higher.Child.Where(c => c.data == high).FirstOrDefault(); 
                    if(childNodehigher.Child.Count() == 0)
                    {

                        treeNode.ChildNodes.Remove(higher);
                        higher.Child.Remove(childNodehigher);
                        string nameHigh = studentAccomodation.Name;
                        ChildNode child = new ChildNode(nameHigh);
                        childNodehigher.Child.Add(child);
                        higher.Child.Add(childNodehigher);
                        treeNode.ChildNodes.Add(higher);

                        c2t.SaveTree(treeNode);
                        //TreeNode rt = c2t.RetrieveTree();
                        //var f = rt;
                       AddAccomodation(studentAccomodation);
                    }
                    else
                    {

                    }

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
            DataStorage dataStorage = new DataStorage();
            data.AccomodationOwnerUsersId = 1;
            try
            {
                dataStorage.StudentAccomodation.Add(data);
                dataStorage.SaveChanges();

            }catch(Exception e)
            {
                _ = e.StackTrace;
            }
        }

        public void SaveTree(TreeNode treedata)
        {


        }

    }
}