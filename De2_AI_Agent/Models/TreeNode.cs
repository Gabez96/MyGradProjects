using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace De2_AI_Agent.Models
{
    public class TreeNode
    {

       public string Data { get; set; }
       public List<ChildNode> ChildNodes { get; set; }
       public TreeNode RootNode { get; set; }


        public TreeNode()
        {

        }
        public TreeNode(string value)
        {
            this.Data = value;
            ChildNodes = new List<ChildNode>();
        }


        public void AddChild(ChildNode value,int index)
        {
            RootNode.ChildNodes[index].Child.Add(value);
        }

        public ChildNode GetChild(string id)
        {
            return RootNode.ChildNodes.Where(c => c.Id == id).FirstOrDefault();
        }


        public TreeNode GetRootNode()
        {
            return RootNode;
        }

        public void DeleteNode(ChildNode child)
        {
            RootNode.ChildNodes.Remove(child);
        }

    }
}