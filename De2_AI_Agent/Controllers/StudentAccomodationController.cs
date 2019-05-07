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
        public ActionResult Index(StudentAccomodation studentAccomodation)
        {


            TreeNode treeNode = c2t.RetrieveTree();

            if (treeNode == null)
            {
                treeNode = new TreeNode("Root");

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
                
                if(lower.Child.Count() != 0)
                {
                    treeNode.ChildNodes.Remove(lower);

                    ChildNode areas = lower.Child.Where(c => c.data == studentAccomodation.location).FirstOrDefault();

                    if (areas == null)
                    {
                        areas = new ChildNode(studentAccomodation.location);
                        
                    }


                    if(areas.Child.Count() != 0)
                    {
                        lower.Child.Remove(areas);
                        ChildNode childaccom = new ChildNode(studentAccomodation.Name);
                        areas.Child.Add(childaccom);
                        lower.Child.Add(areas);
                        treeNode.ChildNodes.Add(lower);

                        c2t.SaveTree(treeNode);
                        //AddAccomodation(studentAccomodation);
                    }
                    else
                    {

                        ChildNode areasaccom = new ChildNode(studentAccomodation.Name);
                        areas.Child.Add(areasaccom);
                        lower.Child.Add(areas);
                        treeNode.ChildNodes.Add(lower);

                        c2t.SaveTree(treeNode);

                        //AddAccomodation(studentAccomodation);

                    }
                    

                }
                else
                {
                    treeNode.ChildNodes.Remove(lower);
                    string local = studentAccomodation.location;
                       ChildNode area1 = new ChildNode(local);

                       ChildNode acc = new ChildNode(studentAccomodation.Name);

                        string name = studentAccomodation.Name;
                        area1.Child.Add(acc);
                        lower.Child.Add(area1);
                        treeNode.ChildNodes.Add(lower);
                        c2t.SaveTree(treeNode);

                        //TreeNode trees = c2t.RetrieveTree();
                        //var h = trees;
                        //AddAccomodation(studentAccomodation);
                    
                }
                //treeNode.ChildNodes.Add(lower);

                

            }
            else if(studentAccomodation.IncomeGroup == "Medium")
            {
                ChildNode middle = treeNode.ChildNodes.Where(c => c.data == "Medium").FirstOrDefault();
                if (middle.Child.Count() != 0)
                {
                    treeNode.ChildNodes.Remove(middle);
                    string mid = studentAccomodation.location;
                 
                    treeNode.ChildNodes.Add(middle);
                    ChildNode studcom = middle.Child.Where(c => c.data == mid).FirstOrDefault();

                    if(studcom == null)
                    {
                        studcom = new ChildNode(mid);
                        middle.Child.Add(studcom);
                    }


                    if (studcom.Child.Count()!=0)
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
                       //AddAccomodation(studentAccomodation);
                    }
                    else
                    {
                        treeNode.ChildNodes.Remove(middle);
                        middle.Child.Remove(studcom);
                        string accom = studentAccomodation.Name;
                        ChildNode staccom = new ChildNode(accom);
                        studcom.Child.Add(staccom);
                        middle.Child.Add(studcom);
                        treeNode.ChildNodes.Add(middle);

                        c2t.SaveTree(treeNode);

                        //AddAccomodation(studentAccomodation);
                        
                    }


                }
                else
                {
                    treeNode.ChildNodes.Remove(middle);
                    string mid = studentAccomodation.location;

                    
                        ChildNode studcom = new ChildNode(mid);

                        string accom = studentAccomodation.Name;
                        ChildNode staccom = new ChildNode(accom);
                        studcom.Child.Add(staccom);
                        middle.Child.Add(studcom);
                        treeNode.ChildNodes.Add(middle);

                        c2t.SaveTree(treeNode);

                        // TreeNode tre = c2t.RetrieveTree();
                        //var tu = tre;
                        //dynamic tu = treeNode;
                      //  AddAccomodation(studentAccomodation);
                    
                    
                }
            }
            else
            {

                ChildNode higher = treeNode.ChildNodes.Where(c => c.data == "High").FirstOrDefault();
                if (higher.Child.Count()!=0)
                {
                    treeNode.ChildNodes.Remove(higher);
                    string high = studentAccomodation.location;
                    
                   
                    ChildNode childNodehigher = higher.Child.Where(c => c.data == high).FirstOrDefault();
                    if(childNodehigher == null)
                    {
                        childNodehigher = new ChildNode(high);
                        higher.Child.Add(childNodehigher);
                    }

                    if (childNodehigher.Child.Count() != 0)
                    {

                        //treeNode.ChildNodes.Remove(higher);
                        higher.Child.Remove(childNodehigher);
                        string nameHigh = studentAccomodation.Name;
                        ChildNode child = new ChildNode(nameHigh);
                        childNodehigher.Child.Add(child);
                        higher.Child.Add(childNodehigher);
                        treeNode.ChildNodes.Add(higher);

                        c2t.SaveTree(treeNode);
                      
                        //AddAccomodation(studentAccomodation);
                    }
                    else
                    {
                        
                        higher.Child.Remove(childNodehigher);
                        string nameHigh = studentAccomodation.Name;
                        ChildNode child = new ChildNode(nameHigh);
                        childNodehigher.Child.Add(child);
                        higher.Child.Add(childNodehigher);
                        treeNode.ChildNodes.Add(higher);

                        c2t.SaveTree(treeNode);
                        
                        //AddAccomodation(studentAccomodation);

                    }

                   
                }
                else
                {
                    treeNode.ChildNodes.Remove(higher);
                    ChildNode higharea = new ChildNode(studentAccomodation.location);

                    ChildNode accom = new ChildNode(studentAccomodation.Name);
                    higharea.Child.Add(accom);
                    higher.Child.Add(higharea);
                    treeNode.ChildNodes.Add(higher);

                    c2t.SaveTree(treeNode);

                    //AddAccomodation(studentAccomodation);
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