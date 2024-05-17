namespace nike_clone_backend.Shared.CustomResult
{
    public class FailResult
    {

        public string Message { get; set; }
        public int StatusCode { get; set; }
        public string ErrorCodeSystem { get; set; }
        public bool IsError { get; set; } = true;

        public FailResult(string message, int statusCode)
        {
            IsError = true;
            ErrorCodeSystem = "00001";
            Message = message;
            StatusCode = statusCode;
        }

    }

}

