using AuthenticationApi.DbContexts;
using AuthenticationApi.IRepositories;
using AuthenticationApi.Models;
using AuthenticationApi.Utility;
using AuthenticationApi.ViewModel.Parameters;
using AuthenticationApi.ViewModel.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Repositories
{
    public class PinSettingsImp : IPinSettings
    {
        private readonly TempaAuthContext _dbContext;

        private AppResponse _appResponse = new AppResponse();
        IUnitOfContext _IUnitOfContext;
        public PinSettingsImp(TempaAuthContext dbContext, IUnitOfContext IUnitOfContext)
        {
            _dbContext = dbContext;
            _IUnitOfContext = IUnitOfContext;
        }

        bool IsSequential(int[] array)
        {
            return array.Zip(array.Skip(1), (a, b) => (a + 1) == b).All(x => x);
        }

        public async Task<AppResponse> UsersPin(UsersPinParam usersPinParam)
        {
            var appResponse = new AppResponse();
            try
            {
                if (!Validation.IsValidEmail(usersPinParam.EmailAddress))
                    return new AppResponse
                    {
                        ResponseCode = "01",
                        ResponseMessage = "Invalid Email Address"
                    };

                var getUSer = await _dbContext.Users.Where(c => c.EmailAddress == usersPinParam.EmailAddress).FirstOrDefaultAsync();
                if (getUSer == null)
                {
                    return new AppResponse
                    {
                        ResponseCode = "01",
                        ResponseMessage = "Invalid Email Address"
                    };
                }

               

                if(usersPinParam.Pin.Length > 4 || usersPinParam.Pin.Length < 4)
                {
                    return new AppResponse
                    {
                        ResponseCode = "01",
                        ResponseMessage = "Pin Should be 4 in length!"
                    };
                }
               
                List<int> list = new List<int>();

                foreach (var b in usersPinParam.Pin)
                {
                    list.Add(b);
                }

                if (IsSequential(list.ToArray()))
                {
                    return new AppResponse
                    {
                        ResponseCode = "01",
                        ResponseMessage = "Your Pin is too weak!"
                    };
                }

                    byte[] passwordHash, passwordSalt;
                PasswordSecurity.CreatePasswordHash(usersPinParam.Pin, out passwordHash, out passwordSalt);

                var usersPin = new UsersPin();

                usersPin.Channel = usersPinParam.Channel;
                usersPin.TempaTag = getUSer.TempaTag;
                usersPin.EmailAddress = usersPinParam.EmailAddress;
                usersPin.PasswordHash = passwordHash;
                usersPin.PasswordSalt = passwordSalt;
                usersPin.DateCreated = DateTime.Now;


                await _dbContext.AddAsync(usersPin);

                int save = await _IUnitOfContext.Save();
                if (save > 0)
                    return new AppResponse
                    {
                        ResponseCode = "00",
                        ResponseMessage = "Your pin created successfully!"
                    };

            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<AppResponse> ValidatePin(UserPinParam UserPinParam)
        {
            var appResponse = new AppResponse();
            try
            {
                var getUSer  = await _dbContext.UsersPin.Where(c => c.EmailAddress == UserPinParam.EmailAddress
                    ).FirstOrDefaultAsync();

                if (getUSer == null)
                {
                    return new AppResponse
                    {
                        ResponseCode = "01",
                        ResponseMessage = "Invalid Email Address"
                    };
                }

                if (getUSer != null)
                {
                    if (!PasswordSecurity.VerifyPasswordHash(UserPinParam.Pin, getUSer.PasswordHash, getUSer.PasswordSalt))
                    {
                        return new AppResponse
                        {
                            ResponseCode = "01",
                            ResponseMessage = "Invalid transaction details"
                        };
                    }

                    return new AppResponse
                    {
                        ResponseCode = "00",
                        ResponseMessage = "Success"
                    };

                }
            }
            catch (Exception ex)
            {
            }

            return new AppResponse
            {
                ResponseCode = "01",
                ResponseMessage = "Error"
            };
        }
   
    
    }
}