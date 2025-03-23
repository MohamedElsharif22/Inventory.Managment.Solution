
namespace Inventory.Managment.APIs.Errors
{
    public class ApiResponse(int statusCode, string? message = null)
    {
        public int StatusCode { get; set; } = statusCode;
        public string? Message { get; set; } = message ?? GetDefaultMessageForCurruntStatusCode(statusCode);

        private static string? GetDefaultMessageForCurruntStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "bad request.",
                401 => "you are not authorized! :(",
                404 => "Not Found",
                500 => "error has occured from server",
                _ => null
            };
        }
    }
}
