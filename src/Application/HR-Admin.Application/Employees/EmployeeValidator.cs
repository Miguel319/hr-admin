using Admin_HR.Domain.Entities;
using FluentValidation;

namespace HR_Admin.Application.Employees
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("The first name is mandatory.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("The last name is mandatory.");
            RuleFor(x => x.Salary).NotEmpty().WithMessage("The salary is mandatory.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("The phone number is mandatory.");
            RuleFor(x => x.AddressLine1).NotEmpty().WithMessage("The address is mandatory.");
            RuleFor(x => x.City).NotEmpty().WithMessage("The city is mandatory.");
            RuleFor(x => x.ZipCode).NotEmpty().WithMessage("The zip code is mandatory.");
            RuleFor(x => x.State).NotEmpty().WithMessage("The state is mandatory.");
        }
    }
}