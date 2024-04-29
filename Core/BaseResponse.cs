using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Reformation.Core
{
    public class NotFoundResponse : NotFoundObjectResult
    {
        public NotFoundResponse(string message) : base(new
        {
            IsSuccess = false,
            Message = message,
            ErrorCode = 8948,
            Data = new { }
        })
        {
        }
    }

    public class SuccessResponse : OkObjectResult
    {
        public SuccessResponse(object? data, string message) : base(null)
        {
            Value = new
            {
                IsSuccess = true,
                Message = message,
                ErrorCode = 0,
                Data = data
            };
        }
    }


    public class BadRequestResponse : BadRequestObjectResult
    {
        public BadRequestResponse(string message) : base(new
        {
            IsSuccess = false,
            Message = message,
            ErrorCode = 4531,
            Data = new { }
        })
        {

        }
    }


}

