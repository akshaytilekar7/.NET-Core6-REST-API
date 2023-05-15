using AutoMapper;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Authors.API.Models;

namespace Books.API.Filters;

public class AuthorsResultFilter : IAsyncResultFilter
{
    private readonly IMapper _mapper;

    public AuthorsResultFilter(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task OnResultExecutionAsync(
        ResultExecutingContext context,
        ResultExecutionDelegate next)
    {
        var resultFromAction = context.Result as ObjectResult;
        if (resultFromAction?.Value == null || resultFromAction.StatusCode < 200 || resultFromAction.StatusCode >= 300)
        {
            await next();
            return;
        }

        resultFromAction.Value = _mapper.Map<IEnumerable<AuthorDto>>(resultFromAction.Value);

        await next();
    }
}

//to use this filter which have ctor DI
    //[AuthorsResultFilter] // cant pass ctor dependancy
    //[TypeFilter(typeof(AuthorsResultFilter))] // can pass ctor dependancy
    // 2n option Get Service via HttpContext
    //public void controllerMethodName()
    //{ 
         // body
    //}
