using AuthenticationApi.DbContexts;
using AuthenticationApi.IRepositories;
using AuthenticationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Repositories
{
    public class LogTBLImp : ILogTBL
    {
        private readonly TempaAuthContext _dbContext;
        public LogTBLImp(TempaAuthContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> SaveLog(LogTbl logTbl)
        {
            _dbContext.Add(logTbl);
              int save = await Save();
            return save;
        }

        public async Task<int> Save()
        {
            int save = await _dbContext.SaveChangesAsync();
            return save;
        }
    }
}