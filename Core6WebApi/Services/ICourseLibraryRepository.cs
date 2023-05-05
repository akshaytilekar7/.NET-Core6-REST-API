using Core6WebApi.Entities;
using Core6WebApi.Helpers;
using Core6WebApi.Models;

namespace Core6WebApi.Controllers;

public interface ICourseLibraryRepository
{
    Task<Course> GetCourseAsync(Guid authorId, Guid courseId);
    void AddCourse(Guid authorId, Course course);
    void UpdateCourse(Course course);
    Task<PagedList<Author>> GetAuthorsAsync(AuthorsResourceParameters authorsResourceParameters);
    Task<bool> SaveAsync();
}

