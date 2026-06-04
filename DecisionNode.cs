using System;
using System.Collections.Generic;
using System.Text;

namespace Labb_7
{
    public class DecisionNode
    {
        public string Text { get; set; }
        public bool IsQuestion { get; set; }

        public DecisionNode Yes { get; set; }
        public DecisionNode No { get; set; }

        public DecisionNode(string text, bool isQuestion)
        {
            Text = text;
            IsQuestion = isQuestion;
        }
    }
}
