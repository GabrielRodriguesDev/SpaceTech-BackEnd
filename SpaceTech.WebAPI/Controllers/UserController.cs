using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpaceTech.Domain.Commands.User;
using SpaceTech.Domain.Enums;
using SpaceTech.Domain.Interfaces.Repository;
using SpaceTech.Domain.Interfaces.Services;
using SpaceTech.Domain.Models;
using SpaceTech.Domain.Queries;
using SpaceTech.Domain.Queries.Params;
using SpaceTech.Domain.Queries.Result;
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

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Get([FromServices] IUserRepository repository, [FromRoute] Guid id, CancellationToken cancellationToken)
    {
        ErrorCatalogHelper.SettingCatalogedError(HttpContext, ErrorCatalog.GetUser);

        var tsc = new TaskCompletionSource<IActionResult>();
        var searchFormParams = new SearchFormParams();
        searchFormParams.Id = id;
        searchFormParams.TableName = "User";
        searchFormParams.ReturnFields = BaseQueries.ExtractReturnFieldsForQuery<UserFormQueryResult>();
        var result = repository.FormSearch(searchFormParams);
        tsc.SetResult(new JsonResult(result)
        {
            StatusCode = 200
        });

        return await tsc.Task;
    }

    [HttpPost]
    [Route("Search")]
    public async Task<IActionResult> Search([FromServices] IUserRepository repository, [FromBody] SearchParams searchParams, CancellationToken cancellationToken)
    {
        ErrorCatalogHelper.SettingCatalogedError(HttpContext, ErrorCatalog.SearchUser);

        var tsc = new TaskCompletionSource<IActionResult>();
        searchParams.TableName = "User";
        BaseQueries.ExtractReturnFieldsForSearch<UserListResult>(searchParams);
        var result = repository.Search(searchParams);
        var totalizer = repository.Totalizer(searchParams);
        var response = new PaginatedAnswerModel<IEnumerable<UserListResult>>(searchParams.Take, searchParams.Skip, totalizer, result);
        tsc.SetResult(new JsonResult(response)
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
        ErrorCatalogHelper.SettingCatalogedError(HttpContext, ErrorCatalog.DeleteUser);

        var tsc = new TaskCompletionSource<IActionResult>();
        var result = service.Delete(id, cancellationToken);
        tsc.SetResult(new JsonResult(result)
        {
            StatusCode = 200
        });

        return await tsc.Task;
    }
}

