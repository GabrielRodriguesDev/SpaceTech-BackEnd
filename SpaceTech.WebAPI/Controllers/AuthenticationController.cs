using Microsoft.AspNetCore.Mvc;
using SpaceTech.Domain.Commands.Authentication;
using SpaceTech.Domain.Interfaces.Services;
using SpaceTech.Infrastructure.Errors;
using SpaceTech.WebAPI.Helpers;
using SpaceTech.WebAPI.Services;


namespace SpaceTech.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> Login([FromServices] IAuthenticationService service, [FromBody] LoginCommand body, CancellationToken cancellationToken)
    {
        ErrorCatalogHelper.SettingCatalogedError(HttpContext, ErrorCatalog.Login);

        var tsc = new TaskCompletionSource<IActionResult>();
        var result = service.Login(body, cancellationToken);
        if (result.Sucess)
        {
            var token = TokenService.GenerateJwtToken(HttpContext, result.Authenticated!);
            result.Authenticated!.Token = token;
        }

        tsc.SetResult(new JsonResult(result)
        {
            StatusCode = 200
        });

        return await tsc.Task;
    }
}