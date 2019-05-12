using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace De2_AI_Agent.Models
{
    [Serializable]
    public class ChildNode
    {

        public int Id { get; set; }
        public string data { get; set; }
        public int safety { get; set; }
        public int sentiment { get; set; }
        public List<ChildNode> Child {get;set;}



        

        public ChildNode(string value)
        {
            Child = new List<ChildNode>();
            this.data = value;
        }

        public ChildNode(string value,int Id)
        {
            //this.data = value;
            this.Id = Id;
        }
    }


}