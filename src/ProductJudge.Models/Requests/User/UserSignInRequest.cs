namespace ProductJudge.Models.Requests.User;

public class UserSignInRequest
{
    public string Email { get; set; } = string.Empty;

    public string PushToken { get; set; } = string.Empty;
}
