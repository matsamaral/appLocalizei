using System.Threading.Tasks;
using Localizei.Domain.Entities;
using Localizei.Domain.Services;

namespace Localizei.Domain.Repositories
{
    public interface IRecogninRepository
    {
        Task<string> GetFaceId(string imageFilePath);
        Task<ResultCompare> ToCompareFaceId(string faceId1, string faceId2);
    }
}