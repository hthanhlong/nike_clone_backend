using Microsoft.AspNetCore.Mvc;
using nike_clone_backend.Shared.CustomResult;

namespace Nike_clone_Backend.Shared;

public class SuccessResponse : OkObjectResult
{
    public SuccessResponse(string message, object? data) : base(null)
    {
        Value = new SuccessResult(message, data);
    }
}