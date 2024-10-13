namespace MasterNet.Application.Photographs.GetPhotography;

public record PhotographyResponse(Guid? Id, string? Url, Guid? CourseId)
{
    public PhotographyResponse() : this(null, null, null)
    {

    }
}