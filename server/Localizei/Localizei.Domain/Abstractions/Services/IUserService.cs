using System.Collections;
using System.Threading.Tasks;

namespace Localizei.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable> GetAll();
    }
}