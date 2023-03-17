using DotNetEnv;

namespace TotallyBiased.API.Authentication;

public class AuthConstants
{
    public const string ApiKeyHeaderName = "X-Api-Key";
    public string ApiKey;

    public AuthConstants()
    {
        Env.TraversePath().Load();
        ApiKey = Env.GetString("ADMIN_API_KEY");
    }
}