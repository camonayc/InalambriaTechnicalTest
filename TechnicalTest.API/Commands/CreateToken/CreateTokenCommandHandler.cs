using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechnicalTest.API.Errors;

namespace TechnicalTest.API.Commands.CreateToken
{
    public class CreateTokenCommandHandler : IRequestHandler<CreateTokenCommand, string>
    {
        private readonly IConfiguration _configuration;
        public CreateTokenCommandHandler(IConfiguration configuration) { 
            _configuration = configuration;
        }
        public Task<string> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            if (request.Name == null || request.Email == null)
            {
                throw new Exception(message: "Los campos 'Name' y 'Email 'no pueden ser Null.");
            }
            else
            {
                if (request.Name == "" || request.Email == "")
                {
                    throw new EmptyException("Los campos 'Name' y 'Email 'no pueden ser Empty.");
                }
                if (!request.Email.Contains('@'))
                {
                    throw new TypeException("El campo 'Email' no es valido.");
                }

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, request.Name),
                    new Claim(ClaimTypes.Email, request.Email),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:key").Value));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var securityTokens = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: creds);

                string token = new JwtSecurityTokenHandler().WriteToken(securityTokens);

                return Task.FromResult(token);
            }
        }
    }
}
