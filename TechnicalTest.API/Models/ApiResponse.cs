namespace TechnicalTest.API.Models
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public string? Data { get; set; }
        public ApiResponse() { }
    }
}
