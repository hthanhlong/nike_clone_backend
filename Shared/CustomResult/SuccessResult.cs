namespace nike_clone_backend.Shared.CustomResult
{

    public class SuccessResult(string message, object? data)
    {

        public string Message { get; set; } = message;
        public string ErrorCodeSystem { get; set; } = "00000";
        public bool IsError { get; set; } = false;
        public object? Data { get; set; } = data;
    }
}