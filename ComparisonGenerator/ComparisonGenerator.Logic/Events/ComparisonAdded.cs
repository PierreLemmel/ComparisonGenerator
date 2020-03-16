using ComparisonGenerator.Infrastructure.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComparisonGenerator.Logic.Events
{
    public class ComparisonAdded : IEvent
    {
        public string LeftPart { get; set; }
        public string RightPart { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
    }
}
