using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpaceTech.Domain.Commands.User;
using SpaceTech.Domain.Enums;
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

    [HttpPut]
    public async Task<IActionResult> Update([FromServices] IUserService service, [FromBody] UpdateUserCommand body, CancellationToken cancellationToken)
    {
        ErrorCatalogHelper.SettingCatalogedError(HttpContext, ErrorCatalog.UpdateUser);

        var tsc = new TaskCompletionSource<IActionResult>();
        var result = service.Update(body, cancellationToken);
        tsc.SetResult(new JsonResult(result)
        {
            StatusCode = 200
        });

        return await tsc.Task;
    }

    [HttpDelete]
    [Route("{id}")]
    [Authorize(Roles = nameof(UserType.Administrator))]
    public async Task<IActionResult> Delete([FromServices] IUserService service, [FromRoute] Guid id, CancellationToken cancellationToken)
    {
        ErrorCatalogHelper.SettingCatalogedError(HttpContext, ErrorCatalog.UpdateUser);

        var tsc = new TaskCompletionSource<IActionResult>();
        var result = service.Delete(id, cancellationToken);
        tsc.SetResult(new JsonResult(result)
        {
            StatusCode = 200
        });

        return await tsc.Task;
    }
}

