﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace De2_AI_Agent.Models
{
    public class ChildNode
    {

        public string Id { get; set; }
        public string data { get; set; }
        public List<ChildNode> Child {get;set;}



        

        public ChildNode(string value)
        {
            Child = new List<ChildNode>();
            this.data = value;
        }

        public ChildNode(string value,string Id)
        {
            //this.data = value;
            this.Id = Id;
        }
    }


}