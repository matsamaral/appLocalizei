using System;
using System.Collections.Generic;
using System.Text;

namespace Localizei.Domain.Entities
{
    public class MatchFindPerson
    {
        public string DataPersonLocalized { get; set; }
        public string DataPersonWanted { get; set; }
        public ResultCompare Match { get; set; }
        public int Status { get; set; }
    }
}
