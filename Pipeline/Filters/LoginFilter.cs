
using WebPosLicense.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Options;
using WebPosLicense.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HitServicesCore.Filters
{

    public class LoginFilter : IAuthorizationFilter
    {
        private readonly LoginUser loginUser;
        private readonly IOptions<MyConfiguration> config;
        private readonly ILogger<LoginFilter> logger;
        public LoginFilter(LoginUser _loginUser, IOptions<MyConfiguration> config, ILogger<LoginFilter> logger )
        {
            this.config = config;
            this.loginUser = _loginUser;
            this.logger = logger;
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {
            try
            {
                var z = context;
           //     context.Result = new RedirectToRouteResult
           //(new RouteValueDictionary(new
           //{
           //    action = "Index",
           //    controller = "Login"
           //}));
            }
            catch (Exception e)
            {

            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var x = 5;
            var y = context;
            string path = context.HttpContext.Request.Path.ToString();
            //if (loginsUsers.logins["isAdmin"] == true || loginsUsers.logins["isAdmin"] == false)
            //    return;
            //if (loginsUsers.logins["isAdmin"] == null)
            //{
            //    context.Result = new RedirectToRouteResult
            //       (new RouteValueDictionary(new
            //       {
            //           action = "Index",
            //           controller = "Login"
            //       }));
            //}
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            string connStr = config.Value.SqlConnection;
            logger.LogInformation("Initiating LoginUserValidation");
            ValidateLoginUser validator = new ValidateLoginUser(connStr,loginUser);
            validator.Validate();
            
        }


    }
}
