//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc.Controllers;
//using Microsoft.Extensions.Logging;
//using Symposium.Enums;
//using Symposium.Helpers.Config;
//using Symposium.Helpers.System;
//using Symposium.Models.Config;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Threading.Tasks;

//namespace Synposium.WebApi.Pipeline.Middlewares
//{
//    /// <summary>
//    /// Set the proper DBInfoModel (from Stores.xml). 
//    /// DBInfoModel is saved into UserInfoModel which is accessed throw out the request.
//    /// </summary>
//    public class SetStoreDBMiddleware
//    {
//        private readonly ILogger<SetStoreDBMiddleware> logger;
//        private readonly SystemInfoHelper systemInfoHelper;
//        private readonly StoreDBHelper usersToDatabasesHelper;

//        private readonly RequestDelegate next;

//        public SetStoreDBMiddleware(RequestDelegate next, SystemInfoHelper systemInfoHelper, StoreDBHelper usersToDatabasesHelper, ILogger<SetStoreDBMiddleware> logger)
//        {
//            this.next = next;
//            this.logger = logger;
//            this.systemInfoHelper = systemInfoHelper;
//            this.usersToDatabasesHelper = usersToDatabasesHelper;
//        }


//        public async Task Invoke(HttpContext context, UserInfoModel userInfoModel)
//        {

//            try
//            {
//                DBInfoModel dbmodel= GetDBInfo(context);
//                if (dbmodel == null)
//                {
//                    await ReturnErrorResponse(context);
//                }
            
//            }catch(Exception ex)
//            {
//                logger.LogError(ex.ToString());
//                await ReturnErrorResponse(context);
//            }

//            await next(context);
//        }




//        /// <summary>
//        /// Get DBInfo from Header or Query parameter or the default
//        /// </summary>
//        /// <param name="context">Http Context</param>
//        /// <returns>DBInfoModel</returns>
//        protected DBInfoModel GetDBInfo(HttpContext context)
//        {
           
//            //1. Get Store from Header
//            var authHeader = context.Request.Headers["StoreId"];
//            string storeId= authHeader.FirstOrDefault();
//            DBInfoModel dbmodel = null;
//            if (!string.IsNullOrWhiteSpace(storeId))
//            {
//                dbmodel= usersToDatabasesHelper.GetStore(Guid.Parse(storeId));
//            }

//            //2. Get store from query parameter
//            if (dbmodel == null)
//            {
//                storeId = context.Request.Query["StoreId"].ToString();
//                if (!string.IsNullOrWhiteSpace(storeId))
//                {
//                    dbmodel = usersToDatabasesHelper.GetStore(Guid.Parse(storeId));
//                }
//            }

//           // if (ExcludeValidation(context)) return new DBInfoModel();

//            //3. get Default DBInfo 
//            if (dbmodel == null)
//            {
//                dbmodel = usersToDatabasesHelper.GetDefaultStore();
//            }
//            return dbmodel;
//         }
       


//    private async Task ReturnErrorResponse(HttpContext context)
//    {
//        context.Response.ContentType = "application/json";
//        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
//        await context.Response.StartAsync();
//    }


//        private bool ExcludeValidation(HttpContext context)
//        {
//            var controllerActionDescriptor = context
//        .GetEndpoint()
//        .Metadata
//        .GetMetadata<ControllerActionDescriptor>();

//            var controllerName = controllerActionDescriptor.ControllerName;
//            var actionName = controllerActionDescriptor.ActionName;

//            if (controllerName == "HomeController")
//                return true;
//            else
//                return false;
//        }

//    //private string getAuthorizationHeader(HttpContext context)
//    //    {
//    //        var authHeader = context.Request.Headers["Authorization"];
//    //        if (!string.IsNullOrWhiteSpace(authHeader.ToString()))
//    //        {
//    //            var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);
//    //            if (authHeaderVal.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && authHeaderVal.Parameter != null)
//    //            {
//    //                return authHeaderVal.Parameter;
//    //            }
//    //        }
//    //        return null;
//    //    }

//    //    /// <summary>
//    //    /// set the DBInfoModel for the Request
//    //    /// </summary>
//    //    private void setDBInfoModel(UserInfoModel userInfoModel, HttpContext context)
//    //    {
//    //       //// if (systemInfoHelper.ApiMode == ApiModeEnum.DAServer)
//    //       // {
//    //       //     userInfoModel.DBInfoModel = systemInfoHelper.DAStore;
//    //       // }
//    //       // else
//    //       // {
//    //       //     if (!string.IsNullOrWhiteSpace(userInfoModel.Username) && !string.IsNullOrWhiteSpace(userInfoModel.Password))
//    //       //     {
//    //       //         userInfoModel.DBInfoModel = usersToDatabasesHelper.GetStoreByUser_Password(userInfoModel.Username, userInfoModel.Password);
//    //       //     }
//    //       //     if (userInfoModel.DBInfoModel == null)
//    //       //     {
//    //       //         string storeid = context.Request.Query["storeid"].ToString();
//    //       //         if (!string.IsNullOrWhiteSpace(storeid))
//    //       //         {
//    //       //             userInfoModel.DBInfoModel = usersToDatabasesHelper.GetStoreById(Guid.Parse(storeid));
//    //       //         }
//    //       //     }
//    //       // }
//    //       // if (userInfoModel.DBInfoModel == null) throw new Exception("Unable to set proper DBInfoModel");
//    //    }

//    //    /// <summary>
//    //    /// set Header's username, password or Header's AuthToken
//    //    /// </summary>
//    //    private void setUsersParams(UserInfoModel userInfoModel, string header)
//    //    {
//    //        var encoding = Encoding.GetEncoding("iso-8859-1");
//    //        header = encoding.GetString(Convert.FromBase64String(header));
//    //        if (header.EndsWith(":")) header = header.Replace(":", "");
//    //        int separator = header.IndexOf(':');

//    //        if (separator >= 0)
//    //        {
//    //            userInfoModel.Username = header.Substring(0, separator);
//    //            userInfoModel.Password = header.Substring(separator + 1);
//    //        }
//    //        else
//    //        {
//    //            userInfoModel.AuthToken = header;
//    //        }
//    //    }
//    }
//}
