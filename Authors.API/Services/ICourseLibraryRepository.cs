﻿using Authors.API.Entities;
using Authors.API.Helpers;
using Authors.API.Models;

namespace Authors.API.Controllers;

public interface ICourseLibraryRepository
{
    Task<Course> GetCourseAsync(int authorId, int courseId);
    void AddCourse(int authorId, Course course);
    void UpdateCourse(Course course);
    Task<PagedList<Author>> GetAuthorsAsync(AuthorsResourceParameters authorsResourceParameters);
    Task<Author> GetAuthorAsync(int authorId);
    IAsyncEnumerable<Author> GetAuthorsAsAsyncEnumerable();
    Task<IEnumerable<Author>> GetAuthorAsync();
    Task<Models.External.AuthorCoverDto?> GetAuthorCoverAsync(string id);
    Task<IEnumerable<Models.External.AuthorCoverDto>> GetAuthorCoversProcessOneByOneAsync(int bookId, CancellationToken cancellationToken);
    Task<IEnumerable<Models.External.AuthorCoverDto>> GetAuthorCoversProcessAfterWaitForAllAsync(int bookId);
    Task<bool> SaveAsync();
}

