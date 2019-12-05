using Localizei.Domain.Entities;
using Localizei.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Localizei.Domain.Services
{
    public class RecogninService : IRecogninService
    {
        private IRecogninRepository _recogninRepository;

        public RecogninService(
                IRecogninRepository recogninRepository
            )
        {
            _recogninRepository = recogninRepository;
        }

        public async Task<string> GetFaceId(string imagePath)
        {
            return await _recogninRepository.GetFaceId(imagePath);
        }

        public async Task<ResultCompare> ToCompareFaceId(string faceId1, string faceId2)
        {
            return await _recogninRepository.ToCompareFaceId(faceId1, faceId2);
        }
    }
}
