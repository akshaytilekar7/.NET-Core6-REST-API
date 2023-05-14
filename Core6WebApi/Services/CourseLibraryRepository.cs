using Core6WebApi.DbContexts;
using Core6WebApi.Entities;
using Core6WebApi.Helpers;
using Core6WebApi.Models;
using Core6WebApi.Services;
using Microsoft.EntityFrameworkCore;

namespace Core6WebApi.Controllers;

public class CourseLibraryRepository : ICourseLibraryRepository
{
    private readonly CourseLibraryContext _context;
    private readonly IPropertyMappingService _propertyMappingService;

    public CourseLibraryRepository(CourseLibraryContext context, IPropertyMappingService propertyMappingService)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _propertyMappingService = propertyMappingService ?? throw new ArgumentNullException(nameof(propertyMappingService));
    }

    public void AddCourse(int authorId, Course course)
    {
        if (authorId == 0)
        {
            throw new ArgumentNullException(nameof(authorId));
        }

        if (course == null)
        {
            throw new ArgumentNullException(nameof(course));
        }

        // always set the AuthorId to the passed-in authorId
        course.AuthorId = authorId;
        _context.Courses.Add(course);
    }

    public async Task<Course> GetCourseAsync(int authorId, int courseId)
    {
        if (authorId == 0)
        {
            throw new ArgumentNullException(nameof(authorId));
        }

        if (courseId == 0)
        {
            throw new ArgumentNullException(nameof(courseId));
        }

#pragma warning disable CS8603 // Possible null reference return.
        return await _context.Courses
          .Where(c => c.AuthorId == authorId && c.Id == courseId).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
    }

    public void UpdateCourse(Course course)
    {
        // no code in this implementation
    }

    public async Task<PagedList<Author>> GetAuthorsAsync(AuthorsResourceParameters authorsResourceParameters)
    {
        if (authorsResourceParameters == null)
        {
            throw new ArgumentNullException(nameof(authorsResourceParameters));
        }

        //if (string.IsNullOrWhiteSpace(authorsResourceParameters.MainCategory)
        //    && string.IsNullOrWhiteSpace(authorsResourceParameters.SearchQuery))
        //{
        //    return await GetAuthorsAsync();
        //}

        // collection to start from
        var collection = _context.Authors as IQueryable<Author>;

        if (!string.IsNullOrWhiteSpace(authorsResourceParameters.MainCategory))
        {
            var mainCategory = authorsResourceParameters.MainCategory.Trim();
            collection = collection.Where(a => a.MainCategory == mainCategory);
        }

        if (!string.IsNullOrWhiteSpace(authorsResourceParameters.SearchQuery))
        {
            var searchQuery = authorsResourceParameters.SearchQuery.Trim();
            collection = collection.Where(a => a.MainCategory.Contains(searchQuery) || a.FirstName.Contains(searchQuery) || a.LastName.Contains(searchQuery));
        }

        if (!string.IsNullOrWhiteSpace(authorsResourceParameters.OrderBy))
        {
            // get property mapping dictionary
            var authorPropertyMappingDictionary = _propertyMappingService.GetPropertyMapping<AuthorDto, Author>();
            collection = collection.ApplySort(authorsResourceParameters.OrderBy, authorPropertyMappingDictionary);
        }

        return await PagedList<Author>.CreateAsync(collection, authorsResourceParameters.PageNumber, authorsResourceParameters.PageSize);
    }

    public async Task<Author> GetAuthorAsync(int authorId)
    {
        if (authorId == 0)
        {
            throw new ArgumentNullException(nameof(authorId));
        }

#pragma warning disable CS8603 // Possible null reference return.
        return await _context.Authors.FirstOrDefaultAsync(a => a.Id == authorId);
#pragma warning restore CS8603 // Possible null reference return.
    }

    public async Task<IEnumerable<Author>> GetAuthorAsync()
    {
        return await _context.Authors
            .ToListAsync();
    }

    public IAsyncEnumerable<Author> GetAuthorsAsAsyncEnumerable()
    {
        return _context.Authors.AsAsyncEnumerable<Author>();
    }
    public async Task<bool> SaveAsync()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }

}

