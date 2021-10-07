using AuthenticationApi.Models;
using AuthenticationApi.ViewModel.Parameters;
using AuthenticationApi.ViewModel.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.IRepositories
{
    public interface IEmailSender
    {
        Task<AppResponse> SendEmail(EmailParam EmailParam, int EmailServerId, string WalletNo = null, string PhoneNo = null, string Amount = null, string TransRefNo = null, string Date = null);
        Task<EmailServer> ReadEmailCreadential(int Id);
        
    }
}