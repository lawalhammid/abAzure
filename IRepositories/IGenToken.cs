using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.IRepositories
{
    public interface IGenToken
    {
        Task<object> GenNewToken();
    }
}
