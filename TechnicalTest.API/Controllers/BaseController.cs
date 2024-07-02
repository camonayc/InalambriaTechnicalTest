using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using TechnicalTest.API.Models;

namespace TechnicalTest.API.Controllers
{
    [ApiController]
    [Route("api/technical-test/v1/[Controller]")]
    public class BaseController : ControllerBase
    {

        protected ApiResponse SuccessResquest(object data)
        {
            var response = new ApiResponse()
            {
                StatusCode = 200,
                IsSuccess = true,
                Message = "Conversión exitosa",
                Data = data as string
            };
            return response;
        }

        protected ApiResponse ErrorRequest(int code,string errorMessage)
        {
            var response = new ApiResponse()
            {
                StatusCode = code,
                IsSuccess = false,
                Message = errorMessage,
                Data = null
            };
            return response;
        }

        protected ApiResponse InternalServerError(string errorMessage)
        {
            var response = new ApiResponse()
            {
                StatusCode = 500,
                IsSuccess = false,
                Message = errorMessage,
                Data = null
            };
            return response;
        }

    }
}
