using Authors.API.ActionFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using Xunit;

namespace Authors.API.Tests;
public class CheckShowStatisticsHeaderTests
{
    [Fact]
    public void OnActionExecuting_InvokeWithoutShowStatisticsHeader_ReturnsBadRequest()
    {
        // Arrange 
        var act = new CheckShowStatisticsHeader();

        var httpContext = new DefaultHttpContext();

        var actionContext = new ActionContext(httpContext, new(), new(), new());

        var actionExecutingContext = new ActionExecutingContext
            (actionContext, new List<IFilterMetadata>(),
            new Dictionary<string, object?>(),
            controller: null);

        // Act
        act.OnActionExecuting(actionExecutingContext);

        // Assert
        Assert.IsType<BadRequestResult>(actionExecutingContext.Result);
    }
}
