using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace BE.Common.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var pars = context.ActionArguments.ToList();

            foreach (var par in pars)
            {
                if (par.GetType() == typeof(string))
                {
                    if (string.IsNullOrEmpty(par.ToString()))
                    {
                        context.Result = new BadRequestObjectResult($"{nameof(par)} is null");
                        return;
                    }
                }

                if (string.IsNullOrEmpty(par.Key))
                {
                    context.Result = new BadRequestObjectResult($"{nameof(par.Key)} is null");
                    return;
                }
            }

            if (!context.ModelState.IsValid)
            {
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }
        }
    }
}
