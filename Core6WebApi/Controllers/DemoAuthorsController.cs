using AutoMapper;
using Core6WebApi.Entities;
using Core6WebApi.Helpers;
using Core6WebApi.Models;
using Core6WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core6WebApi.Controllers;


[Route("api/demointernalemployees")]
public class DemoAuthorsController : ControllerBase
{
    private readonly ICourseLibraryRepository _courseLibraryRepository;
    private readonly IMapper _mapper;

    public DemoAuthorsController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
    {
        _courseLibraryRepository = courseLibraryRepository;
        _mapper = mapper;
    }

    [HttpPost]
    public ActionResult<Course> CreateCourse(Course course)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _courseLibraryRepository.AddCourse(int.Parse("bfdd0acd-d314-48d5-a7ad-0e94dfdd9155"), course);

        return CreatedAtAction("GetCourse", _mapper.Map<CourseDto>(course), new { Id = course.Id });
    }


    [HttpGet]
    [Authorize]
    public IActionResult GetProtectedCourse()
    {
        // depending on the role, redirect to another action
        if (User.IsInRole("Admin"))
            return RedirectToAction("GetInternalEmployees", "ProtectedInternalEmployees");

        return RedirectToAction("GetInternalEmployees", "InternalEmployees");
    }
}
