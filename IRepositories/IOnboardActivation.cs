using AuthenticationApi.Models;
using AuthenticationApi.ViewModel.Parameters;
using AuthenticationApi.ViewModel.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.IRepositories
{
    public interface IOnboardActivation
    {
        // ------- Providus ----------- //
        Task<AppResponse> ActivateProvidus(ActivationParam activationParam);
        Task<AppResponse> ReActivateProvidus(ActivationParam activationParam);

        // ------- WEMA ----------- //
        Task<AppResponse> ActivateWEMA(ActivationParam activationParam);
        Task<AppResponse> ReActivateWEMA(ActivationParam activationParam);
    }
}