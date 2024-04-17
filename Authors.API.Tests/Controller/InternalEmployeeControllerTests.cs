using AutoMapper;
using Authors.API.Controllers;
using Authors.API.Entities;
using Authors.API.Helpers;
using Authors.API.Models;
using Authors.API.Profiles;
using Authors.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagement.Test
{
    public class InternalEmployeeControllerTests
    {
        private AuthorsController _authorController;

        [Fact]
        public async Task GetInternalEmployees_GetAction_ReturnsOkObjectResultWithCorrectAmountOfInternalEmployees()
        {
            // Arrange
            var list = new List<Author>() {
                new Author("Megan", "Jones", "Horror") { Id = int.Parse("bfdd0acd-d314-48d5-a7ad-0e94dfdd9155") },
                new Author("Akshay", "Tilekar", "Sci Fi") { Id = int.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e") }
            };

            var input = new AuthorsResourceParameters();
            var _courseLibraryRepositoryMock = new Mock<ICourseLibraryRepository>();
            var _propertyMappingService = new Mock<IPropertyMappingService>();
            var _propertyCheckerService = new Mock<IPropertyCheckerService>();

            var returnList = new PagedList<Author>(list, 1, 1, 10);

            _courseLibraryRepositoryMock.Setup(m => m.GetAuthorsAsync(input)).ReturnsAsync(returnList);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<Author, AuthorDto>(It.IsAny<Author>())).Returns(new AuthorDto());

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<AuthorsProfile>());
            var mapper = new Mapper(mapperConfiguration);

            var _demoController = new DemoController(_courseLibraryRepositoryMock.Object, mapper, _propertyMappingService.Object, _propertyCheckerService.Object);

            // Act
            ActionResult<IEnumerable<AuthorDto>>? result = await _demoController.ForUnitTest("timepass", input, "a");

            // Assert

            // VERIFYING ACTIONRESULT TYPE
            var actionResult = Assert.IsType<ActionResult<IEnumerable<AuthorDto>>>(result);

            // VERIFYING MODEL TYPE
            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);

            // VERIFYING MODEL CONTENT
            var dtos = Assert.IsAssignableFrom<IEnumerable<AuthorDto>>(okObjectResult.Value);

            Assert.Equal(2, dtos.Count());
            var _responseAuthor = dtos.First();
            Assert.Equal(list.First().Id, _responseAuthor.Id);

        }
    }
}
