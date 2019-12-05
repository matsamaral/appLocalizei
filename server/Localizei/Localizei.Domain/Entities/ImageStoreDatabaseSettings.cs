using System;
using System.Collections.Generic;
using System.Text;

namespace Localizei.Domain.Entities
{
    public class ImageStoreDatabaseSettings : IImageStoreDatabaseSettings
    {
        public string ImageCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IImageStoreDatabaseSettings
    {
        string ImageCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
