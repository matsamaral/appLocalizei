using Localizei.Domain.Entities;
using System.Threading.Tasks;

namespace Localizei.Domain.Services
{
    public interface IRecogninService
    {
        Task<string> GetFaceId(string imagePath);
        Task<ResultCompare> ToCompareFaceId(string faceId1, string faceId2);
    }
}