namespace Authors.API.Models;

public class CourseDto
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }
}
