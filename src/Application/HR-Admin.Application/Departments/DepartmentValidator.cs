using Admin_HR.Domain.Entities;
using FluentValidation;

namespace HR_Admin.Application.Departments
{
    public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}