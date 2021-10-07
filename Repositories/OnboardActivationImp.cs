using AuthenticationApi.DbContexts;
using AuthenticationApi.IRepositories;
using AuthenticationApi.Models;
using AuthenticationApi.ViewModel.Parameters;
using AuthenticationApi.ViewModel.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using AuthenticationApi.Utility;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using AuthenticationApi.DbContexts.Dapper;
using Dapper;

namespace AuthenticationApi.Repositories
{
    public class OnboardActivationImp : IOnboardActivation
    {
        private readonly TempaAuthContext _dbContext;
        IUnitOfContext _IUnitOfContext;
        IEmailSender _IEmailSender;

        private AppResponse _appResponse = new AppResponse();
        public OnboardActivationImp(TempaAuthContext dbContext, IUnitOfContext IUnitOfContext, IEmailSender IEmailSender)
        {
            _dbContext = dbContext;
            _IUnitOfContext = IUnitOfContext;
            _IEmailSender = IEmailSender;
        }

        public async Task<AppResponse> ActivateProvidus(ActivationParam activationParam)
        {
            var getUserEmail = await _dbContext.OnboardActivationDetails.Where(c => c.UserEmail == activationParam.UserEmail).FirstOrDefaultAsync();
            if (getUserEmail == null)
                return new AppResponse
                {
                    ResponseCode = "01",
                    ResponseMessage = "Invalid user email address or activation code!"
                };
            if (getUserEmail.ActivationCode != activationParam.ActivationCode)
                return new AppResponse
                {
                    ResponseCode = "01",
                    ResponseMessage = "Invalid user email address or activation code!"
                };

            var getActivateCode = await _dbContext.OnboardActivationDetails.Where(c=> c.ActivationCode == activationParam.ActivationCode).FirstOrDefaultAsync();
            if (getActivateCode == null)
                return new AppResponse {
                    ResponseCode = "01",
                    ResponseMessage = "Invalid activation Code!"
            };

            if(getActivateCode.UserEmail == activationParam.UserEmail)
            {
                OnboardActivationDetails OnboardActivationDetails = new OnboardActivationDetails();

                if (getActivateCode.ExpiryDate < DateTime.Now)
                    return new AppResponse
                    {
                        ResponseCode = "01",
                        ResponseMessage = "Activation code has expires! You can request a new one"
                    };

                if (getActivateCode.Activated == true)
                    return new AppResponse
                    {
                        ResponseCode = "01",
                        ResponseMessage = "Your account has already been activated"           
                    };

              

                getActivateCode.Activated = true;

                var response = _dbContext.Update(getActivateCode);
                int save = await _IUnitOfContext.SaveAuditTrail(getActivateCode.UserEmail);
                
                if (save > 0)
                {
                    try
                    {
                        var tempaUser = await _dbContext.Users.Where(c => c.EmailAddress == getActivateCode.UserEmail).FirstOrDefaultAsync();

                        try
                        {
                            tempaUser.RegistrationStatus = "COMPLETE";
                            _dbContext.Update(tempaUser);
                            save = await _IUnitOfContext.SaveAuditTrail(getActivateCode.UserEmail);
                        }
                        catch(Exception ex)
                        {

                        }
                       

                        EmailParam emailParam = new EmailParam();
                        emailParam.ReceiverEmail = tempaUser.EmailAddress;
                        emailParam.FullName = tempaUser.FullName;
                        emailParam.OtherDetails = JsonConvert.SerializeObject(tempaUser);

                        var emial = await _IEmailSender.SendEmail(emailParam, 2);
                    }
                    catch(Exception ex)
                    {
                        var exM = ex.StackTrace;
                    }
                    return new AppResponse
                    {
                        ResponseCode = "00",
                        ResponseMessage = "Your account activated succcessful!"
                    };
                }
            }

            return new AppResponse
            {
                ResponseCode = "01",
                ResponseMessage = "Your activation request did'nt complete!"
            };
        }

        public async Task<AppResponse> ReActivateProvidus(ActivationParam activationParam)
        {
            var getActivateCode = await _dbContext.OnboardActivationDetails.Where(c => c.UserEmail == activationParam.UserEmail).FirstOrDefaultAsync(); ;
            if (getActivateCode == null)
                return new AppResponse
                {
                    ResponseCode = "01",
                    ResponseMessage = "Email did'nt have an initial activation Code!"
                };

            if (getActivateCode.UserEmail == activationParam.UserEmail)
            {
                OnboardActivationDetails OnboardActivationDetails = new OnboardActivationDetails();

                if (getActivateCode.Activated == true)
                    return new AppResponse
                    {
                        ResponseCode = "01",
                        ResponseMessage = "Your account has already been activated"
                    };

                string pin = RandomGeneration.Pin();

                getActivateCode.ActivationCode = pin;
                getActivateCode.Activated = false;
                _dbContext.Update(getActivateCode);
                int save = await _IUnitOfContext.Save();
                if (save > 0)
                {
                    EmailParam emailParam = new EmailParam();
                    emailParam.ReceiverEmail = getActivateCode.UserEmail;

                    var getUserFulName = await _dbContext.Users.Where(c => c.EmailAddress == getActivateCode.UserEmail).FirstOrDefaultAsync();

                    emailParam.FullName = getUserFulName.FullName ?? string.Empty; 
                    emailParam.Pin = pin;

                    var email = await _IEmailSender.SendEmail(emailParam, 1);

                    if (email.ResponseCode == "00")
                    {
                        return new AppResponse
                        {
                            ResponseCode = "00",
                            ResponseMessage = "Your new activation code has been sent to your email!"
                        };
                    }
                }
                    
            }

            return new AppResponse
            {
                ResponseCode = "01",
                ResponseMessage = "Your activation request did'nt complete!"
            };
        }


        //// --- WEMA Below ---- //

        public async Task<AppResponse> ActivateWEMA(ActivationParam activationParam)
        {
            var getUserEmail = await _dbContext.OnboardActivationDetails.Where(c => c.UserEmail == activationParam.UserEmail).FirstOrDefaultAsync();
            if (getUserEmail == null)
                return new AppResponse
                {
                    ResponseCode = "01",
                    ResponseMessage = "Invalid user email address or activation code!"
                };
            if (getUserEmail.ActivationCode != activationParam.ActivationCode)
                return new AppResponse
                {
                    ResponseCode = "01",
                    ResponseMessage = "Invalid user email address or activation code!"
                };

            var getActivateCode = await _dbContext.OnboardActivationDetails.Where(c => c.ActivationCode == activationParam.ActivationCode).FirstOrDefaultAsync();
            if (getActivateCode == null)
                return new AppResponse
                {
                    ResponseCode = "01",
                    ResponseMessage = "Invalid activation Code!"
                };

            if (getActivateCode.UserEmail == activationParam.UserEmail)
            {
                OnboardActivationDetails OnboardActivationDetails = new OnboardActivationDetails();

                if (getActivateCode.ExpiryDate < DateTime.Now)
                    return new AppResponse
                    {
                        ResponseCode = "01",
                        ResponseMessage = "Activation code has expires! You can request a new one"
                    };

                if (getActivateCode.Activated == true)
                    return new AppResponse
                    {
                        ResponseCode = "01",
                        ResponseMessage = "Your account has already been activated"
                    };



                getActivateCode.Activated = true;
                getActivateCode.DateActivated = DateTime.Now;

                var response = _dbContext.Update(getActivateCode);
                
                
                
                int save = await _IUnitOfContext.SaveAuditTrail(getActivateCode.UserEmail);

                if (save > 0)
                {
                    try
                    {
                        var tempaUser = await _dbContext.Users.Where(c => c.EmailAddress == getActivateCode.UserEmail).FirstOrDefaultAsync();

                        var WemaUsersAccount = await _dbContext.WemaUsersAccount.Where(c => c.EmailAddress == getActivateCode.UserEmail).FirstOrDefaultAsync();

                        try
                        {
                            tempaUser.RegistrationStatus = "COMPLETE";
                            WemaUsersAccount.RegistrationStatus = "COMPLETE";

                            _dbContext.Update(tempaUser);
                            _dbContext.Update(WemaUsersAccount);

                           
                            try
                            {
                                var rtn = new DapperDATAImplementation<ResponseBalanceOnBoard>();

                                DynamicParameters param = new DynamicParameters();
                                param.Add("@TransRef", "000");
                                param.Add("@Balance", "0.00");
                                param.Add("@LastAmountCredit", "0.00");
                                param.Add("@SessionId", null);
                                param.Add("@EmaiAddress", tempaUser.EmailAddress);
                                param.Add("@PhoneNo", tempaUser.PhoneNumber);
                                param.Add("@WalletAcct", tempaUser.WalletAcct);

                                var _response = await rtn.ResponseObj("isp_InsertBalanceOnBoarding", param);
                            }
                            catch(Exception exc)
                            {

                            }


                            save = await _IUnitOfContext.SaveAuditTrail(getActivateCode.UserEmail);
                        }
                        catch (Exception ex)
                        {

                        }


                        EmailParam emailParam = new EmailParam();
                        emailParam.ReceiverEmail = tempaUser.EmailAddress;
                        emailParam.FullName = tempaUser.FullName;
                        emailParam.OtherDetails = JsonConvert.SerializeObject(tempaUser);

                        var emial = await _IEmailSender.SendEmail(emailParam, 2);
                    }
                    catch (Exception ex)
                    {
                        var exM = ex.StackTrace;
                    }
                    return new AppResponse
                    {
                        ResponseCode = "00",
                        ResponseMessage = "Your account activated succcessful!"
                    };
                }
            }

            return new AppResponse
            {
                ResponseCode = "01",
                ResponseMessage = "Your activation request did'nt complete!"
            };
        }

        public async Task<AppResponse> ReActivateWEMA(ActivationParam activationParam)
        {
            var getActivateCode = await _dbContext.OnboardActivationDetails.Where(c => c.UserEmail == activationParam.UserEmail).FirstOrDefaultAsync(); ;
            if (getActivateCode == null)
                return new AppResponse
                {
                    ResponseCode = "01",
                    ResponseMessage = "Email did'nt have an initial activation Code!"
                };

            if (getActivateCode.UserEmail == activationParam.UserEmail)
            {
                OnboardActivationDetails OnboardActivationDetails = new OnboardActivationDetails();

                if (getActivateCode.Activated == true)
                    return new AppResponse
                    {
                        ResponseCode = "01",
                        ResponseMessage = "Your account has already been activated"
                    };

                string pin = RandomGeneration.Pin();

                getActivateCode.ActivationCode = pin;
                getActivateCode.Activated = false;
                _dbContext.Update(getActivateCode);
                int save = await _IUnitOfContext.Save();
                if (save > 0)
                {
                    EmailParam emailParam = new EmailParam();
                    emailParam.ReceiverEmail = getActivateCode.UserEmail;

                    var getUserFulName = await _dbContext.Users.Where(c => c.EmailAddress == getActivateCode.UserEmail).FirstOrDefaultAsync();

                    emailParam.FullName = getUserFulName.FullName ?? string.Empty;
                    emailParam.Pin = pin;

                    var email = await _IEmailSender.SendEmail(emailParam, 1);

                    if (email.ResponseCode == "00")
                    {
                        return new AppResponse
                        {
                            ResponseCode = "00",
                            ResponseMessage = "Your new activation code has been sent to your email!"
                        };
                    }
                }

            }

            return new AppResponse
            {
                ResponseCode = "01",
                ResponseMessage = "Your activation request did'nt complete!"
            };
        }

    }
}