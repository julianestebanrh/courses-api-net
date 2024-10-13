using AutoMapper;
using AutoMapper.QueryableExtensions;
using MasterNet.Application.Core;
using MasterNet.Application.Instructors.GetInstructors;
using MasterNet.Application.Photographs.GetPhotography;
using MasterNet.Application.Prices.GetPrices;
using MasterNet.Application.Ratings.GetRatings;
using MasterNet.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterNet.Application.Courses.GetCourse;

public class GetCourseQuery
{
    public record GetCourseQueryRequest : IRequest<Result<CourseResponse>>
    {
        public Guid Id { get; set; }
    }

    internal class GetCourseQueryHandler : IRequestHandler<GetCourseQueryRequest, Result<CourseResponse>>
    {
        private readonly IMapper _mapper;
        private readonly MasterNetDbContext _context;

        public GetCourseQueryHandler(IMapper mapper, MasterNetDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<CourseResponse>> Handle(GetCourseQueryRequest request, CancellationToken cancellationToken)
        {
            var course = await _context.Courses!.Where(x => x.Id == request.Id)
                            .Include(x => x.Instructors)
                            .Include(x => x.Prices)
                            .Include(x => x.Ratings)
                            .Include(x => x.Photographies)
                            .ProjectTo<CourseResponse>(_mapper.ConfigurationProvider)
                            .FirstOrDefaultAsync();

            return Result<CourseResponse>.Success(course!);
        }
    }
}

public record CourseResponse(
    Guid Id,
    string Title,
    string Description,
    string Image,
    DateTime? PublicationDate,
    List<InstructorResponse> Instructors,
    List<RatingResponse> Ratings,
    List<PriceResponse> Prices,
    List<PhotographyResponse> Photographies);