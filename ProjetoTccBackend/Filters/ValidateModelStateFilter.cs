using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjetoTccBackend.Models;

namespace ProjetoTccBackend.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ValidateModelStateFilter : Attribute, IActionFilter
    {

        private static List<FormError> ListModelErrors(ActionContext context)
        {
            List<FormError> errors = context.ModelState
                .Where(x => x.Value?.Errors.Count > 0)
                .SelectMany(x => x.Value!.Errors.Select(e => new FormError(x.Key, e.ErrorMessage)))
                .ToList<FormError>();

            return errors;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                List<FormError> errors = ListModelErrors(context);

                var result = new
                {
                    errors = errors
                };

                context.Result = new BadRequestObjectResult(result);
                return;
            }
            return;
        }
    }
}
