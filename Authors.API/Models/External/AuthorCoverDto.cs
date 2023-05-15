namespace Authors.API.Models.External;

public class AuthorCoverDto
{
    public string Id { get; set; }
    public byte[]? Content { get; set; }

    public AuthorCoverDto(string id, byte[]? content)
    {
        Id = id;
        Content = content;
    }
}