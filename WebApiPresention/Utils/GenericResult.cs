namespace WebApiPresention.DTO
{
    public class GenericResult<T> 
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public static GenericResult<T> Success(T data ,string message)
        {
            return new GenericResult<T>
            {
                IsSuccess = true,
                Data = data,
                Message = message
            };
        }

        public static GenericResult<T> Failure(string message, int statusCode)
        {
            return new GenericResult<T>
            {
                IsSuccess = false,
                Message = message,
                StatusCode = statusCode
            };
        }
    }
}
