namespace MasterNet.Domain;

public class Course : BaseEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? PublicationDate { get; set; }
    public ICollection<Rating>? Ratings { get; set; }
    public ICollection<Price>? Prices { get; set; }
    public ICollection<CoursePrice>? CoursePrices { get; set; }
    public ICollection<Instructor>? Instructors { get; set; }
    public ICollection<CourseInstructor>? CourseInstructors { get; }
    public ICollection<Photography>? Photographies { get; set; }

}