using Jupiter_api.Models.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Jupiter_api.Repository;

namespace Jupiter_api.Controllers
{
    // This controller is used for auth
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        //IConfiguration _configuration;
        AuthenticationBase _auth = new AuthenticationBase();
        JwtTokenManager _jwtTokenManager;

        public AuthenticationController(IConfiguration configuration)
        {
            //this._configuration = configuration;
            _jwtTokenManager = new JwtTokenManager(configuration);
        }


        //Login Api
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginUser user)
        {

            var CurrentUser = _auth.Authenticate(user);

            if (CurrentUser != null)
            {
                var token = _jwtTokenManager.GenerateToken(CurrentUser);
                return Ok(token);

            }
            return BadRequest("User not found");
        }

    }
}
