using AuthenticationApi.DbContexts;
using AuthenticationApi.IRepositories;
using AuthenticationApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Repositories
{
    public class TokenImp : IToken
    {
        private readonly TempaAuthContext _dbContext;
        public TokenImp(TempaAuthContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TokenRes> validate(GetTokenParam getTokenParam)
        {
            TokenRes results = new TokenRes();
            var res = await _dbContext.Token.FindAsync(getTokenParam.value1);
            if(res != null)
            {
                if (res.value2 == getTokenParam.value2)
                    results.Token = res.value2;
                return results;
            }
            return results;        
        }

    
    
    }
}
