using AutoMapper;
using Authors.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Books.API.Filters;

public class AuthorResultFilter : ActionFilterAttribute
{
    private readonly IMapper _mapper;

    public AuthorResultFilter(IMapper mapper)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var resultFromAction = context.Result as ObjectResult;
        if (resultFromAction?.Value == null || resultFromAction.StatusCode < 200 || resultFromAction.StatusCode >= 300)
        {
            await next();
            return;
        }

        resultFromAction.Value = _mapper.Map<AuthorDto>(resultFromAction.Value);

        await next();
    }
    public async Task OnResultExecutionAsync1(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var resultFromAction = context.Result as ObjectResult;
        if (resultFromAction?.Value == null || resultFromAction.StatusCode < 200 || resultFromAction.StatusCode >= 300)
        {
            await next();
            return;
        }

        resultFromAction.Value = _mapper.Map<AuthorDto>(resultFromAction.Value);

        await next();
    }
}
