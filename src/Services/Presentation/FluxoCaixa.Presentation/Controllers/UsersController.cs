using FluxoCaixa.Application.Objects.Requests;
using FluxoCaixa.Application.Objects.Responses;
using FluxoCaixa.Application.UserCases.Users;
using FluxoCaixa.Infra.Settings;
using FluxoCaixa.WebApi.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;

namespace FluxoCaixa.WebApi.Controllers;

public class UsersController(IUsersService usersService, IOptions<AppSettings> appSettings) : ApiController
{
    [HttpPost("adicionar-usuario")]
    [ProducesResponseType(typeof(UserResponse), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Authorize]
    public async Task<ActionResult> AddUser([FromBody] AuthenticateRequest request)
    {
        var response = await usersService.AddUser(request);

        if (response is null)
            return CustomResponse((int)HttpStatusCode.BadRequest, false);

        return CustomResponse((int)HttpStatusCode.Created, true, response);
    }

    [HttpPost("autenticar-usuario")]
    [ProducesResponseType(typeof(AuthenticateResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Authenticate(AuthenticateRequest request)
    {
        var response = await usersService.AuthenticateUser(request.Username, request.Password);

        if (response is null)
            return CustomResponse((int)HttpStatusCode.BadRequest, false);

        var token = JwtProvider.GenerateJwtToken(response.Id.ToString(), appSettings.Value);

        response.Token = token;

        return CustomResponse((int)HttpStatusCode.OK, true, response);
    }

    [HttpGet("listar-usuarios")]
    [ProducesResponseType(typeof(List<AuthenticateResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [Authorize]
    public async Task<ActionResult> GetUsers()
    {
        var response = await usersService.GetAll();

        if (response is null || !response.Any())
            return CustomResponse((int)HttpStatusCode.NotFound, false);

        return CustomResponse((int)HttpStatusCode.OK, true, response);
    }
}
