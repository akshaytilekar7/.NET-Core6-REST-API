using Authors.API.DbContexts;
using Authors.API.Entities;
using Authors.API.Helpers;
using Authors.API.Models;
using Authors.API.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Authors.API.Controllers;

public class CourseLibraryRepository : ICourseLibraryRepository
{
    private readonly CourseLibraryContext _context;
    private readonly IPropertyMappingService _propertyMappingService;
    private readonly IHttpClientFactory _httpClientFactory;

    public CourseLibraryRepository(CourseLibraryContext context, IPropertyMappingService propertyMappingService, IHttpClientFactory httpClientFactory)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _propertyMappingService = propertyMappingService ?? throw new ArgumentNullException(nameof(propertyMappingService));
        _httpClientFactory = httpClientFactory;
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

    public async Task<Models.External.AuthorCoverDto?> GetAuthorCoverAsync(string id)
    {
        var httpClient = _httpClientFactory.CreateClient();

        var response = await httpClient.GetAsync($"http://localhost:52644/api/authorcovers/{id}");
        if (response.IsSuccessStatusCode)
        {
            return JsonSerializer.Deserialize<Models.External.AuthorCoverDto>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true, });
        }

        return null;
    }

    public async Task<IEnumerable<Models.External.AuthorCoverDto>> GetAuthorCoversProcessOneByOneAsync(int bookId, CancellationToken cancellationToken)
    {
        var httpClient = _httpClientFactory.CreateClient();
        var bookCovers = new List<Models.External.AuthorCoverDto>();

        // create a list of fake bookcovers
        var bookCoverUrls = new[]
        {
                $"http://localhost:52644/api/authorcovers/{bookId}-dummycover1",
                // $"http://localhost:52644/api/authorcovers/{bookId}-dummycover2?returnFault=true",
                $"http://localhost:52644/api/authorcovers/{bookId}-dummycover3",
                $"http://localhost:52644/api/authorcovers/{bookId}-dummycover4",
                $"http://localhost:52644/api/authorcovers/{bookId}-dummycover5"
            };

        using (var cancellationTokenSource = new CancellationTokenSource())
        {
            using (var linkedCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationTokenSource.Token, cancellationToken))
            {
                // fire tasks & process them one by one
                foreach (var bookCoverUrl in bookCoverUrls)
                {
                    var response = await httpClient.GetAsync(bookCoverUrl, linkedCancellationTokenSource.Token);
                    if (response.IsSuccessStatusCode)
                    {
                        var bookCover = JsonSerializer.Deserialize<Models.External.AuthorCoverDto>(
                            await response.Content
                            .ReadAsStringAsync(linkedCancellationTokenSource.Token),
                            new JsonSerializerOptions { PropertyNameCaseInsensitive = true, });

                        if (bookCover != null)
                            bookCovers.Add(bookCover);
                    }
                    else
                        cancellationTokenSource.Cancel();
                }
            }
        }
        return bookCovers;
    }

    public async Task<IEnumerable<Models.External.AuthorCoverDto>> GetAuthorCoversProcessAfterWaitForAllAsync(int bookId)
    {
        var httpClient = _httpClientFactory.CreateClient();
        var bookCovers = new List<Models.External.AuthorCoverDto>();

        // create a list of fake bookcovers
        var bookCoverUrls = new[]
        {
                $"http://localhost:52644/api/authorcovers/{bookId}-dummycover1",
                $"http://localhost:52644/api/authorcovers/{bookId}-dummycover2",
                $"http://localhost:52644/api/authorcovers/{bookId}-dummycover3",
                $"http://localhost:52644/api/authorcovers/{bookId}-dummycover4",
                $"http://localhost:52644/api/authorcovers/{bookId}-dummycover5"
            };

        var bookCoverTasks = new List<Task<HttpResponseMessage>>();
        foreach (var bookCoverUrl in bookCoverUrls)
            bookCoverTasks.Add(httpClient.GetAsync(bookCoverUrl));

        // wait for all tasks to be completed
        var bookCoverTasksResults = await Task.WhenAll(bookCoverTasks);

        // run through the results in reverse order 
        foreach (var bookCoverTaskResult in bookCoverTasksResults.Reverse())
        {
            var bookCover = JsonSerializer.Deserialize<Models.External.AuthorCoverDto>(
                await bookCoverTaskResult.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true, });

            if (bookCover != null)
                bookCovers.Add(bookCover);
        }
        return bookCovers;
    }

    public async Task<bool> SaveAsync()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }

}

