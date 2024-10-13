using MasterNet.Application.Core;

namespace MasterNet.Application.Instructors.GetInstructors;

public class GetInstructorsRequest : PagingParameters
{
    public string? Names { get; set; }
    public string? Surnames { get; set; }
}