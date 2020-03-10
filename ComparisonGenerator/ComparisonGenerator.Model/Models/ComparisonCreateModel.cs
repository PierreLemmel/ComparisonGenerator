using System;

namespace ComparisonGenerator.Models
{
    public class ComparisonCreateModel
    {
        public string LeftHandSide { get; set; }
        public string RightHandSide { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
    }
}