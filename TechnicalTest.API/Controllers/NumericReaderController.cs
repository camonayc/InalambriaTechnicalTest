using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using TechnicalTest.API.Models;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;
using TechnicalTest.API.Commands.NumericReader;
using System.ComponentModel.DataAnnotations;
using TechnicalTest.API.Errors;

namespace TechnicalTest.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NumericReaderController : BaseController
    {
        private readonly IMediator _mediator;

        public NumericReaderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Convierte un número entero a su equivalente en texto.
        /// </summary>
        /// <remarks>
        /// <para>Este método recibe un número entero y lo convierte a su representación textual.</para>
        /// <para>El número debe ser un entero sin comas ni puntos. Ejemplo de entrada válida: <code>1234567890</code></para>
        /// <para>Ejemplo de respuesta:</para>
        /// <pre>
        /// {
        ///   "statusCode": 200,
        ///   "isSuccess": true,
        ///   "message": "Conversión exitosa",
        ///   "data": "mil millones doscientos treinta y cuatro millones quinientos sesenta y siete mil ochocientos noventa"
        /// }
        /// </pre>
        /// </remarks>
        /// <param name="number">Objeto que contiene el número a convertir.</param>
        /// <returns>Retorna una respuesta con el número convertido a texto.</returns>
        /// <response code="200">Conversión exitosa.</response>
        /// <response code="400">Error en la solicitud. El número no es válido. El número es obligatorio.</response>
        /// <response code="422">El servidor comprende la solicitud, pero no puede procesarla debido a errores de sintaxis o semánticos.</response>
        /// <response code="500">Se produjo una excepción en el sistema que no se pudo manejar.</response>
        [HttpPost(Name = "GetNumberConvertToText")]
        [ProducesResponseType(type: typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(type: typeof(ApiResponse), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(type: typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ConvertNumberToText([FromBody] NumericReaderCommand number)
        {

            try
            {
                var result = await _mediator.Send(number);
                return Ok(SuccessResquest(result));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ErrorRequest(400,ex.Message));
            }
            catch (TypeException ex)
            {
                return BadRequest(ErrorRequest(422, ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(InternalServerError(ex.Message));
            }
        }

    }
}
