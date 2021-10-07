using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.ViewModel
{
    public class GetTokenParam
    {
        public long value1 { get; set; }
        public string value2 { get; set; }
    }

    public class GetTokenWEMAParam
    {
        public long Auth1 { get; set; }
        public string Auth2 { get; set; }
    }
}
