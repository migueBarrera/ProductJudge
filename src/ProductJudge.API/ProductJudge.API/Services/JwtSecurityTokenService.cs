using ProductJudge.API.Helpers;
using ProductJudge.API.Repository.Tables;
using System.Security.Claims;

namespace ProductJudge.API.Services;

public class JwtSecurityTokenService
{
    private readonly string jwtToken = "\"M�&%dfdfsev/*t*K-N9oZ,�--7ws$YAM1`�Ua-A]*=Cg.42}5^Qx/x&xq@-!),9A;KvssIrg:56%rfgR~s";

    private const int EXPIRES_DAYS_TOKEN = 1;
    private const int EXPIRES_DAYS_REFRESH_TOKEN = 31;

    public JwtSecurityTokenService()
    {
    }

    public string BuildToken(
        UserTable client)
    {
        return BuildToken(
            new[]
            {
                new Claim(ClaimTypes.Email, client.Email),
                new Claim(ClaimTypes.NameIdentifier, client.Id.ToString()),
            });
    }

    public string BuildRefreshToken(
         UserTable client)
    {
        return BuildRefreshToken(
            new[]
            {
                new Claim(ClaimTypes.Email, client.Email),
                new Claim(ClaimTypes.NameIdentifier, client.Id.ToString()),
            });
    }

    private string BuildToken(
        IEnumerable<Claim> claims)
    {
        return JwtSecurityTokenHelper.BuildToken(jwtToken, claims, EXPIRES_DAYS_TOKEN);
    }

    private string BuildRefreshToken(
        IEnumerable<Claim> claims)
    {
        return JwtSecurityTokenHelper.BuildToken(jwtToken, claims, EXPIRES_DAYS_REFRESH_TOKEN);
    }
}
