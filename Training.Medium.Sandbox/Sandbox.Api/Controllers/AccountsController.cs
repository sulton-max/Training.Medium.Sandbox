using EntitiesSection.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Sandbox.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    #region Users

    [HttpGet("users")]
    public IActionResult GetUsers([FromServices] IUserService userService)
    {
        var result = userService.Get(user => true);
        return Ok(result);
    }

    #endregion
}