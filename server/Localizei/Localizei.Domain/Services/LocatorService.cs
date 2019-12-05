using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Localizei.Domain.Repositories;
using Localizei.Domain.Enums;
using Localizei.Domain.Entities;

namespace Localizei.Domain.Services
{
    public class LocatorService : ILocatorService
    {
        private ILocatorRepository _locatorRepository;
        private IRecogninService _recogninService;

        public LocatorService(
                ILocatorRepository locatorRepository,
                IRecogninService recogninService
            )
        {
            _locatorRepository = locatorRepository;
            _recogninService = recogninService;
        }

        public async Task<List<Image>> GetAll()
        {
            return await _locatorRepository.GetAll();
        }

        public async Task<MatchFindPerson> LocalizedPerson(string imageBase64)
        {
            if (!string.IsNullOrEmpty(imageBase64)) {
                var faceId = await _recogninService.GetFaceId(imageBase64);
                var resultMath = await CompareMultiFaceId(faceId, imageBase64);
                var image = new Image
                {
                    Name = "TesteVandão",
                    Data = imageBase64,
                    Status = (int)StatusEncontrado.Localizado
                };
                await _locatorRepository.PostLocalizedPerson(image);
                return resultMath;
            }
            return default;
        }

        public async Task<MatchFindPerson> CompareMultiFaceId(string faceId1, string imageBase64)
        {
            var list = await _locatorRepository.GetAll();

            var valueReturn = new MatchFindPerson();
            foreach (var listImages in list)
            {
               var faceId2 = await _recogninService.GetFaceId(listImages.Data);
                var resultCompare = await _recogninService.ToCompareFaceId(faceId1, faceId2);

                if (resultCompare.isIdentical)
                {
                    valueReturn.DataPersonLocalized = imageBase64;
                    valueReturn.Match = resultCompare;
                    valueReturn.DataPersonWanted = listImages.Data;
                    break;
                }

            };

            if (valueReturn != null && valueReturn.Match != null && valueReturn.Match.isIdentical)
            {
                return valueReturn;
            }
            return default;
        }
    }
}
