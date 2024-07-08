using System.Net;
using FluxoCaixa.Application.Objects.Requests;
using FluxoCaixa.Application.Objects.Responses;
using FluxoCaixa.Application.UserCases.Users;
using FluxoCaixa.Infra.Settings;
using FluxoCaixa.WebApi.Setup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FluxoCaixa.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUsersService usersService, IOptions<AppSettings> appSettings) : ApiController
{
    [HttpPost("[action]/{request}", Name = "autenticar-usuario")]
    [ProducesResponseType(typeof(AuthenticateResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Authenticate(AuthenticateRequest request)
    {
        var response = await usersService.AuthenticateUser(request.Username, request.Password);

        if (response is null)
            return CustomResponse((int)HttpStatusCode.NotFound, false);

        var token = JwtProvider.GenerateJwtToken(response.Id, appSettings.Value);

        response.Token = token;

        return CustomResponse((int)HttpStatusCode.OK, true, response);
    }

    [Authorize]
    [HttpGet("[action]", Name = "listar-usuarios")]
    [ProducesResponseType(typeof(List<AuthenticateResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult> GetUsers()
    {
        var response = await usersService.GetAll();

        if (response is null || response.Count == 0)
            return CustomResponse((int)HttpStatusCode.NotFound, false);

        return CustomResponse((int)HttpStatusCode.OK, true, response);
    }
}
