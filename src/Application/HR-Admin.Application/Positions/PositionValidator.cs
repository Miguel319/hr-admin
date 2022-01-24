using Admin_HR.Domain.Entities;
using FluentValidation;

namespace HR_Admin.Application.Positions
{
    public class PositionValidator : AbstractValidator<Position>
    {
        public PositionValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("The name is mandatory.");
            RuleFor(x => x.MinSalary).NotEmpty().WithMessage("The min salary is mandatory.");
            RuleFor(x => x.MaxSalary).NotEmpty().WithMessage("The max salary is mandatory.");
            
            RuleFor(x => x.MinSalary).LessThan(x => x.MaxSalary)
                .WithMessage("The min salary must be less than the max salary");
            
            RuleFor(x => x.MaxSalary).GreaterThan(x => x.MinSalary)
                .WithMessage("The max salary must be greater than the min salary.");
        } 
    }
}