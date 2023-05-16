using System.ComponentModel.DataAnnotations;
using Authors.API.Controllers;
using Authors.API.Entities;
using MinimalApi.Endpoint;

namespace minimal.Authors;
public class Create : IEndpoint<IResult, CreateAuthorRequest>
{
    private ICourseLibraryRepository _authorRepository;
    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapPost("/authors", async (CreateAuthorRequest request, ICourseLibraryRepository authorRepository) =>
        {
            _authorRepository = authorRepository;
            return await HandleAsync(request);
        })
        .Produces<AuthorCreatedResponse>()
        .WithTags("AuthorsApi");
    }

    public async Task<IResult> HandleAsync(CreateAuthorRequest request)
    {
        _authorRepository.AddCourse(1, new Course(""));
        var response = new AuthorCreatedResponse(1, "");
        return Results.Created($"/authors/{1}", response);
    }
}

// NOTE: Minimal APIs don't support model validation in version 6
public record CreateAuthorRequest([Required] string Name, string TwitterAlias);
public record AuthorCreatedResponse(int Id, string Name);

