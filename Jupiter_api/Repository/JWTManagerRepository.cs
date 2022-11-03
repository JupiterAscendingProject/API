using Jupiter_api.Models.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Jupiter_api.Repository
{
    public class JWTManagerRepository : IJWTManagerRepository
    {

        // Creating Dict for storing user login and pass temporary

        Dictionary<string, string> UsersRecords = new Dictionary<string, string>
                    {
                        { "user1","password1"},
                        { "user2","password2"},
                        { "user3","password3"},
                    };

        private readonly IConfiguration iconfiguration;

        public JWTManagerRepository(IConfiguration iconfiguration)
        {
            
            this.iconfiguration = iconfiguration;
        }

        public Tokens Authenticate(Users users)
        {
            /*
             if user id and pass are not available the we will return Null
             */

            if(!UsersRecords.Any(x => x.Key == users.Name && x.Value == users.Password))
            {
                return null;
            }

            // Else we generate JSON web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new Claim[]
                 {
                    new Claim(ClaimTypes.Name, users.Name)
                  }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };

        }

    }
    
}
