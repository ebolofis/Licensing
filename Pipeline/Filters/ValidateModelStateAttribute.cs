using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Synposium.WebApi.Pipeline.Filters
{
    /// <summary>
    /// Action Filter that obtain the associated ModelState dictionary.
    /// If the state of that object is invalid, it returns an error response with the status code 400 (bad request) back to the client, with the ModelState attached, 
    /// as it will contain the errors from your DataAnnotations or any other validation logic built around IValidateableObject.
    /// This response can then be inspected by the client and appropriate corrective actions taken on its side.
    /// 
    /// In order for the Actions to be validated, must be decorated with the attribute: [ValidateModelState]
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Result = new BadRequestObjectResult(actionContext.ModelState);
            }
        }
    }
}

