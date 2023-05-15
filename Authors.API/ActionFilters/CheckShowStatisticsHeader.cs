using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Authors.API.ActionFilters
{
    public class CheckShowStatisticsHeader : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // if no ShowStatistics return badRequest
            if (!context.HttpContext.Request.Headers.ContainsKey("ShowStatistics"))
                context.Result = new BadRequestResult();

            // if ShowStatistics is false return badRequest
            if (!bool.TryParse(context.HttpContext.Request.Headers["ShowStatistics"].ToString(), out bool showStatisticsValue))
                context.Result = new BadRequestResult();

            if (!showStatisticsValue)
                context.Result = new BadRequestResult();
        }
    }
}

/*
how to use filters
        [HttpGet]
        [CheckShowStatisticsHeader]
        public ActionResult<StatisticsDto> GetStatistics()

*/ 