using AutoMapper;
using Core6WebApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace Core6WebApi.Controllers;

[ApiController]
[Route("api/authors/{authorId}/courses")]
public class CoursesController : ControllerBase
{
    private readonly ICourseLibraryRepository _courseLibraryRepository;
    private readonly IMapper _mapper;

    public CoursesController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
    {
        _courseLibraryRepository = courseLibraryRepository ?? throw new ArgumentNullException(nameof(courseLibraryRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    [HttpPatch("{courseId}")]
    public async Task<IActionResult> PartiallyUpdateCourseForAuthor(Guid authorId, Guid courseId, JsonPatchDocument<CourseForUpdateDto> patchDocument)
    {

        var courseForAuthorFromRepo = await _courseLibraryRepository
            .GetCourseAsync(authorId, courseId);

        if (courseForAuthorFromRepo == null)
        {
            var courseDto = new CourseForUpdateDto();
            patchDocument.ApplyTo(courseDto, ModelState);

            if (!TryValidateModel(courseDto))
            {
                return ValidationProblem(ModelState);
            }

            var courseToAdd = _mapper.Map<Entities.Course>(courseDto);
            courseToAdd.Id = courseId;

            _courseLibraryRepository.AddCourse(authorId, courseToAdd);
            await _courseLibraryRepository.SaveAsync();

            var courseToReturn = _mapper.Map<CourseDto>(courseToAdd);
            return CreatedAtRoute("GetCourseForAuthor",
                new { authorId, courseId = courseToReturn.Id },
                courseToReturn);
        }

        var courseToPatch = _mapper.Map<CourseForUpdateDto>(
            courseForAuthorFromRepo);
        patchDocument.ApplyTo(courseToPatch, ModelState);

        if (!TryValidateModel(courseToPatch))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(courseToPatch, courseForAuthorFromRepo);

        _courseLibraryRepository.UpdateCourse(courseForAuthorFromRepo);

        await _courseLibraryRepository.SaveAsync();

        return NoContent();
    }

    public override ActionResult ValidationProblem(
        [ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
    {
        var options = HttpContext.RequestServices
            .GetRequiredService<IOptions<ApiBehaviorOptions>>();

        return (ActionResult)options.Value
            .InvalidModelStateResponseFactory(ControllerContext);
    }

}