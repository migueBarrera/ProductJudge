namespace ProductJudge.API.Repository;

public static class RepositoryServices
{
    public static IServiceCollection UseFreyaRepository(this IServiceCollection serviceProvider)
    {

        serviceProvider.AddTransient<IUserRepository, UserRepository>();
        return serviceProvider;
    }
}
