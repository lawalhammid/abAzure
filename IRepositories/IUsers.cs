using AuthenticationApi.Models;
using AuthenticationApi.ViewModel.Parameters;
using AuthenticationApi.ViewModel.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.IRepositories
{
    public interface IUsers
    {
        Task<LoginResponse> LoginUser(LoginParam loginParam);
        Task<object> VeryUserByAcctNo(string Account);

        //--Below for WEMA Bank ---//

        Task<AppResponse> CreateUser(tempaUsersParam tempaUsersParam);
        Task<LoginResponse> LoginUserWEMA(LoginParam loginParam);
        Task<LoginResponse> LoginFingerWEMA(string FingerPrintUser);

        /// ==  For Post Group ===// 
        Task<AppResponse> CreatPostGroup(GroupUsersParam groupUsersParam);
        Task<AppResponse> CreatCorporate(CorporateUsersParam corporateUsersParam);
        Task<List<ContactResponse>> Contacts(ContactParam ContactParam);
    }
}