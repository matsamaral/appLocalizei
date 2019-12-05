using System.Collections;
using System.Threading.Tasks;

namespace Localizei.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable> GetAll();
    }
}