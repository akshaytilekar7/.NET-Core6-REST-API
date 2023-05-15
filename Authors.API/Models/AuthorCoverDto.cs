namespace Authors.API.Models;

public class AuthorCoverDto
{
    public string Id { get; set; }

    public AuthorCoverDto(string id)
    {
        Id = id;
    }

    //public byte[]? Content { get; set; }

    //public BookCoverDto(string id, byte[]? content)
    //{
    //    Id = id;
    //    Content = content;
    //}
}