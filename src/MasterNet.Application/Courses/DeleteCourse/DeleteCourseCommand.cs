using FluentValidation;
using MasterNet.Application.Core;
using MasterNet.Application.Interfaces;
using MasterNet.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterNet.Application.Courses.DeleteCourse;

public class DeleteCourseCommand
{
    public record DeleteCourseCommandRequest(Guid? CourseId) : IRequest<Result<Unit>>, ICommandBase;

    internal class DeleteCourseCommandHanlder : IRequestHandler<DeleteCourseCommandRequest, Result<Unit>>
    {
        private readonly MasterNetDbContext _context;

        public DeleteCourseCommandHanlder(MasterNetDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(DeleteCourseCommandRequest request, CancellationToken cancellationToken)
        {

            // Cargamos las relaciones para poder eliminar las relaciones 
            var course = await _context.Courses!
                .Include(x => x.Instructors)
                .Include(x => x.Prices)
                .Include(x => x.Ratings)
                .Include(x => x.Photographies)
                .FirstOrDefaultAsync(x => x.Id == request.CourseId);

            if (course is null)
            {
                return Result<Unit>.Failure("Course not found");
            }

            _context.Courses!.Remove(course);
            var response = await _context.SaveChangesAsync(cancellationToken) > 0;

            return response
                ? Result<Unit>.Success(Unit.Value)
                : Result<Unit>.Failure("Cannot delete course");
        }
    }


    public class DeleteCourseCommandRequestValidator : AbstractValidator<DeleteCourseCommandRequest>
    {

        public DeleteCourseCommandRequestValidator()
        {
            RuleFor(x => x.CourseId).NotNull();
        }
    }
}