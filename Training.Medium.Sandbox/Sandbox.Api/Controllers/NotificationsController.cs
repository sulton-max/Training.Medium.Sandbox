using EntitiesSection.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Sandbox.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController: ControllerBase
    {
        [HttpGet("emails/templates")]
        public async ValueTask<IActionResult> GetEmailTemplates([FromServices]IEmailTemplateService emailTemplateService)
        {
            var result = emailTemplateService.Get(emailTemplate => true).ToList();
            await Task.Delay(10);
            return result.Any() ? Ok(result) : NotFound();
        }
    }
}
