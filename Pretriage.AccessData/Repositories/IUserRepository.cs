using Pretriage.Entitis.Model;

namespace Pretriage.AccessData.Repositories
{
    public interface IUserRepository
    {
        void Add(string login, string password);
        void Delete(User userR);
        bool ValidateUser(string login, string password);
    }
}