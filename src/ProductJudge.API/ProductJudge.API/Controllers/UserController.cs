using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductJudge.Models.Responses.User;

namespace ProductJudge.API.Controllers;

[Route("api/[controller]/v1")]
[ApiController]
public class UserController : ControllerBase
{
    private UserControllerService userControllerService;

    public UserController(UserControllerService userControllerService)
    {
        this.userControllerService = userControllerService;
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("SignIn")]
    public Task<ActionResult<UserSignInResponse>> SignIn(UserSignInResponse request)
    {
        return userControllerService.SignIn(this, request);
    }
}
