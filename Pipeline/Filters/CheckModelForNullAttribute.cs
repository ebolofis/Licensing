using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Synposium.WebApi.Pipeline.Filters
{
    /// <summary>
    /// Action Filter that checks the action arguments to find out whether any of them has been passed as null. 
    /// If that’s true, you reject the request with a 400 response
    /// 
    /// In order for the Actions to be validated, must be decorated with the attribute: [CheckModelForNull]
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class CheckModelForNullAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            var args = new Dictionary<string, object>(actionContext.ActionArguments);
            if (args.ContainsValue(null))
            {
                actionContext.Result = new BadRequestObjectResult("Object is null");
            }
        }
    }
}