namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "You have made a bad request!",
                401 => "Not authorized!",
                403 => "Only administrators are allowed to do this!",
                404 => "The resource was not found!",
                500 => "Internal server error!",
                _ => null
            };
        }
    }
}