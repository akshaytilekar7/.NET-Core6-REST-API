using Core6WebApi.Entities;
using Core6WebApi.Helpers;
using Core6WebApi.Models;

namespace Core6WebApi.Controllers;

public interface ICourseLibraryRepository
{
    Task<Course> GetCourseAsync(int authorId, int courseId);
    void AddCourse(int authorId, Course course);
    void UpdateCourse(Course course);
    Task<PagedList<Author>> GetAuthorsAsync(AuthorsResourceParameters authorsResourceParameters);
    Task<Author> GetAuthorAsync(int authorId);
    IAsyncEnumerable<Author> GetAuthorsAsAsyncEnumerable();
    Task<IEnumerable<Author>> GetAuthorAsync();
    Task<bool> SaveAsync();
}

