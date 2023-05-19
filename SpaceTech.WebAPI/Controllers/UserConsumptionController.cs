using Microsoft.AspNetCore.Mvc;
using SpaceTech.Domain.Commands.UserConsumption;
using SpaceTech.Domain.Interfaces.Services;
using SpaceTech.Infrastructure.Errors;
using SpaceTech.WebAPI.Helpers;

namespace SpaceTech.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserConsumptionController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> RegisteringConsumption([FromServices] IUserConsumptionService service, [FromBody] CreateUserConsumptionCommand body, CancellationToken cancellationToken)
    {
        ErrorCatalogHelper.SettingCatalogedError(HttpContext, ErrorCatalog.CreateUser);

        var tsc = new TaskCompletionSource<IActionResult>();
        var result = service.Create(body, cancellationToken);
        tsc.SetResult(new JsonResult(result)
        {
            StatusCode = 200
        });

        return await tsc.Task;
    }
}
