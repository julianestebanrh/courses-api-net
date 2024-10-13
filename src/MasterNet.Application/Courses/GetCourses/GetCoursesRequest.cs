using MasterNet.Application.Core;

namespace MasterNet.Application.Courses.GetCourses;

public class GetCoursesRequest : PagingParameters
{
    public string? Title { get; set; }
    public string? Description { get; set; }
}