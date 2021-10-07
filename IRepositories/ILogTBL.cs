using AuthenticationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.IRepositories
{
    public interface ILogTBL
    {
        Task<int> SaveLog(LogTbl logTbl);
    }
}
