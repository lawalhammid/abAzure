using AuthenticationApi.DbContexts;
using AuthenticationApi.DbContexts.Dapper;
using AuthenticationApi.IRepositories;
using AuthenticationApi.Models;
using AuthenticationApi.Utility;
using AuthenticationApi.ViewModel.Parameters;
using AuthenticationApi.ViewModel.Responses;
using AutoMapper;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Repositories
{
    public class WemaBankVirtualAccountImp : IWemaBankVirtualAccount
    {
        private readonly TempaAuthContext _dbContext;
        AppResponse results = new AppResponse();
        private readonly IMapper _mapper;
        IEmailSender _IEmailSender;
        IOnboardActivationDetails _IOnboardActivationDetails;
        IUnitOfContext _IUnitOfContext;
        public WemaBankVirtualAccountImp(TempaAuthContext dbContext, IMapper mapper, IEmailSender IEmailSender, IOnboardActivationDetails IOnboardActivationDetails, IUnitOfContext IUnitOfContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _IEmailSender = IEmailSender;
            _IOnboardActivationDetails = IOnboardActivationDetails;
            _IUnitOfContext = IUnitOfContext;
        }
        public async Task<string> GetVirtualAcctForWEMAUser(WemaUsersAccountParam wemaUsersAccountParam)
        {
            WemaUsersAccountParam _WemaUsersAccountParam = new WemaUsersAccountParam();
            
            var rtn = new DapperDATAImplementation<VirtualAcctProcResponse>();

            string procName = "isp_GetVirtualAcct";

            DynamicParameters param = new DynamicParameters();
            param.Add("@pnId", 1);

            var _response = await rtn.ResponseObj(procName, param);
            string acctNumber = AppSettingsConfig.WEMAAcctPrefix() + _response.VirtualAcct.ToString();
            if(acctNumber.Trim().Length > 10)
                return acctNumber.Substring(0, 10);
           
            return acctNumber;
            
        }

        public async Task<object> ValidateWemaVirtualUser(WemaValidateUsersAccountParam wemaValidateUsersAccountParam)
        {
            var getUser =  await _dbContext.WemaUsersAccount.Where(c => c.BankAcct == wemaValidateUsersAccountParam.AcctountNumber).FirstOrDefaultAsync();
            if(getUser != null)
            return new { 
              FullName = getUser.FullName,
              Status = getUser.RegistrationStatus == "COMPLETE" ? "Active" : "Inactive",
            };
            return  null;
        }

        public async  Task<object> ValidateWemaAccountAmountValidation(WemaValidateUsersAmountValidationParam wemaValidateUsersAmountValidationParam)
        {
            var getUser = await _dbContext.WemaUsersAccount.Where(c => c.BankAcct == wemaValidateUsersAmountValidationParam.AccountNumber).FirstOrDefaultAsync();// && c.AmountPerDay == wemaValidateUsersAmountValidationParam.Amount).FirstOrDefaultAsync();
            if (getUser != null)
                return new
                {
                    FullName = getUser.FullName,
                    Status = getUser.RegistrationStatus == "COMPLETE" ? "Active" : "Inactive",
                    Amount = getUser.AmountPerTransaction == null ? 0 : getUser.AmountPerTransaction
                };
            return null;
        }
    }
}
