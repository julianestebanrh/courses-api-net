using MasterNet.Application.Core;

namespace MasterNet.Application.Prices.GetPrices;

public class GetPricesRequest : PagingParameters
{
    public string? Name { get; set; }
}