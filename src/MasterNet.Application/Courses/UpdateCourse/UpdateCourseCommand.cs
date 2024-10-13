using FluentValidation;
using MasterNet.Application.Core;
using MasterNet.Application.Interfaces;
using MasterNet.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterNet.Application.Courses.UpdateCourse;

public class UpdateCourseCommand
{

    public record UpdateCourseCommandRequest(UpdateCourseRequest UpdateCourseRequest, Guid? CourseId) : IRequest<Result<Guid>>, ICommandBase;

    internal class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommandRequest, Result<Guid>>
    {
        private readonly MasterNetDbContext _context;

        public UpdateCourseCommandHandler(MasterNetDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Guid>> Handle(UpdateCourseCommandRequest request, CancellationToken cancellationToken)
        {
            var courseId = request.CourseId;

            var course = await _context.Courses!.FirstOrDefaultAsync(x => x.Id == courseId);

            if (course is null)
            {
                return Result<Guid>.Failure("Course not found");
            }

            course.Description = request.UpdateCourseRequest.Description;
            course.Title = request.UpdateCourseRequest.Title;
            course.PublicationDate = request.UpdateCourseRequest.PublicationDate;

            _context.Entry(course).State = EntityState.Modified;
            var response = await _context.SaveChangesAsync() > 0;

            return response
                ? Result<Guid>.Success(course.Id)
                : Result<Guid>.Failure("Error updating course");
        }
    }

    public class UpdateCourseCommandRequestValidator : AbstractValidator<UpdateCourseCommandRequest>
    {
        public UpdateCourseCommandRequestValidator()
        {
            RuleFor(x => x.UpdateCourseRequest).SetValidator(new UpdateCourseValidator());
            RuleFor(x => x.CourseId).NotNull();
        }
    }
}