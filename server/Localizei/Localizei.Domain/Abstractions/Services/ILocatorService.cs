using Localizei.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Localizei.Domain.Services
{
    public interface ILocatorService
    {
        Task<List<Image>> GetAll();
        Task<MatchFindPerson> LocalizedPerson(string imageBase64);
        Task<MatchFindPerson> CompareMultiFaceId(string faceId1, string imageBase64);
    }

}