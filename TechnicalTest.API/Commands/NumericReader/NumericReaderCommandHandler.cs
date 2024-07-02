using MediatR;
using TechnicalTest.API.Errors;

namespace TechnicalTest.API.Commands.NumericReader
{
    public class NumericReaderCommandHandler : IRequestHandler<NumericReaderCommand, string>
    {

        public NumericReaderCommandHandler()
        {
        }

        public Task<string> Handle(NumericReaderCommand request, CancellationToken cancellationToken)
        {
            if (request.Number == null)
            {
                throw new EmptyException("El campo 'Number' no puede ser 'Null'");
            }
            else
            {
                if (request.Number.GetType() != typeof(long))
                {
                    throw new TypeException("El valor de 'Number' debe ser un entero.");
                }
                long number = (long)request.Number;
                string response = NumberToText(number);

                return Task.FromResult(response);
            }

        }

        static string NumberToText(long number)
        {
            if (number == 0)
                return "cero";

            if (number < 0)
                return "menos " + NumberToText(Math.Abs(number));

            return ConvertToText(number).Trim();
        }

        static string ConvertToText(long number)
        {
            string[] units = { "", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve" };
            string[] teens = { "diez", "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve" };
            string[] tens = { "", "", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };
            string[] hundreds = { "", "ciento", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };

            if (number < 10)
                return units[number];

            if (number < 20)
                return teens[number - 10];

            if (number < 100)
            {
                if (number == 20)
                    return "veinte";
                if (number < 30)
                    return "veinti" + units[number % 10];
                if (number % 10 == 0)
                    return tens[number / 10];
                return tens[number / 10] + " y " + units[number % 10];
            }

            if (number < 1000)
            {
                if (number == 100)
                    return "cien";
                return hundreds[number / 100] + " " + ConvertToText(number % 100);
            }

            if (number < 1000000)
            {
                if (number == 1000)
                    return "mil";
                if (number < 2000)
                    return "mil " + ConvertToText(number % 1000);
                if (number % 1000 == 0)
                    return ConvertToText(number / 1000) + " mil";
                return ConvertToText(number / 1000) + " mil " + ConvertToText(number % 1000);
            }

            if (number < 1000000000)
            {
                if (number == 1000000)
                    return "un millón";
                if (number < 2000000)
                    return "un millón " + ConvertToText(number % 1000000);
                if (number % 1000000 == 0)
                    return ConvertToText(number / 1000000) + " millones";
                return ConvertToText(number / 1000000) + " millones " + ConvertToText(number % 1000000);
            }

            if (number < 1000000000000)
            {
                if (number == 1000000000)
                    return "mil millones";
                if (number < 2000000000)
                    return "mil millones " + ConvertToText(number % 1000000000);
                if (number % 1000000000 == 0)
                    return ConvertToText(number / 1000000000) + " mil millones";
                return ConvertToText(number / 1000000000) + " mil millones " + ConvertToText(number % 1000000000);
            }

            if (number < 1000000000000000)
            {
                if (number == 1000000000000)
                    return "un billón";
                if (number < 2000000000000)
                    return "un billón " + ConvertToText(number % 1000000000000);
                if (number % 1000000000000 == 0)
                    return ConvertToText(number / 1000000000000) + " billones";
                return ConvertToText(number / 1000000000000) + " billones " + ConvertToText(number % 1000000000000);
            }

            return "Número fuera de rango";
        }
    }
}
