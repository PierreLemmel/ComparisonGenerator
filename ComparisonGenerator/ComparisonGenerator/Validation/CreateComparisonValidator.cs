using ComparisonGenerator.Models;
using FluentValidation;

namespace ComparisonGenerator.Validation
{
    public class CreateComparisonValidator : AbstractValidator<ComparisonCreateModel>
    {
        public CreateComparisonValidator()
        {
            RuleFor(comp => comp.LeftHandSide).NotNull().MinimumLength(4);
            RuleFor(comp => comp.RightHandSide).NotNull().MinimumLength(4);
            RuleFor(comp => comp.Body).NotNull().MinimumLength(8);
            RuleFor(comp => comp.RightHandSide).NotNull().MinimumLength(4);
        }
    }
}
