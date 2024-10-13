using FluentValidation;
using MasterNet.Application.Core;
using MasterNet.Application.Interfaces;
using MasterNet.Domain;
using MasterNet.Persistence;
using MediatR;

namespace MasterNet.Application.Courses.CreateCourse;

public class CreateCourseCommand
{
    public record CreateCourseCommandRequest(CreateCourseRequest createCourseRequest) : IRequest<Result<Guid>>, ICommandBase;

    public class CreateCourseCommandRequestValidator : AbstractValidator<CreateCourseCommandRequest>
    {
        public CreateCourseCommandRequestValidator()
        {
            RuleFor(x => x.createCourseRequest).SetValidator(new CreateCourseValidator());
        }
    }

    internal class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommandRequest, Result<Guid>>
    {
        private readonly MasterNetDbContext _context;
        private readonly ICloudinaryService _cloudinartService;

        public CreateCourseCommandHandler(MasterNetDbContext context, ICloudinaryService cloudinaryService)
        {
            _context = context;
            _cloudinartService = cloudinaryService;
        }

        public async Task<Result<Guid>> Handle(CreateCourseCommandRequest request, CancellationToken cancellationToken)
        {
            var courseId = Guid.NewGuid();
            var course = new Course
            {
                Id = courseId,
                Title = request.createCourseRequest.Title,
                Description = request.createCourseRequest.Description,
                PublicationDate = request.createCourseRequest.PublicationDate
            };

            if (request.createCourseRequest.Photography is not null)
            {
                var uploadResult = await _cloudinartService
                    .UploadFileAsync(request.createCourseRequest.Photography);

                var photography = new Photography
                {
                    Id = Guid.NewGuid(),
                    PublicId = uploadResult.PublicId,
                    Url = uploadResult.Url,
                    CourseId = courseId
                };

                course.Photographies = new List<Photography> { photography };
            }


            if (request.createCourseRequest.InstructorId is not null)
            {
                var instructor = _context.Instructors!
                    .FirstOrDefault(x => x.Id == request.createCourseRequest.InstructorId);

                if (instructor is null)
                {
                    return Result<Guid>.Failure("Instructor not found");
                }

                course.Instructors = [instructor];
            }

            if (request.createCourseRequest.PriceId is not null)
            {
                var price = _context.Prices!
                    .FirstOrDefault(x => x.Id == request.createCourseRequest.PriceId);

                if (price is null)
                {
                    return Result<Guid>.Failure("Price not found");
                }

                course.Prices = [price];
            }

            _context.Add(course);
            var response = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (!response)
                return Result<Guid>.Failure("Course could not be inserted");

            return Result<Guid>.Success(course.Id);
        }
    }
}