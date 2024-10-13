namespace MasterNet.Domain;

public class Photography : BaseEntity
{
    public string? PublicId { get; set; }
    public string? Url { get; set; }
    public Guid? CourseId { get; set; }
    public Course? Course { get; set; }
}