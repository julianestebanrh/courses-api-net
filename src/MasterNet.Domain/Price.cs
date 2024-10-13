namespace MasterNet.Domain;

public class Price : BaseEntity
{
    public string? Name { get; set; }
    public decimal Amount { get; set; }
    public decimal Promotion { get; set; }
    public ICollection<Course>? Courses { get; set; }
    public ICollection<CoursePrice>? CoursePrices { get; set; }

}