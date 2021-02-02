using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPosLicense.Models;
using Dapper;
using System.Data.SqlClient;
using WebPosLicense.DTOs;
using Microsoft.Extensions.Logging;

namespace WebPosLicense.Helpers
{


    public class ValidateLoginUser
    {
        private readonly string ConStr;
        private LoginUser loginUser;

        public ValidateLoginUser(string conStr, LoginUser loginUser )
        {
            this.ConStr = conStr;
            this.loginUser = loginUser;
        }

        public void Validate()
        {
            var x = loginUser;
            loginUser.name = "hitadmin@hit.com.gr";
            loginUser.password = "6ae7c8475224064a688218935c04dd875edd569b5b1a8f14050f8e267a0c933d";

            using (SqlConnection db = new SqlConnection(this.ConStr))
            {
                string select = "SELECT * FROM Users AS us WHERE us.LoginName =@loginName and us.PasswordHash =@pass";
                try
                {
                    UserDTO res = db.Query<UserDTO>(select, new { loginName = loginUser.name, pass = loginUser.password }).FirstOrDefault();

                }
                catch (Exception ex)
                {
                    throw new Exception("Error Validating User");
                }

            }
        }
    }
}
