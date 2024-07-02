using FluentValidation;
using MediatR;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace TechnicalTest.API.Commands.NumericReader
{
    public class NumericReaderCommand : IRequest<string>
    {
        public long? Number { get; set; }
        public NumericReaderCommand() { }

        public class NumericReaderCommandValidator : AbstractValidator<NumericReaderCommand>
        {
            public NumericReaderCommandValidator()
            {
                RuleFor(x => x.Number).NotNull()
                    .WithMessage("El campo Number no puede ser nulo.");

                RuleFor(x => x.Number).GreaterThanOrEqualTo(0)
                    .WithMessage("El número debe ser mayor o igual a 0.");

                RuleFor(x => x.Number).LessThanOrEqualTo(999999999999)
                    .WithMessage("El número debe ser menor o igual a 999.999.999.999.");
            }
        }
    }
}
