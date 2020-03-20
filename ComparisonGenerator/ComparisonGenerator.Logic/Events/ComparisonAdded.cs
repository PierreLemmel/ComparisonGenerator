using ComparisonGenerator.Infrastructure.Events;
using System;

namespace ComparisonGenerator.Logic.Events
{
    public class ComparisonAdded : IEvent
    {
        public ComparisonAdded(string leftPart, string rightPart, string body, string author)
        {
            LeftPart = leftPart ?? throw new ArgumentNullException(nameof(leftPart));
            RightPart = rightPart ?? throw new ArgumentNullException(nameof(rightPart));
            Body = body ?? throw new ArgumentNullException(nameof(body));
            Author = author ?? throw new ArgumentNullException(nameof(author));
        }

        public string LeftPart { get; }
        public string RightPart { get; }
        public string Body { get; }
        public string Author { get; }
    }
}
