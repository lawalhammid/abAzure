using AuthenticationApi.DbContexts.Dapper;
using AuthenticationApi.IRepositories;
using AuthenticationApi.ViewModel.Responses;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Repositories
{
    public class ValidateUserImp : IValidateUser
    {
        public async Task<ValidateUserResponse> ValidateUser(string TempaTag = null, string EmailAddress = null, string BankAcct = null)
        {
            var rtn = new DapperDATAImplementation<ValidateUserResponse>();

            DynamicParameters param = new DynamicParameters();

            param.Add("@TempaTag", TempaTag);
            param.Add("@EmailAddress", EmailAddress);
            param.Add("@BankAcct", BankAcct);

            var _response = await rtn.ResponseObj("tarmac_ValUser", param);

            return _response;
        }

        public async Task<UserResponse> GetUserDetails(string TempaTag = null, string EmailAddress = null, string BankAcct = null)
        {
            var rtn = new DapperDATAImplementation<UserResponse>();

            DynamicParameters param = new DynamicParameters();

            param.Add("@TempaTag", TempaTag);
            param.Add("@EmailAddress", EmailAddress);
            param.Add("@BankAcct", BankAcct);

            var _response = await rtn.ResponseObj("tarmac_ValUserRtUserDetails", param);

            return _response;
        }
    }

}
