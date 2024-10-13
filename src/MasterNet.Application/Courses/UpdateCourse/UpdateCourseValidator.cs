using System.Security.Cryptography.X509Certificates;
using FluentValidation;

namespace MasterNet.Application.Courses.UpdateCourse;

public class UpdateCourseValidator : AbstractValidator<UpdateCourseRequest>
{
    public UpdateCourseValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.PublicationDate).Must(ValidateDateTime);
    }

    private bool ValidateDateTime(DateTime? date)
    {
        if (date == null) return false;
        if (date == default(DateTime)) return false;
        return true;
    }
}