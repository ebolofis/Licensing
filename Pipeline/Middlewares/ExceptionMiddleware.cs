//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Logging;

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text.Json;
//using System.Threading.Tasks;

//namespace Symposium.WebApi.Pipeline.Middlewares
//{
//    public class ExceptionMiddleware
//    {
//        private readonly RequestDelegate _next;
//        private readonly ILogger<ExceptionMiddleware> logger;

//        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
//        {
//            this.logger = logger;
//            _next = next;
//        }

//        public async Task InvokeAsync(HttpContext httpContext)
//        {
//            try
//            {
//                await _next(httpContext);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(ex.ToString());
//                await HandleExceptionAsync(httpContext, ex);
//            }
//        }

//        private Task HandleExceptionAsync(HttpContext context, Exception ex)
//        {
//            context.Response.ContentType = "application/json";
//            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

//            return context.Response.WriteAsync(new ReturnErrorModel()
//            {
//                Message = ConstructErrorMessage(ex)
//            }.ToString()); 
//        }

//        private string ConstructErrorMessage(Exception ex)
//        {
//            if (ex.Message.StartsWith("A network-related or instance-specific error occurred while establishing a connection to SQL Server"))
//                return "Unable to connect with Database.";

//            return ex.Message;
//        }
//    }

   
//}
