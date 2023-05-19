using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpaceTech.Domain.Commands;
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
            CookieHelper.SetCookie(Response, token);
        }

        tsc.SetResult(new JsonResult(result)
        {
            StatusCode = 200
        });

        return await tsc.Task;
    }

    [HttpPost("Logout")]
    [AllowAnonymous]
    public async Task<IActionResult> Logout()
    {
        ErrorCatalogHelper.SettingCatalogedError(HttpContext, ErrorCatalog.Logout);
        var tsc = new TaskCompletionSource<IActionResult>();
        CookieHelper.ClearCookie(Response);
        tsc.SetResult(new JsonResult(new GenericCommandResult(true, "Logged out successfully."))
        {
            StatusCode = 200
        });
        return await tsc.Task;
    }


    [HttpPost("AccountVerification")]
    [AllowAnonymous]
    public async Task<IActionResult> AccountVerification([FromServices] IAuthenticationService authenticationService, [FromBody] AccountVerificationCommand body, CancellationToken cancellationToken)
    {
        ErrorCatalogHelper.SettingCatalogedError(HttpContext, ErrorCatalog.AccountVerification);
        var tsc = new TaskCompletionSource<IActionResult>();
        var result = authenticationService.AccountVerification(body, cancellationToken);
        CookieHelper.ClearCookie(Response);
        tsc.SetResult(new JsonResult(result)
        {
            StatusCode = 200
        });
        return await tsc.Task;
    }

    [HttpPost("ChangePassword")]
    [AllowAnonymous]
    public async Task<IActionResult> ChangePassword([FromServices] IAuthenticationService authenticationService, [FromBody] ChangePasswordCommand body, CancellationToken cancellationToken)
    {
        ErrorCatalogHelper.SettingCatalogedError(HttpContext, ErrorCatalog.ChangePassword);
        var tsc = new TaskCompletionSource<IActionResult>();
        var result = authenticationService.ChangePassword(body, cancellationToken);
        CookieHelper.ClearCookie(Response);
        tsc.SetResult(new JsonResult(result)
        {
            StatusCode = 200
        });
        return await tsc.Task;
    }
}