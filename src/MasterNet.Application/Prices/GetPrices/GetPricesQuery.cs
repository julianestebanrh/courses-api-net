using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MasterNet.Application.Core;
using MasterNet.Domain;
using MasterNet.Persistence;
using MediatR;

namespace MasterNet.Application.Prices.GetPrices;

public class GetPricesQuery
{
    public record GetPricesQueryRequest : IRequest<Result<Pagination<PriceResponse>>>
    {
        public GetPricesRequest? PricesRequest;
    }

    internal class GetPricesQueryHandler : IRequestHandler<GetPricesQueryRequest, Result<Pagination<PriceResponse>>>
    {

        private readonly IMapper _mapper;
        private readonly MasterNetDbContext _context;

        public GetPricesQueryHandler(IMapper mapper, MasterNetDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<Pagination<PriceResponse>>> Handle(GetPricesQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Price> queryable = _context.Prices!;

            var predicate = ExpressionBuilder.New<Price>();
            if (!string.IsNullOrEmpty(request.PricesRequest!.Name))
            {
                predicate = predicate.And(x => x.Name!.Contains(request.PricesRequest!.Name));
            }

            if (!string.IsNullOrEmpty(request.PricesRequest!.OrderBy))
            {
                Expression<Func<Price, object>> orderBySelector =
                    request.PricesRequest.OrderBy.ToLower() switch
                    {
                        "name" => price => price.Name!,
                        _ => price => price!.Name!
                    };

                bool orderBy = request.PricesRequest.OrderAsc.HasValue
                  ? request.PricesRequest.OrderAsc.Value
                  : true;

                queryable = orderBy
                    ? queryable.OrderBy(orderBySelector)
                    : queryable.OrderByDescending(orderBySelector);

            }

            queryable = queryable.Where(predicate);

            var pricesQuery = queryable
                .ProjectTo<PriceResponse>(_mapper.ConfigurationProvider).AsQueryable();

            var response = await Pagination<PriceResponse>.CreateAsync(
                pricesQuery, request.PricesRequest.PageNumber, request.PricesRequest.PageSize);

            return Result<Pagination<PriceResponse>>.Success(response);
        }
    }
}

public record PriceResponse(Guid? Id, string? Name, decimal? Amount, decimal? Promotion)
{
    public PriceResponse() : this(null, null, null, null)
    {
    }
}