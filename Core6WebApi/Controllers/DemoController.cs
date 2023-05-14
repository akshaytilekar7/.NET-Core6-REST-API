using AutoMapper;
using Books.API.Filters;
using Core6WebApi.Helpers;
using Core6WebApi.Models;
using Core6WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Core6WebApi.Controllers;


[ApiController]
[Route("api/demo")]
public class DemoController : ControllerBase
{
    private readonly ICourseLibraryRepository _courseLibraryRepository;
    private readonly IMapper _mapper;
    private readonly IPropertyMappingService _propertyMappingService;
    private readonly IPropertyCheckerService _propertyCheckerService;

    public DemoController(
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

    [HttpGet(Name = "ForUnitTest")]
    public async Task<ActionResult<IEnumerable<AuthorDto>>> ForUnitTest(string name, AuthorsResourceParameters authorsResourceParameters, string name2)
    {
        var authorFromRepo = await _courseLibraryRepository.GetAuthorsAsync(authorsResourceParameters);

        return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorFromRepo));
    }

}
