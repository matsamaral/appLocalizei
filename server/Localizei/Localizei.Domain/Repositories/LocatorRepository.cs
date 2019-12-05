using Localizei.Domain.Entities;
using Localizei.Domain.Enums;
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
    public class LocatorRepository : ILocatorRepository
    {
        private readonly IMongoCollection<Image> _imageStore;

        public LocatorRepository(IImageStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _imageStore = database.GetCollection<Image>(settings.ImageCollectionName);
        }

        public async Task<List<Image>> GetAll()
        {
           return _imageStore.Find(image => true).ToList();
        }

        public async Task<Image> PostLocalizedPerson(Image image)
        {
            _imageStore.InsertOne(image);
            return image;
        }

    }
}
    