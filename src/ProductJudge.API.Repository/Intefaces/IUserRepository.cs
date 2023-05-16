namespace ProductJudge.API.Repository.Intefaces;

public interface IUserRepository
{
    Task<UserTable?> GetClientByEmail(string email);
}
