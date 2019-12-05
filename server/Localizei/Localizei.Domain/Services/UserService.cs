using Localizei.Domain.Repositories;
using System.Collections;
using System.Threading.Tasks;

namespace Localizei.Domain.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(
            IUserRepository userRepository
            )
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable> GetAll()
        {
            return await _userRepository.GetAll();
        }
    }
}
