using System;
using System.Collections.Generic;
using System.Text;

namespace Localizei.Domain.Entities
{
    public class RecogninSettings : IRecogninSettings
    {
        public string url_recognin_detect { get; set; }
        public string url_recognin_verify { get; set; }
        public string key { get; set; }
    }
    public interface IRecogninSettings
    {
        string url_recognin_verify { get; set; }
        string url_recognin_detect { get; set; }
        string key { get; set; }
    }
}
