using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpaceTech.Domain.Commands.User;
using SpaceTech.Domain.Interfaces.Services;
using SpaceTech.Infrastructure.Errors;
using SpaceTech.WebAPI.Helpers;

namespace SpaceTech.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> Create([FromServices] IUserService service, [FromBody] CreateUserCommand body, CancellationToken cancellationToken)
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

