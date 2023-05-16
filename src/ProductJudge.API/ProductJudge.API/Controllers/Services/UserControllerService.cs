using Microsoft.AspNetCore.Mvc;
using ProductJudge.API.Helpers;
using ProductJudge.API.Repository.Intefaces;
using ProductJudge.API.Services;
using ProductJudge.Models.Requests.User;
using ProductJudge.Models.Responses.User;

namespace ProductJudge.API.Controllers.Services;

public class UserControllerService
{
    private readonly JwtSecurityTokenService jwtSecurityToken;
    private readonly IUserRepository userRepository;

    public UserControllerService(
        JwtSecurityTokenService jwtSecurityToken, 
        IUserRepository userRepository)
    {
        this.jwtSecurityToken = jwtSecurityToken;
        this.userRepository = userRepository;
    }

    public async Task<ActionResult<UserSignInResponse>> SignIn(ControllerBase controller, UserSignInRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Email))
        {
            return controller.NotFound();
        }

        var user = await userRepository.GetClientByEmail(request.Email);

        if (user == null)
        {
            return controller.NotFound();
        }

        var response = new UserSignInResponse()
        {
            Token = jwtSecurityToken.BuildToken(user),
            RefreshToken = jwtSecurityToken.BuildRefreshToken(user),
        };

        return controller.Ok(response);
    }
}
