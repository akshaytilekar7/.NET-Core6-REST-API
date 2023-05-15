using AutoMapper;
using Authors.API.Entities;
using Authors.API.Helpers;
using Authors.API.Models;
using Authors.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authors.API.Controllers;


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
