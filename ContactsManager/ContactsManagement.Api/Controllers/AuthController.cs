using ContactsManagement.Application.DTOs.Auth;
using ContactsManagement.Application.Interfaces.Auth;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ContactsManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenHandler _tokenHandler;

        public AuthController(ITokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetToken(LoginRequest request)
        {
            var generatedToken = await _tokenHandler.HandleAsync(request);

            if (generatedToken != null && generatedToken.Success && !string.IsNullOrEmpty(generatedToken.Token))
                return Ok(generatedToken);
            else
                return Unauthorized();
        }
    }
}