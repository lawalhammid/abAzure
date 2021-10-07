using AuthenticationApi.Models;
using AuthenticationApi.ViewModel.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.IRepositories
{
    public interface IOnboardActivationDetails
    {
        Task<string> CreateActivation(OnboardActivationDetails OnboardActivationDetails);
    }
}
