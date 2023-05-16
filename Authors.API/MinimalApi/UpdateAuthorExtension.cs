using Authors.API.Entities;
using Authors.API.Models;
using Authors.API.Controllers;
using Swashbuckle.AspNetCore.Annotations;

public static class UpdateAuthorExtension
{
    // use a static extension method to register endpoints
    // reference: http://www.binaryintellect.net/articles/f3dcbb45-fa8b-4e12-b284-f0cd2e5b2dcf.aspx
    public static void RegisterAuthorUpdateEndpoint(this WebApplication app)
    {
        app.MapPut("/authors/{id}",
        [SwaggerOperation(Summary = "Updates an author.", Description = "Updates an author, which must exist, otherwise NotFound is returned.")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(404, "Not Found")]
        async (ICourseLibraryRepository repo, int id, AuthorDto updatedAuthor) =>
        {
            if (await repo.GetAuthorAsync(id) is Author author)
            {
                author.FirstName = updatedAuthor.Name;
                repo.UpdateCourse(new Course(""));
                return Results.Ok();
            }
            else return Results.NotFound();
        })
        .WithName("UpdateAuthor")
        .WithTags("AuthorsApi");
    }
}

