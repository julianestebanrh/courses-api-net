namespace MasterNet.Domain;

public class Instructor : BaseEntity
{
    public string? Names { get; set; }
    public string? Surnames { get; set; }
    public string? Degree { get; set; }
    public ICollection<Course>? Courses { get; set; }
    public ICollection<CourseInstructor>? CoursesInstructors { get; set; }
}