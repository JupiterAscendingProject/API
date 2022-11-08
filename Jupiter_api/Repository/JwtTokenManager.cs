using Jupiter_api.Models.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Jupiter_api.Repository
{
    public class JwtTokenManager
    {
        private IConfiguration configuration;

        public JwtTokenManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GenerateToken(Users user)
        {

            var SecKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
            var Credentials = new SigningCredentials(SecKey, SecurityAlgorithms.HmacSha256);

            var Claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                new Claim(ClaimTypes.GivenName, user.UserName),
                new Claim(ClaimTypes.Role, user.Role),

            };

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"],
                claims: Claims,
                signingCredentials: Credentials,
                expires: DateTime.Now.AddHours(2) //token expiration is set to 2 hours 
                );

            //return token
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
