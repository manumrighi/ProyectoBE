using Microsoft.AspNetCore.Mvc;
using ProyectoBE.Data.Repository.Interfaces;
using ProyectoBE.Models;
using System.Text;
using ProyectoBE.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace ProyectoBE.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;

        public AuthenticationController(IConfiguration config, IUserRepository userRepository)
        {
            _config = config;
            this._userRepository = userRepository;
        }

        [HttpPost("authenticate")]
        public ActionResult<string> Autenticar(AuthenticationRequestBody authenticationRequestBody)
        {
            var user = _userRepository.ValidateUser(authenticationRequestBody);

            if (user is null)
                return Unauthorized();

            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"]));
        }

    }
            
}
