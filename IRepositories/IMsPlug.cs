using AuthenticationApi.ViewModel.Parameters;
using AuthenticationApi.ViewModel.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.IRepositories
{
    public interface IMsPlug
    {
        Task<IEnumerable<MsPlugGetDataPlanResponse>> GetDataPlan();
        Task<AppResponse> BuyAirtme(MsPlugBuyAirtimeParam MsPlugBuyAirtimeParam);
        Task<AppResponse> BuyData(MsPlugBuyDataParam MsPlugBuyDataParam);
    }
}