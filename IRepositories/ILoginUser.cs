using AuthenticationApi.Models;
using AuthenticationApi.ViewModel.Parameters;
using AuthenticationApi.ViewModel.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.IRepositories
{
    public interface ILoginUser
    {
        Task<AppResponse> AuthenticateViaPassword(tempaUsersParam tempaUsersParam);
    }
}