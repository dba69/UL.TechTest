using FluentValidation;

namespace UL.TestTest.Services.Factorial.Validator
{
    public class CalculateFactorialValidator : AbstractValidator<CalculateFactorialRequest>
    {
        public CalculateFactorialValidator()
        {
            RuleFor(x => x.InputInteger).GreaterThan(0);
            RuleFor(x => x.InputInteger).LessThanOrEqualTo(10000);
        }
    }
}
