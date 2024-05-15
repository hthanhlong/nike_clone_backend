namespace nike_clone_backend.Shared.ErrorsExceptions

{
    public class CustomException : Exception
    {
        public int StatusCode { get; private set; }

        public CustomException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public CustomException(string message, int statusCode, Exception inner) : base(message, inner)
        {
            StatusCode = statusCode;
        }
    }
}