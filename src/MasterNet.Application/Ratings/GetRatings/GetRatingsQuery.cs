using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MasterNet.Application.Core;
using MasterNet.Domain;
using MasterNet.Persistence;
using MediatR;

namespace MasterNet.Application.Ratings.GetRatings;

public class GetRatingsQuery
{

    public record GetRatingsQueryRequest : IRequest<Result<Pagination<RatingResponse>>>
    {
        public GetRatingsRequest? RatingsRequest { get; set; }
    }

    internal class GetRatingsQueryHandler : IRequestHandler<GetRatingsQueryRequest, Result<Pagination<RatingResponse>>>
    {

        private readonly IMapper _mapper;
        private readonly MasterNetDbContext _context;

        public GetRatingsQueryHandler(IMapper mapper, MasterNetDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<Pagination<RatingResponse>>> Handle(GetRatingsQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Rating> queryable = _context.Ratings!;

            var predicate = ExpressionBuilder.New<Rating>();
            if (!string.IsNullOrEmpty(request.RatingsRequest!.Student))
            {
                predicate = predicate.And(x => x.Student!.Contains(request.RatingsRequest.Student));
            }

            if (request.RatingsRequest.CourseId is not null)
            {
                predicate = predicate.And(x => x.CourseId == request.RatingsRequest.CourseId);
            }

            if (!string.IsNullOrEmpty(request.RatingsRequest.OrderBy))
            {
                Expression<Func<Rating, object>>? orderBySelector =
                    request.RatingsRequest.OrderBy.ToLower() switch
                    {
                        "student" => rating => rating.Student!,
                        "course" => rating => rating.CourseId!,
                        _ => rating => rating.Student!
                    };

                bool orderBy = request.RatingsRequest.OrderAsc.HasValue
                    ? request.RatingsRequest.OrderAsc.Value
                    : true;

                queryable = orderBy
                    ? queryable.OrderBy(orderBySelector)
                    : queryable.OrderByDescending(orderBySelector);
            }

            queryable = queryable.Where(predicate);

            var instructorsQuery = queryable
                .ProjectTo<RatingResponse>(_mapper.ConfigurationProvider).AsQueryable();

            var response = await Pagination<RatingResponse>.CreateAsync(
                instructorsQuery, request.RatingsRequest.PageNumber, request.RatingsRequest.PageSize);

            return Result<Pagination<RatingResponse>>.Success(response);
        }
    }
}

public record RatingResponse(string? Student, int? Score, string? Commentary, string? Course)
{
    public RatingResponse() : this(null, null, null, null)
    {

    }
}