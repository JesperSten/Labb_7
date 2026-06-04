using System;
using System.Collections.Generic;
using System.Text;

namespace Labb_7
{
    public class TreeNode
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public TreeNode FirstChild { get; set; }
        public TreeNode NextSibling { get; set; }

        public TreeNode(string id, string type, string name)
        {
            Id = id;
            Type = type;
            Name = name;
        }
    }
}
