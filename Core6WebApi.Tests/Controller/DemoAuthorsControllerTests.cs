using AutoMapper;
using Core6WebApi.Controllers;
using Core6WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Security.Claims;
using Xunit;

namespace EmployeeManagement.Test;
public class DemoAuthorsControllerTests
{
    [Fact]
    public void TestModelErrors()
    {
        // Arrange
        var employeeServiceMock = new Mock<ICourseLibraryRepository>();
        var mapperMock = new Mock<IMapper>();
        var demoAuthorsController = new DemoAuthorsController(employeeServiceMock.Object, mapperMock.Object);

        var course = new Course("title");

        demoAuthorsController.ModelState.AddModelError("FirstName", "Required");

        // Act 
        var result = demoAuthorsController.CreateCourse(course);

        // Assert
        var actionResult = Assert.IsType<ActionResult<Course>>(result);

        var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);

        Assert.IsType<SerializableError>(badRequestResult.Value);
    }

    [Fact]
    public void TestModelErrorsIfModelIsCorrect()
    {
        // Arrange
        var employeeServiceMock = new Mock<ICourseLibraryRepository>();
        var mapperMock = new Mock<IMapper>();
        var demoAuthorsController = new DemoAuthorsController(employeeServiceMock.Object, mapperMock.Object);
        var course = new Course("title");

        // Act 
        var result = demoAuthorsController.CreateCourse(course);

        // Assert
        var actionResult = Assert.IsType<ActionResult<Course>>(result);
        Assert.IsType<CreatedAtActionResult>(actionResult.Result);
    }

    [Fact]
    public void HttpContext()
    {
        // Arrange
        var employeeServiceMock = new Mock<ICourseLibraryRepository>();
        var mapperMock = new Mock<IMapper>();

        var demoInternalEmployeesController = new DemoAuthorsController(employeeServiceMock.Object, mapperMock.Object);

        var userClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Karen"),
                new Claim(ClaimTypes.Role, "Admin")
            };

        var claimsIdentity = new ClaimsIdentity(userClaims, "UnitTest");
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        var httpContext = new DefaultHttpContext() { User = claimsPrincipal };

        demoInternalEmployeesController.ControllerContext = new ControllerContext() { HttpContext = httpContext };

        // Act
        var result = demoInternalEmployeesController.GetProtectedCourse();

        // Assert 
        Assert.IsAssignableFrom<IActionResult>(result);
        var redirectoToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("GetInternalEmployees", redirectoToActionResult.ActionName);
        Assert.Equal("ProtectedInternalEmployees", redirectoToActionResult.ControllerName);
    }

    [Fact]
    public void HttpContext_Mock()
    {
        // Arrange
        var employeeServiceMock = new Mock<ICourseLibraryRepository>();
        var mapperMock = new Mock<IMapper>();
        var demoInternalEmployeesController = new DemoAuthorsController(employeeServiceMock.Object, mapperMock.Object);

        var mockPrincipal = new Mock<ClaimsPrincipal>();
        mockPrincipal.Setup(x => x.IsInRole(It.Is<string>(s => s == "Admin"))).Returns(true);

        var httpContextMock = new Mock<HttpContext>();
        httpContextMock.Setup(c => c.User).Returns(mockPrincipal.Object);

        demoInternalEmployeesController.ControllerContext = new ControllerContext() { HttpContext = httpContextMock.Object };

        // Act
        var result = demoInternalEmployeesController.GetProtectedCourse();

        // Assert 
        Assert.IsAssignableFrom<IActionResult>(result);
        var redirectoToActionResult = Assert.IsType<RedirectToActionResult>(result);

        Assert.Equal("GetInternalEmployees", redirectoToActionResult.ActionName);
        Assert.Equal("ProtectedInternalEmployees", redirectoToActionResult.ControllerName);
    }
}
