using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Jupiter_api.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Jupiter_api.Models.Authorization;
using System.Security.Principal;

namespace Jupiter_api.Repository
{

    public class AuthenticationBase 
    {

        public Users Authenticate(LoginUser userCredential)
        {

            //getting user's data from the userName
            var user = DemoUsers.UsersRecords.FirstOrDefault(u => u.UserName == userCredential.UserName);

            //if user is null then no user is found of given username

            if (user != null)
                if (VerifyPsswordHashes(user, userCredential.Password))
                {
                    return user;
                }

            return null;


        }

        private bool VerifyPsswordHashes(Users user, string password)
        {
            var result = DemoUsers.pw.VerifyHashedPassword(user.UserName, user.HashedPassword, password);
            return result == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success;

        }


        public static string GetCurrentUserId(IIdentity i)
        {
            var identity = i as ClaimsIdentity;

            if (identity != null)
            {
                var id =
                    identity.Claims.FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier)?.Value;

                return id;
            }
            return null;

        }
    }
}