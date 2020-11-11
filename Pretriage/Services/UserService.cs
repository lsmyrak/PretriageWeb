using Pretriage.AccessData.Repositories;

namespace Pretriage.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool UserValidator(string username, string password) =>
             _userRepository.ValidateUser(username, password);
    }

}
