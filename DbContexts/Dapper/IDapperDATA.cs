using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.DbContexts.Dapper
{
    public interface IDapperDATA<T> where T : class
    {
        Task<IEnumerable<T>> LoadData(string procName, DynamicParameters param);
        Task<T> ResponseObj(string procName, DynamicParameters param);
        Task<int> ResponseValueInt(string procName, DynamicParameters param);
        Task<string> ResponseValueStr(string procName, DynamicParameters param);
    }

}
