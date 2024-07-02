using FluentValidation;
using MediatR;

namespace TechnicalTest.API.Commands.CreateToken
{
    public class CreateTokenCommand: IRequest<string>
    {

        public string? Name { get; set; }

        public string? Email { get; set; }
    }
}
