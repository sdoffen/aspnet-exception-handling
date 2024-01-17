using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandlingDemo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ExceptionController
{
    /// <summary>
    /// This endpoint throws an exception.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet]    
    public IActionResult Get()
    {
        throw new NotImplementedException();
    }
}
