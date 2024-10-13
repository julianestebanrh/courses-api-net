using MasterNet.Application.Core;

namespace MasterNet.Application.Ratings.GetRatings;

public class GetRatingsRequest : PagingParameters
{
    public string? Student { get; set; }
    public Guid? CourseId { get; set; }
}