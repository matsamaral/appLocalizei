using System;
using System.Collections.Generic;
using System.Text;

namespace Localizei.Domain.Entities
{
    public class ResultCompare
    {
        public bool isIdentical { get; set; }
        public double confidence { get; set; }
    }
}
