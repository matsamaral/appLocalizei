using System;
using System.Collections.Generic;
using System.Text;

namespace Localizei.Domain.Entities
{
    public class ObjectError
    {
        public Error Error { get; set; }
    }

    public class Error
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
