using AuthenticationApi.ViewModel.Parameters;
using AuthenticationApi.ViewModel.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.IRepositories
{
    public interface IPinSettings
    {
        Task<AppResponse> UsersPin(UsersPinParam usersPinParam);
        Task<AppResponse> ValidatePin(UserPinParam userPinParam);
    }
}
