using Microsoft.AspNetCore.Http;

namespace MasterNet.Application.Courses.CreateCourse;

public class CreateCourseRequest
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? PublicationDate { get; set; }
    public IFormFile? Photography { get; set; }
    public Guid? InstructorId { get; set; }
    public Guid? PriceId { get; set; }
}