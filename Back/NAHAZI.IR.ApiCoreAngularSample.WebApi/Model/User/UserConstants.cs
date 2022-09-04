using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAHAZI.IR.ApiCoreAngularSample.WebApi.Model.User
{
    public class UserConstants
    {
        public static List<UserModel> Users = new()
        {
            new UserModel(){
                UserName = "admin",
                Email = "admin@site.com",
                GivenName = "ahmad",
                Password ="admin110",
                Role="admin",
                Surname="ad"
            },
            new UserModel(){
                UserName = "user",
                Email = "user@site.com",
                GivenName = "faezeh",
                Password ="admin110",
                Role="User",
                Surname="us"
            }
        };
    }
}
