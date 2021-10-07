using AuthenticationApi.DbContexts;
using AuthenticationApi.IRepositories;
using AuthenticationApi.Models;
using AuthenticationApi.ViewModel.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;




using AuthenticationApi.Utility;
using AuthenticationApi.ViewModel;
using AuthenticationApi.ViewModel.Parameters;
using Microsoft.Extensions.Configuration;

namespace AuthenticationApi.Repositories
{
    public class OnboardActivationDetailsImp : IOnboardActivationDetails
    {
        private readonly TempaAuthContext _dbContext;

        private AppResponse _appResponse = new AppResponse();
        IUnitOfContext _IUnitOfContext;
        public OnboardActivationDetailsImp(TempaAuthContext dbContext, IUnitOfContext IUnitOfContext)
        {
            _dbContext = dbContext;
            _IUnitOfContext = IUnitOfContext;
        }
    
        public async Task<string> CreateActivation(OnboardActivationDetails OnboardActivationDetails)
        {
            OnboardActivationDetails.ExpiryDate = DateTime.Now.AddMinutes(AppSettingsConfig.PinExpireTime());
            OnboardActivationDetails.Activated = false;
            OnboardActivationDetails.DateCreated = DateTime.Now;

           // await _dbContext.AddAsync(OnboardActivationDetails);
          //  int save = await _IUnitOfContext.Save();
           // if (save > 0)
           if(OnboardActivationDetails.ActivationCode != null)
            return OnboardActivationDetails.ActivationCode;

            return string.Empty;
        }
    }
}
