
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
        int counter = 0;
        List<string> visitedNodes;
        Stack stack;
        public void TreeTraversal(TreeNode treeNode,string area, string incomegroup)
        {
           

            if(treeNode == null)
            {
                return;
            }


            visitedNodes = new List<string>();

            visitedNodes.Add(treeNode.Data);

            stack = new Stack();
            stack.Push(treeNode);
            
            
             TreeNode t =(TreeNode) stack.Pop();
               
             foreach(ChildNode child in t.ChildNodes)
             {

                    Traverse(child);
             }
                          
        }

        public void Traverse(ChildNode child)
        {

            if(child == null)
            {
                return;
            }

            visitedNodes.Add(child.data);
            stack.Push(child);

            
            while(stack.Count > 0)
            {
                ChildNode childNode = (ChildNode)stack.Pop();
                
                foreach (ChildNode node in childNode.Child)
                {
                                       
                        visitedNodes.Add(node.data);

                        stack.Push(node);

                        System.Diagnostics.Debug.WriteLine(node.data);
                    
                    if(node.Child.Count == 0)
                    {
                        GetRecommendations(node);
                    }
                   
                }
            }

        }


        public List<string> GetRecommendations(ChildNode node)
        {
            List<string> recommendationsm = new List<string>();
            int rating = Convert.ToInt32(node.Id);

            if(rating > 7)
            {
                recommendationsm.Add(node.data);
            }
            return null;
        }
    }
}