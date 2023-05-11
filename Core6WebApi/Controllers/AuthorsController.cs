using AutoMapper;
using Core6WebApi.Helpers;
using Core6WebApi.Models;
using Core6WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Core6WebApi.Controllers;


[ApiController]
[Route("api/authors")]
public class AuthorsController : ControllerBase
{
    private readonly ICourseLibraryRepository _courseLibraryRepository;
    private readonly IMapper _mapper;
    private readonly IPropertyMappingService _propertyMappingService;
    private readonly IPropertyCheckerService _propertyCheckerService;

    public AuthorsController(
        ICourseLibraryRepository courseLibraryRepository,
        IMapper mapper,
        IPropertyMappingService propertyMappingService,
        IPropertyCheckerService propertyCheckerService
        )
    {
        _courseLibraryRepository = courseLibraryRepository ?? throw new ArgumentNullException(nameof(courseLibraryRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _propertyMappingService = propertyMappingService ?? throw new ArgumentNullException(nameof(propertyMappingService));
        this._propertyCheckerService = propertyCheckerService;
    }


    [HttpGet(Name = "GetAuthors")]
    [HttpHead]
    public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors([FromQuery] AuthorsResourceParameters authorsResourceParameters)
    {
        if (!_propertyMappingService.ValidMappingExistsFor<AuthorDto, Entities.Author>(authorsResourceParameters.OrderBy))
        {
            return BadRequest();
        }

        // get authors from repo
        PagedList<Entities.Author>? authorsFromRepo = await _courseLibraryRepository.GetAuthorsAsync(authorsResourceParameters);

        var previousPageLink = authorsFromRepo.HasPrevious
            ? CreateAuthorsResourceUri(
                authorsResourceParameters,
                ResourceUriType.PreviousPage) : null;

        var nextPageLink = authorsFromRepo.HasNext
            ? CreateAuthorsResourceUri(
                authorsResourceParameters,
                ResourceUriType.NextPage) : null;

        var paginationMetadata = new
        {
            totalCount = authorsFromRepo.TotalCount,
            pageSize = authorsFromRepo.PageSize,
            currentPage = authorsFromRepo.CurrentPage,
            totalPages = authorsFromRepo.TotalPages,
            previousPageLink = previousPageLink,
            nextPageLink = nextPageLink
        };

        //Response.Headers.Add("X-Pagination",JsonSerializer.Serialize(paginationMetadata));

        // return them
        return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo)
             .ShapeData(authorsResourceParameters.Fields));

        // return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));
    }

    [HttpGet("{authorId}", Name = "GetAuthor")]
    public async Task<IActionResult> GetAuthor(Guid authorId, string? fields)
    {
        if (!_propertyCheckerService.TypeHasProperties<AuthorDto>(fields))
            return BadRequest();

        // get author from repo
        var authorFromRepo = await _courseLibraryRepository.GetAuthorAsync(authorId);

        // return author
        return Ok(_mapper.Map<AuthorDto>(authorFromRepo).ShapeData(fields));
    }

    public async Task<ActionResult<IEnumerable<AuthorDto>>> ForUnitTest(AuthorsResourceParameters authorsResourceParameters)
    {
        var authorFromRepo = await _courseLibraryRepository.GetAuthorsAsync(authorsResourceParameters);

        return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorFromRepo));
    }
    private string? CreateAuthorsResourceUri(AuthorsResourceParameters authorsResourceParameters, ResourceUriType type)
    {
        switch (type)
        {
            case ResourceUriType.PreviousPage:
                return Url.Link("GetAuthors",
                    new
                    {
                        orderBy = authorsResourceParameters.OrderBy,
                        pageNumber = authorsResourceParameters.PageNumber - 1,
                        pageSize = authorsResourceParameters.PageSize,
                        mainCategory = authorsResourceParameters.MainCategory,
                        searchQuery = authorsResourceParameters.SearchQuery
                    });
            case ResourceUriType.NextPage:
                return Url.Link("GetAuthors",
                    new
                    {
                        orderBy = authorsResourceParameters.OrderBy,
                        pageNumber = authorsResourceParameters.PageNumber + 1,
                        pageSize = authorsResourceParameters.PageSize,
                        mainCategory = authorsResourceParameters.MainCategory,
                        searchQuery = authorsResourceParameters.SearchQuery
                    });
            default:
                return Url.Link("GetAuthors",
                    new
                    {
                        orderBy = authorsResourceParameters.OrderBy,
                        pageNumber = authorsResourceParameters.PageNumber,
                        pageSize = authorsResourceParameters.PageSize,
                        mainCategory = authorsResourceParameters.MainCategory,
                        searchQuery = authorsResourceParameters.SearchQuery
                    });
        }
    }


}

