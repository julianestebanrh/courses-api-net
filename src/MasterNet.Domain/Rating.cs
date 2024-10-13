namespace MasterNet.Domain;

public class Rating : BaseEntity
{
    public string? Student { get; set; }
    public int Score { get; }
    public string? Commentary { get; set; }
    public Guid? CourseId { get; set; }
    public Course? Course { get; set; }
}