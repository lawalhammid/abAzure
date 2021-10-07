using AuthenticationApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.IRepositories
{
    public interface IToken
    {
        Task<TokenRes> validate(GetTokenParam getTokenParam);
        //Task<TokenRes> validateTokenWEMA(GetTokenWEMAParam getTokenParam);
    }
}
