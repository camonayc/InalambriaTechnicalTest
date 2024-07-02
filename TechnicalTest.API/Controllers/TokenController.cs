using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using TechnicalTest.API.Commands.CreateToken;
using TechnicalTest.API.Errors;
using TechnicalTest.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechnicalTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : BaseController
    {
        private readonly IMediator _mediator;

        public TokenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Crea un JWT para autenticación.
        /// </summary>
        /// <remarks>
        /// <para>Este método recibe los datos del usuario (Nombre y Email) y genera un token de autorización.</para>
        /// <para>Los campos Name y Email no pueden ser nulos ni vacíos</para>
        /// <para>Ejemplo de respuesta:</para>
        /// <pre>
        /// {
        ///   "statusCode": 200,
        ///   "isSuccess": true,
        ///   "message": "Conversión exitosa",
        ///   "data": "JWT generado"
        /// }
        /// </pre>
        /// </remarks>
        /// <param name="userData">Objeto que contiene el nombre y email del usuario, para generar el token.</param>
        /// <returns>Retorna una respuesta con el token generado.</returns>
        /// <response code="200">Conversión exitosa.</response>
        /// <response code="400">Error en la solicitud. Los campo Name y Email son obligatorios. Los campos Name y Emial no pueden ser vacíos.</response>
        /// <response code="500">Se produjo una excepción en el sistema que no se pudo manejar.</response>
        [HttpPost(Name = "CreateToken")]
        [ProducesResponseType(type: typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(type: typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreateTokenCommand userData)
        {
            try
            {
                var result = await _mediator.Send(userData);
                return Ok(SuccessResquest(result));
            }

            catch (ValidationException ex)
            {
                return BadRequest(ErrorRequest(400, ex.Message));
            }
            catch (EmptyException ex)
            {
                return BadRequest(ErrorRequest(400, ex.Message));
            }
            catch (TypeException ex)
            {
                return BadRequest(ErrorRequest(400, ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(InternalServerError(ex.Message));
            }
                
        }
    }
}
