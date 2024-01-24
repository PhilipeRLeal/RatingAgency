using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace RatingAgency.Validators.ControllerValidators
{
    /// <summary>
    /// Class responsible for validating any POST request. If invalid, then an 400 erro is thrown back to 
    /// the front-end
    /// </summary>
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Method == "POST" && !context.ModelState.IsValid)
                context.Result = new BadRequestObjectResult(context.ModelState);
            
        }
    }
}