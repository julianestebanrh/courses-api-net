using System.Linq.Expressions;
using System.Runtime.InteropServices;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MasterNet.Application.Core;
using MasterNet.Domain;
using MasterNet.Persistence;
using MediatR;

namespace MasterNet.Application.Instructors.GetInstructors;


public class GetInstructorsQuery
{
    public record GetInstructorsQueryRequest : IRequest<Result<Pagination<InstructorResponse>>>
    {
        public GetInstructorsRequest? InstructorsRequest { get; set; }
    }

    internal class GetInstructorsQueryHandler : IRequestHandler<GetInstructorsQueryRequest, Result<Pagination<InstructorResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly MasterNetDbContext _context;

        public GetInstructorsQueryHandler(IMapper mapper, MasterNetDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<Pagination<InstructorResponse>>> Handle(GetInstructorsQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Instructor> queryable = _context.Instructors!;

            var predicate = ExpressionBuilder.New<Instructor>();
            if (!string.IsNullOrEmpty(request.InstructorsRequest!.Names))
            {
                predicate = predicate.And(x => x.Names!.Contains(request.InstructorsRequest!.Names));
            }

            if (!string.IsNullOrEmpty(request.InstructorsRequest!.Surnames))
            {
                predicate = predicate.And(x => x.Surnames!.Contains(request.InstructorsRequest!.Surnames));
            }

            if (!string.IsNullOrEmpty(request.InstructorsRequest.OrderBy))
            {
                Expression<Func<Instructor, object>>? orderBySelector =
                    request.InstructorsRequest.OrderBy.ToLower() switch
                    {
                        "names" => instructor => instructor.Names!,
                        "surnames" => instructor => instructor.Surnames!,
                        _ => instructor => instructor.Names!
                    };

                bool orderBy = request.InstructorsRequest.OrderAsc.HasValue
                    ? request.InstructorsRequest.OrderAsc.Value
                    : true;

                queryable = orderBy
                    ? queryable.OrderBy(orderBySelector)
                    : queryable.OrderByDescending(orderBySelector);
            }

            queryable = queryable.Where(predicate);

            var instructorsQuery = queryable
                .ProjectTo<InstructorResponse>(_mapper.ConfigurationProvider).AsQueryable();

            var response = await Pagination<InstructorResponse>.CreateAsync(
                instructorsQuery, request.InstructorsRequest.PageNumber, request.InstructorsRequest.PageSize);

            return Result<Pagination<InstructorResponse>>.Success(response);
        }
    }
}

public record InstructorResponse(Guid? Id, string? Names, string? Surnames, string? Degree)
{
    public InstructorResponse() : this(null, null, null, null)
    {
    }
}