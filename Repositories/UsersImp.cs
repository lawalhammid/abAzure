using AuthenticationApi.ApiCalls;
using AuthenticationApi.DbContexts;
using AuthenticationApi.DbContexts.Dapper;
using AuthenticationApi.IRepositories;
using AuthenticationApi.Models;
using AuthenticationApi.Utility;
using AuthenticationApi.ViewModel;
using AuthenticationApi.ViewModel.Parameters;
using AuthenticationApi.ViewModel.Responses;
using AutoMapper;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Repositories
{
    public class UsersImp : IUsers
    {
        private readonly TempaAuthContext _dbContext;
        AppResponse results = new AppResponse();
        private readonly IMapper _mapper;
        IEmailSender _IEmailSender;
        IWemaBankVirtualAccount _IWemaBankVirtualAccount;

        IOnboardActivationDetails _IOnboardActivationDetails;
        IUnitOfContext  _IUnitOfContext;
        public UsersImp(TempaAuthContext dbContext, IMapper mapper,  IEmailSender IEmailSender, IOnboardActivationDetails IOnboardActivationDetails, IUnitOfContext IUnitOfContext, IWemaBankVirtualAccount IWemaBankVirtualAccount)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _IEmailSender = IEmailSender;
            _IOnboardActivationDetails = IOnboardActivationDetails;
            _IUnitOfContext = IUnitOfContext;
            _IWemaBankVirtualAccount = IWemaBankVirtualAccount;
        }
       
        // ---- Below for WEMA Bank --- //
        public async Task<AppResponse> CreateUser(tempaUsersParam tempaUsersParam)
        {
            string TempaDeveloperTeamAndErrorMessage = $"Your account could not be created at the moment, try again later or contact us on {AppSettingsConfig.GetTempaTeamContact()}";
            try
            {         
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        if (!Channel.ChannelVal(tempaUsersParam.Channel))
                        {
                            results.ResponseCode = "01";
                            results.ResponseMessage = "Invalid channel!";

                            return results;
                        }

                        if (string.IsNullOrWhiteSpace(tempaUsersParam.EmailAddress) || string.IsNullOrWhiteSpace(tempaUsersParam.Password) || string.IsNullOrWhiteSpace(tempaUsersParam.UserType))
                        {
                            results.ResponseCode = "01";
                            results.ResponseMessage = "Email Address, Password and User Type are Required";

                            return results;
                        }
                        if (!(Validation.IsValidPassword(tempaUsersParam.Password)))
                        {
                            results.ResponseCode = "01";
                            results.ResponseMessage = "Password must contain atleast a Number, One UpperCase and Minimum of 8 Characters";
                            return results;
                        }

                        if (!(Validation.IsValidPhoneNumber(tempaUsersParam.PhoneNumber)))
                        {
                            results.ResponseCode = "01";
                            results.ResponseMessage = "Phone number must conform with Nigeria standard. e.g 08073782015";
                            return results;
                        }

                        if (!(Validation.IsValidEmail(tempaUsersParam.EmailAddress)))
                        {
                            results.ResponseCode = "01";
                            results.ResponseMessage = "Invalid Email Address";
                            return results;
                        }
                        //if (string.IsNullOrWhiteSpace(tempaUsersParam.UserType))
                        //{
                        //    results.ResponseCode = "01";
                        //    results.ResponseMessage = "Kindy Supply User Type";
                        //    return results;
                        //}
                        //var TempaTag = await _dbContext.TempaUsers.Where(c => c.TempaTag == tempaUsersParam.TempaTag).FirstOrDefaultAsync();
                        //if (TempaTag != null)
                        //{
                        //    results.ResponseCode = "01";
                        //    results.ResponseMessage = "Tempa tag already exists";

                        //    return results;
                        //}

                        var EmailAddress = await _dbContext.Users.Where(c => c.EmailAddress == tempaUsersParam.EmailAddress).FirstOrDefaultAsync();
                        if (EmailAddress != null)
                        {
                            results.ResponseCode = "02";
                            results.ResponseMessage = "Email already been used";

                            return results;
                        }
                        var PhoneNumber = await _dbContext.Users.Where(c => c.PhoneNumber == tempaUsersParam.PhoneNumber).FirstOrDefaultAsync();

                        if (PhoneNumber != null)
                        {
                            results.ResponseCode = "03";
                            results.ResponseMessage = "Phone number already been used";

                            return results;
                        }

                        if (!string.IsNullOrWhiteSpace(tempaUsersParam.GroupTag))
                        {
                            var GroupExits = await _dbContext.Users.Where(c => c.GroupTag == tempaUsersParam.GroupTag).FirstOrDefaultAsync();
                            if (GroupExits != null)
                            {
                                results.ResponseCode = "01";
                                results.ResponseMessage = "Group tag already exist. Kindly provide a new group tag";
                                return results;
                            }

                        }

                        string pinNo = RandomGeneration.Pin();

                        byte[] passwordHash, passwordSalt;
                        PasswordSecurity.CreatePasswordHash(tempaUsersParam.Password, out passwordHash, out passwordSalt);


                        if (!string.IsNullOrWhiteSpace(tempaUsersParam.UserType))
                        {
                            if (tempaUsersParam.UserType.ToLower() == "individual")
                            {
                                tempaUsersParam.BusinessName = null;
                                tempaUsersParam.BusinessType = null;
                                tempaUsersParam.CACRegNo = null;
                                tempaUsersParam.BusinessTINNumber = null;
                                tempaUsersParam.BusinessCACDocImageCloudPath = null;
                                tempaUsersParam.GroupName = null;
                                tempaUsersParam.GroupDescription = null;
                                tempaUsersParam.GroupTag = null;
                            }
                            if (tempaUsersParam.UserType.ToLower() == "business")
                            {
                                tempaUsersParam.GroupName = null;
                                tempaUsersParam.GroupDescription = null;
                                tempaUsersParam.GroupTag = null;
                            }
                            if (tempaUsersParam.UserType.ToLower() == "group")
                            {
                                tempaUsersParam.BusinessName = null;
                                tempaUsersParam.BusinessType = null;
                                tempaUsersParam.CACRegNo = null;
                                tempaUsersParam.BusinessTINNumber = null;
                                tempaUsersParam.BusinessCACDocImageCloudPath = null;
                            }
                        }

                        string BankName = "ABBIZWORD&TARMAC CO.";

                        var tempaUser = _mapper.Map<Users>(tempaUsersParam);
                        string tempaTagAfterValidation = Validation.ValidTempaTag(Validation.ReplaceWhitespace(tempaUser.FullName, "")) + pinNo;
                        string groupTagAfterValidation = Validation.ValidTempaTag(tempaUser.GroupTag);

                        tempaUser.TempaTag = tempaTagAfterValidation;
                        tempaUser.GroupTag = groupTagAfterValidation;

                        tempaUser.BankName = BankName;
                        tempaUser.DateCreated = DateTime.Now;
                        tempaUser.PasswordHash = passwordHash;
                        tempaUser.PasswordSalt = passwordSalt;
                        tempaUser.RegistrationStatus = "INCOMPLETE";
                        tempaUser.ReferralCode = RandomGeneration.TempaReferralCode();

                        WemaUsersAccountParam wemaUsersAccountParam = new WemaUsersAccountParam();

                        wemaUsersAccountParam.Channel = tempaUsersParam.Channel;
                        wemaUsersAccountParam.FullName = tempaUsersParam.FullName;
                        wemaUsersAccountParam.TempaTag = tempaTagAfterValidation.Trim();
                        wemaUsersAccountParam.EmailAddress = tempaUser.EmailAddress;
                        wemaUsersAccountParam.PhoneNumber = tempaUser.PhoneNumber;
                        wemaUsersAccountParam.BankName = BankName;
                        wemaUsersAccountParam.BankAcctName = tempaUsersParam.FullName;
                        wemaUsersAccountParam.RegistrationStatus = "INCOMPLETE";
                        wemaUsersAccountParam.DateCreated = DateTime.Now;

                        var getVirtual = await _IWemaBankVirtualAccount.GetVirtualAcctForWEMAUser(wemaUsersAccountParam);

                        wemaUsersAccountParam.BankAcct = getVirtual;
                        tempaUser.WalletAcct = getVirtual;
                        var wemaUser = _mapper.Map<WemaUsersAccount>(wemaUsersAccountParam);

                        var OnboardActivationDetails = new OnboardActivationDetails();

                        OnboardActivationDetails.UserEmail = tempaUser.EmailAddress;
                        OnboardActivationDetails.ActivationCode = pinNo;
                        OnboardActivationDetails.Tag = tempaTagAfterValidation;

                        var pin = await _IOnboardActivationDetails.CreateActivation(OnboardActivationDetails);

                        EmailParam emailParam = new EmailParam();
                        emailParam.ReceiverEmail = tempaUsersParam.EmailAddress;
                        emailParam.FullName = tempaUser.FullName;
                        emailParam.Pin = pin;
                        emailParam.OtherDetails = JsonConvert.SerializeObject(tempaUser);

                        var emial = await _IEmailSender.SendEmail(emailParam, 1);
                        if (emial.ResponseCode == "99")
                        {
                            results.ResponseCode = emial.ResponseCode;
                            results.ResponseMessage = $"Your account could not be created, kindly verify if your email is a valid one. If problem persist, kindly contacts tempa on {AppSettingsConfig.GetTempaTeamContact()}";

                            transaction.Rollback();

                            return results;
                        }

                        if (emial.ResponseCode == "00")
                        {
                            results.ResponseCode = emial.ResponseCode;
                            results.ResponseMessage = "Your account created successfully! Kindly complete your registration with the code(OTP) sent to your email.";

                            await _dbContext.AddAsync(wemaUser);
                            await _dbContext.AddAsync(tempaUser);
                            await _dbContext.AddAsync(OnboardActivationDetails);

                            int saveUserAndWema = await _IUnitOfContext.Save();

                            transaction.Commit();

                            return results;
                        }
                       
                       

                        return results;

                        
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        results.ResponseCode = "04";
                        results.ResponseMessage = TempaDeveloperTeamAndErrorMessage;

                        return results;

                    }
                }

            }
            catch (Exception ex)
            {
                results.ResponseCode = "04";
                results.ResponseMessage = TempaDeveloperTeamAndErrorMessage;
            
            }

            return results;
        }

        public async Task<LoginResponse> LoginUserWEMA(LoginParam loginParam)
        {
            var getUSer = await _dbContext.Users.Where(c => c.TempaTag == loginParam.UserEmailOrPhone).FirstOrDefaultAsync();
            if (getUSer == null)
                getUSer = await _dbContext.Users.Where(c => c.EmailAddress == loginParam.UserEmailOrPhone).FirstOrDefaultAsync();

            if (getUSer != null)
            {


                if (!PasswordSecurity.VerifyPasswordHash(loginParam.Password, getUSer.PasswordHash, getUSer.PasswordSalt))
                {

                    return new LoginResponse
                    {
                        ResponseCode = "01",
                        ResponseMessage = "Invalid Credentials"
                    };
                }

                var getUserActivationCode = await _dbContext.OnboardActivationDetails.Where(c => c.UserEmail == loginParam.UserEmailOrPhone).FirstOrDefaultAsync();
                if (getUserActivationCode == null)
                    getUserActivationCode = await _dbContext.OnboardActivationDetails.Where(c => c.Tag == loginParam.UserEmailOrPhone).FirstOrDefaultAsync();
                if (getUserActivationCode != null)
                {
                    if (getUserActivationCode.Activated == false)
                    {
                        return new LoginResponse
                        {
                            ResponseCode = "01",
                            ResponseMessage = "Kindly complete your registration with the OTP sent to your email or request for a new one"
                        };
                    }
                }

                var tempaUser = new LoginUserResponse
                {
                    UserType = getUSer.UserType,
                    FullName = getUSer.FullName,
                    TempaTag = getUSer.TempaTag,
                    EmailAddress = getUSer.EmailAddress,
                    PhoneNumber = getUSer.PhoneNumber,
                    BankName = getUSer.BankName,
                    BusinessName = getUSer.BusinessName,
                    BusinessType = getUSer.BusinessType,
                    CACRegNo = getUSer.CACRegNo,
                    BusinessTINNumber = getUSer.BusinessTINNumber,
                    BusinessCACDocImageCloudPath = getUSer.BusinessCACDocImageCloudPath,
                    GroupName = getUSer.GroupName,
                    GroupDescription = getUSer.GroupDescription,
                    ReceiveLatestNews = getUSer.ReceiveLatestNews,
                    GroupTag = getUSer.GroupTag,
                };
                var objectToEn = new LoginResponse
                {
                    ResponseCode = "00",
                    ResponseMessage = "Success!",
                    BankName = getUSer.BankName,
                    UserAccount = getUSer.WalletAcct,
                    UserFullName = getUSer.FullName,
                    UserType = getUSer.UserType,
                    TempaTag = getUSer.TempaTag,
                    GroupTag = getUSer.GroupTag,
                    loginUserResponse = tempaUser

                };

                var other = JsonConvert.SerializeObject(objectToEn);

                string encryptedValue = Cryptors.Encrypt(other);

                return new LoginResponse
                {
                    ResponseCode = "00",
                    ResponseMessage = "Success!",
                    BankName = getUSer.BankName,
                    UserAccount = getUSer.WalletAcct,
                    UserFullName = getUSer.FullName,
                    UserType = getUSer.UserType,
                    TempaTag = getUSer.TempaTag,
                    GroupTag = getUSer.GroupTag,
                    loginUserResponse = tempaUser,
                    OtherDetails = encryptedValue

                };
            }
            return new LoginResponse
            {
                ResponseCode = "01",
                ResponseMessage = "Invalid Credentials!"
            };
        }

        public async Task<LoginResponse> LoginFingerWEMA(string FingerPrintUser)
        {
            try
            {
                string decryptedValue = Cryptors.Decrypt(FingerPrintUser);
                var DesresultObj = JsonConvert.DeserializeObject<LoginResponse>(decryptedValue);

                return DesresultObj;
            }
            catch (Exception ex)
            {
                var exM = ex.StackTrace;

            }

            return null;
        }
       
        public async Task<AppResponse> CreatPostGroup(GroupUsersParam groupUsersParam)
        {
            try
            {
                var groupUsers = _mapper.Map<GroupUsers>(groupUsersParam);

                groupUsers.Tag = Validation.ValidTempaTag(groupUsersParam.TempaTag);
                groupUsers.GroupTag = Validation.ValidTempaTag(groupUsersParam.GroupTag);
                groupUsers.DateCreated = DateTime.Now;

                await _dbContext.AddAsync(groupUsers);
               
                int save = await _IUnitOfContext.Save();
                if(save > 0)
                results.ResponseCode = "00";
                results.ResponseMessage = "Success";
                return results;
            }
            catch(Exception ex)
            {
                var exM = ex;
            }
            results.ResponseCode = "01";
            results.ResponseMessage = "Your group could not be created. Kindly try later";
            return results;
        }

        public async Task<AppResponse> CreatCorporate(CorporateUsersParam corporateUsersParam)
        {
            try
            {
                var corporateUsers = _mapper.Map<CorporateUsers>(corporateUsersParam);

                corporateUsers.Tag = Validation.ValidTempaTag(corporateUsersParam.TempaTag);
                corporateUsers.DateCreated = DateTime.Now;

                await _dbContext.AddAsync(corporateUsers);


                int save = await _IUnitOfContext.Save();
                if (save > 0)
                    results.ResponseCode = "00";
                results.ResponseMessage = "Success";
                return results;
            }
            catch(Exception ex)
            {
                var exM = ex;
            }

            
            results.ResponseCode = "01";
            results.ResponseMessage = "Your corporate account couldn't be created at this moment. Kindly try later";
            return results;
        }

        public async Task<LoginResponse> LoginUser(LoginParam loginParam)
        {
            var getUSer = await _dbContext.Users.Where(c => c.TempaTag == loginParam.UserEmailOrPhone).FirstOrDefaultAsync();
            if (getUSer == null)
            {
                getUSer = await _dbContext.Users.Where(c => c.EmailAddress == loginParam.UserEmailOrPhone).FirstOrDefaultAsync();
            }
            if (getUSer == null)
            {
                getUSer = await _dbContext.Users.Where(c => c.PhoneNumber == loginParam.UserEmailOrPhone).FirstOrDefaultAsync();
            }

            if (getUSer != null)
            {
                if (!PasswordSecurity.VerifyPasswordHash(loginParam.Password, getUSer.PasswordHash, getUSer.PasswordSalt))
                {

                    return new LoginResponse
                    {
                        ResponseCode = "01",
                        ResponseMessage = "Invalid Credentials"
                    };
                }

                var getUserActivationCode = await _dbContext.OnboardActivationDetails.Where(c => c.UserEmail == loginParam.UserEmailOrPhone).FirstOrDefaultAsync();
                if (getUserActivationCode == null)
                    getUserActivationCode = await _dbContext.OnboardActivationDetails.Where(c => c.Tag == loginParam.UserEmailOrPhone).FirstOrDefaultAsync();
                if (getUserActivationCode != null)
                {
                    if (getUserActivationCode.Activated == false)
                    {
                        return new LoginResponse
                        {
                            ResponseCode = "01",
                            ResponseMessage = "Kindly complete your registration with the OTP sent to your email or request for a new one"
                        };
                    }
                }

                var tempaUser = new LoginUserResponse
                {
                    UserType = getUSer.UserType,
                    FullName = getUSer.FullName,
                    TempaTag = getUSer.TempaTag,
                    EmailAddress = getUSer.EmailAddress,
                    PhoneNumber = getUSer.PhoneNumber,
                    BankName = getUSer.BankName,
                    BusinessName = getUSer.BusinessName,
                    BusinessType = getUSer.BusinessType,
                    CACRegNo = getUSer.CACRegNo,
                    BusinessTINNumber = getUSer.BusinessTINNumber,
                    BusinessCACDocImageCloudPath = getUSer.BusinessCACDocImageCloudPath,
                    GroupName = getUSer.GroupName,
                    GroupDescription = getUSer.GroupDescription,
                    ReceiveLatestNews = getUSer.ReceiveLatestNews,
                    GroupTag = getUSer.GroupTag,
                };
                var objectToEn = new LoginResponse
                {
                    ResponseCode = "00",
                    ResponseMessage = "Success!",
                    BankName = getUSer.BankName,
                    UserAccount = getUSer.WalletAcct,
                    UserFullName = getUSer.FullName,
                    UserType = getUSer.UserType,
                    TempaTag = getUSer.TempaTag,
                    GroupTag = getUSer.GroupTag,
                    loginUserResponse = tempaUser

                };

                var other = JsonConvert.SerializeObject(objectToEn);

                string encryptedValue = Cryptors.Encrypt(other);

                return new LoginResponse
                {
                    ResponseCode = "00",
                    ResponseMessage = "Success!",
                    BankName = getUSer.BankName,
                    UserAccount = getUSer.WalletAcct,
                    UserFullName = getUSer.FullName,
                    UserType = getUSer.UserType,
                    TempaTag = getUSer.TempaTag,
                    GroupTag = getUSer.GroupTag,
                    loginUserResponse = tempaUser,
                    OtherDetails = encryptedValue

                };
            }
            return new LoginResponse
            {
                ResponseCode = "01",
                ResponseMessage = "Invalid Credentials!"
            };
        }


        public async Task<object> VeryUserByAcctNo(string Account)
        {
            try
            {
                var getUSer = await _dbContext.Users.Where(c => c.WalletAcct == Account.Trim()).FirstOrDefaultAsync();

                return new
                {
                    Name = getUSer.FullName
                };
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ContactResponse>> Contacts(ContactParam ContactParam)
        {
            try
            {
                var rtn = new DapperDATAImplementation<ContactResponse1>();

                DynamicParameters param = new DynamicParameters();
                param.Add("@pnId", 1);
                param.Add("@UserTag", ContactParam.UserTag);
                param.Add("@UsersPhonesNo", "sderee");

                //var items = _dbContext.TempaUsers.Where(item => ContactParam.UserContacts.Contains(item.PhoneNumber)).ToList();
                var _response = await rtn.ResponseObj("isp_GetContactVirtualAcct", param);

                IDbConnection conn = new SqlConnection(AppSettingsConfig.GetDefaultCon());

                string sql = _response.Select;
                var results = await conn.QueryAsync<ContactResponse>(sql, new { PhoneNumbers = ContactParam.UserContacts });

                return results.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}