using System;

namespace ComparisonGenerator.Models
{
    public class ComparisonModel
    {
        public ComparisonModel(string leftHandSide, string rightHandSide, string body)
        {
            LeftHandSide = leftHandSide ?? throw new ArgumentNullException(nameof(leftHandSide));
            RightHandSide = rightHandSide ?? throw new ArgumentNullException(nameof(rightHandSide));
            Body = body ?? throw new ArgumentNullException(nameof(body));
        }

        public string LeftHandSide { get; }
        public string RightHandSide { get; }
        public string Body { get; }
    }
}