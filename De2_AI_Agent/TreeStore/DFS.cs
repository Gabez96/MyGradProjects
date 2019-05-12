
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using De2_AI_Agent.Models;

namespace De2_AI_Agent.TreeStore
{

    public class DFS
    {
       
        List<string> visitedNodes;
        Stack stack = new Stack();
        string goalval;
        List<string> studentaccomodations = new List<string>();
      
        public void TreeTraversal(TreeNode treeNode, string area, string incomegroup)
        {


            if (treeNode == null)
            {
                return;
            }


            visitedNodes = new List<string>();

            visitedNodes.Add(treeNode.Data);

            stack = new Stack();
            stack.Push(treeNode);


            TreeNode t = (TreeNode)stack.Pop();

            foreach (ChildNode child in t.ChildNodes)
            {

                Traverse(child, area, incomegroup);

            }

        }

        public void Traverse(ChildNode child, string area, string incomegroup)
        {

            if (child == null)
            {
                return;
            }

            visitedNodes.Add(child.data);
            stack.Push(child);




            while (stack.Count > 0)
            {
                ChildNode childNode = (ChildNode)stack.Pop();

                if (childNode.data == incomegroup)
                {
                    visitedNodes.Add(childNode.data);
                    System.Diagnostics.Debug.WriteLine(childNode.data);
                    foreach (ChildNode node in childNode.Child)
                    {

                        if (node.data == area)
                        {
                            visitedNodes.Add(node.data);
                            stack.Push(node);
                            System.Diagnostics.Debug.WriteLine(node.data);
                            foreach (ChildNode chd in node.Child)
                            {
                                visitedNodes.Add(chd.data);
                                System.Diagnostics.Debug.WriteLine(chd.data);
                                stack.Push(chd);
                                GetRecommendations(chd);

                            }
                        }
                    }
                }
            }

        }


        public string GetRecommendations(ChildNode node)
        {
          
            int rating = node.Id;

            if (rating >= 7)
            {
                return node.data;
            }
            
            return null;
        }

        public string GetRecommendationsForSafety(ChildNode node)
        {

            int rating = node.safety;

            if (rating >= 3.5)
            {
                return node.data;
            }

            return null;
        }
        public string GetRecommendationsSentiment(ChildNode node)
        {

            int rating = node.sentiment;

            if (rating >= 0.5)
            {
                return node.data;
            }

            return null;
        }
        public List<string> IterativeDeepeningSearch(TreeNode treee, RecoomendSuperclass.Percept gooal, int depth,int type)
        {
            List<string> result = new List<string>();


            for (int i = 0; i < depth; i++)
            {
                goalval = gooal.Incomegroup;
                result = DepthLimitedSearch(treee, gooal, depth, type);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }

        public List<string> DepthLimitedSearch(TreeNode tree, RecoomendSuperclass.Percept goal, int limit,int type)
        {
            
            ChildNode chd = new ChildNode(tree.Data);
            chd.Child = tree.ChildNodes;
            
            if(limit > 0)
            {
                
                foreach(ChildNode n in chd.Child)
                {
                   TreeNode trees = new TreeNode(n.data);
                   trees.ChildNodes = n.Child;

                    if (n.data == goalval)
                    {
                        goalval = goal.area;
                        DepthLimitedSearch(trees, goal, limit - 1,type);
                    }
                    System.Diagnostics.Debug.WriteLine(n.data);
                    if(n.Child.Count == 0)
                    {
                        string res = "";
                        switch (type)
                        {
                            case 1:
                                res = GetRecommendations(n);
                                break;
                            case 2:
                                  res = GetRecommendationsForSafety(n);
                                break;
                            case 3:
                                res = GetRecommendationsSentiment(n);
                                break;
                        }

                        //string res = GetRecommendations(n);
                        if (res != null)
                        {
                            studentaccomodations.Add(res);
                        }
                    }   
                    if(n.data == goal.Incomegroup & goalval == goal.area)
                    {
                        if (studentaccomodations != null)
                        {
                            return studentaccomodations;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            return null;
        }
    }
    
}


/*
 public string IterativeDeepeningSearch(TreeNode treee,ChildNode gooal,int depth)
        {
            string result = "";

            for (int i =0; i < depth; i++)
            {
                result = DepthLimitedSearch(treee, gooal,i);

                if (result != null)
                {
                    return "";
                }

            }

            return null;

        }

        public string DepthLimitedSearch(TreeNode tree,ChildNode goal,int limit)
        {
            string res = "";
            TreeNode treeChild;
          
            int depth = 3;

            if(tree.Data == goal.data)
            {
                return tree.Data;
            }
            ChildNode chd = new ChildNode(tree.Data);
            chd.Child = tree.ChildNodes;
            stack.Push(chd);
            
            string searchval = goal.data;
            
               
            if(limit <= depth)
            {
            
             
                    ChildNode child = (ChildNode)stack.Pop();

                    if(child.data == searchval)
                    {
                        
                        searchval = goal.Id;
                       
                        for(int y =0; y < child.Child.Count(); y++)
                        {
                            GetRecommendations(child.Child[y]);
                        }
                    }
                    else
                    {

                        foreach(ChildNode n in child.Child)
                        {
                            
                            if (!visited.Contains(n.data))
                            {
                                visited.Add(n.data);
                                stack.Push(n);
                            }
                       }
                        if(searchval == goal.Id)
                        {
                            goal.Id = searchval;
                        }
                    }
            }
            return null;
        }





    */
