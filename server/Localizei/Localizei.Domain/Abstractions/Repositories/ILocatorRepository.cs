using Localizei.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Localizei.Domain.Repositories
{
    public interface ILocatorRepository
    {
        Task<List<Image>> GetAll();
        Task<Image> PostLocalizedPerson(Image image);
    }
}