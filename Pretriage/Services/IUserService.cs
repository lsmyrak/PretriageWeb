namespace Pretriage.Services
{
    public interface IUserService
    {
        bool UserValidator(string username, string password);
    }
}