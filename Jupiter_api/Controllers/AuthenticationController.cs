using Jupiter_api.Models.Authorization;
using Jupiter_api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jupiter_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJWTManagerRepository jwtManagerRepository;
        

        public AuthenticationController(IJWTManagerRepository jwtAuth)
        {
            this.jwtManagerRepository = jwtAuth;
           
        }   


        
        [HttpPost("authentication")]
        public IActionResult Authenticate([FromBody] Users userCredential)
        {
            var token = jwtManagerRepository.Authenticate(userCredential);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
