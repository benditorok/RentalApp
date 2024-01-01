using Microsoft.AspNetCore.Mvc;

namespace RentalApp.Endpoint.Controller;

[Route("api/[controller]")]
[ApiController]
public class StatusController : ControllerBase
{
    [Route("")]
    [HttpPost, HttpGet]
    public async Task<ActionResult> GetAsync()
    {
        return await Task.Run(Ok);
    }
}
