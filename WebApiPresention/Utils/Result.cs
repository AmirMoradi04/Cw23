using WebApiPresention.DTO;

namespace WebApiPresention.Utils
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public static Result Success()
        {
            return new Result
            {
                IsSuccess = true,
                Message = "Success"
            };
        }

        public static Result Failure(string message, int statusCode)
        {
            return new Result
            {
                IsSuccess = false,
                Message = message,
                StatusCode = statusCode
            };
        }
    }
}
