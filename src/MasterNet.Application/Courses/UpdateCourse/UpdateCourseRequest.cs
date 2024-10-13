namespace MasterNet.Application.Courses.UpdateCourse;


public class UpdateCourseRequest
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? PublicationDate { get; set; }
}