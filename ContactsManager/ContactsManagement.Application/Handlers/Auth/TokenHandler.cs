using ContactsManagement.Application.DTOs.Auth;
using ContactsManagement.Application.Interfaces.Auth;
using ContactsManagement.Application.Interfaces.User.ValidateUser;
using ContactsManagement.Domain.Repositories.User;
using ContactsManagement.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagement.Application.Handlers.Auth
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IValidateUserHandler _validateUserHandler;
        private readonly JwtSettings _jwtSettings;

        public TokenHandler(IValidateUserHandler userHandler, IOptions<JwtSettings> jwtSettings)
        {
            _validateUserHandler = userHandler;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<LoginResponse> HandleAsync(LoginRequest request)
        {
            var response = new LoginResponse();
            var user = await _validateUserHandler.HandleAsync(request);

            if (user is null)
            {
                response.Success = false;
                response.Token = string.Empty;
            }
            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityKey = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
                var tokenProperties = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, nameof(user.UserType))
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(securityKey),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenProperties);

                response.Success = true;
                response.Token = tokenHandler.WriteToken(token);
            }

            return response;
        }
    }
}
