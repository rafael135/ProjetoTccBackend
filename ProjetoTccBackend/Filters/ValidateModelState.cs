using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProjetoTccBackend.Filters
{
    public class ValidateModelState : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.ModelState.IsValid is false)
            {
                var errors = context.ModelState.Keys
                    .SelectMany(key => context.ModelState[key]!.Errors.Select(x => new { field = key, error = x.ErrorMessage }))
                    .ToList();

                context.Result = new BadRequestObjectResult(new { errors });
            }
        }
    }
}
