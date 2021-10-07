using AuthenticationApi.ViewModel.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.IRepositories
{
    public interface IValidateUser
    {
        Task<ValidateUserResponse> ValidateUser(string TempaTag = null, string EmailAddress = null, string BankAcct = null);
        Task<UserResponse> GetUserDetails(string TempaTag = null, string EmailAddress = null, string BankAcct = null);
    }
}
