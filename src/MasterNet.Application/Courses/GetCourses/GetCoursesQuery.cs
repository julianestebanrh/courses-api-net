using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MasterNet.Application.Core;
using MasterNet.Application.Courses.GetCourse;
using MasterNet.Domain;
using MasterNet.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterNet.Application.Courses.GetCourses;

public class GetCoursesQuery
{
    public record GetCoursesQueryRequest : IRequest<Result<Pagination<CourseResponse>>>
    {
        public GetCoursesRequest? CoursesRequest { get; set; }
    }

    internal class GetCoursesQueryHandler : IRequestHandler<GetCoursesQueryRequest, Result<Pagination<CourseResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly MasterNetDbContext _context;

        public GetCoursesQueryHandler(IMapper mapper, MasterNetDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<Pagination<CourseResponse>>> Handle(GetCoursesQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Course> queryable = _context.Courses!
                .Include(x => x.Instructors)
                .Include(x => x.Ratings)
                .Include(x => x.Prices)
                .Include(x => x.Photographies);

            var predicate = ExpressionBuilder.New<Course>();
            if (!string.IsNullOrEmpty(request.CoursesRequest!.Title))
            {
                predicate = predicate.And(x =>
                    x.Title!.ToLower().Contains(request.CoursesRequest.Title.ToLower()));
            }

            if (!string.IsNullOrEmpty(request.CoursesRequest!.Description))
            {
                predicate = predicate.And(x =>
                    x.Description!.ToLower().Contains(request.CoursesRequest.Description.ToLower()));
            }

            if (!string.IsNullOrEmpty(request.CoursesRequest!.OrderBy))
            {
                Expression<Func<Course, object>>? orderBySelector =
                    request.CoursesRequest.OrderBy!.ToLower() switch
                    {
                        "title" => course => course.Title!,
                        "description" => course => course.Description!,
                        _ => course => course.Title!,
                    };

                bool orderBy = request.CoursesRequest.OrderAsc.HasValue
                    ? request.CoursesRequest.OrderAsc.Value : true;

                queryable = orderBy
                    ? queryable.OrderBy(orderBySelector)
                    : queryable.OrderByDescending(orderBySelector);
            }

            queryable = queryable.Where(predicate);
            var coursesQuery = queryable.ProjectTo<CourseResponse>(_mapper.ConfigurationProvider).AsQueryable();

            var response = await Pagination<CourseResponse>.CreateAsync(
                coursesQuery, request.CoursesRequest.PageNumber, request.CoursesRequest.PageSize);

            return Result<Pagination<CourseResponse>>.Success(response);

        }
    }
}