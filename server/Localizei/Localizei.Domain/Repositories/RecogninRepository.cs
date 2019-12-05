using Localizei.Domain.Entities;
using Localizei.Domain.Services;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Localizei.Domain.Repositories
{
    public class RecogninRepository : IRecogninRepository
    {
        private string uriDetect;
        private string uriVerify;
        private string subscriptionKey;

        public RecogninRepository(IRecogninSettings settings)
        {
            uriDetect = settings.url_recognin_detect;
            uriVerify = settings.url_recognin_verify;
            subscriptionKey = settings.key;
        }

        public async Task<string> GetFaceId(string imageFilePath)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add(
                "Ocp-Apim-Subscription-Key", subscriptionKey);

            string requestParameters = "returnFaceId=true";

            string uri = uriDetect + "?" + requestParameters;

            HttpResponseMessage response;

            var match = Regex.Match(imageFilePath, @"data:(?<type>.+?);base64,(?<data>.+)");
            var base64Data = match.Groups["data"].Value;
            byte[] bytesArray = Convert.FromBase64String(base64Data);
            using (ByteArrayContent content = new ByteArrayContent(bytesArray))
            {
                content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/octet-stream");

                response = await client.PostAsync(uri, content);
                string contentString = await response.Content.ReadAsStringAsync();

                if (response.StatusCode != System.Net.HttpStatusCode.BadRequest)
                {

                
                    var obj = JsonConvert.DeserializeObject<List<Image>>(contentString);
                    return obj[0].FaceId;
        
                }
                else
                {
                    var obj = JsonConvert.DeserializeObject<ObjectError>(contentString);
                     throw new ArgumentException(obj.Error.Message);
                }

            }
        }

        public async Task<ResultCompare> ToCompareFaceId(string faceId1, string faceId2)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add(
                "Ocp-Apim-Subscription-Key", subscriptionKey);

            string uri = uriVerify;

            HttpResponseMessage response;

            var stringCompare = new Verify
            {
                FaceId1 = faceId1,
                FaceId2 = faceId2
            };

            var jsonString = JsonConvert.SerializeObject(stringCompare);

            using (var content = new StringContent(jsonString, Encoding.UTF8, "application/json"))
            {
                content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/json");

                response = await client.PostAsync(uri, content);

                string contentString = await response.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<ResultCompare>(contentString);


                return obj;
            }
        }
    }
}
