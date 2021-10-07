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
//using System.IO;
//using System.Linq;
using System.Net;
using System.Net.Mail;
using AuthenticationApi.Utility;
using Newtonsoft.Json;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.Routing;
//using Twilio;
//using Twilio.Rest.Api.V2010.Account;
//using Vanso.SXMP;

namespace AuthenticationApi.Repositories
{
    public class EmailSenderImp : IEmailSender
    {
        private readonly TempaAuthContext _dbContext;

        private AppResponse _appResponse = new AppResponse();
        IUnitOfContext _IUnitOfContext;
        public EmailSenderImp(TempaAuthContext dbContext, IUnitOfContext IUnitOfContext)
        {
            _dbContext = dbContext;
            _IUnitOfContext = IUnitOfContext;
        }
        public async Task<EmailServer> ReadEmailCreadential(int Id)
        {
            var EmailServerDetails = await _dbContext.EmailServer.FindAsync(Id);
            return EmailServerDetails;
        }
        public async Task<AppResponse> SendEmail(EmailParam EmailParam, int ServerId, string WalletNo = null, string PhoneNo = null, string Amount = null, string TransRefNo = null, string Date = null)
        {
            try
            {
                var otherUserDetails = new Users();
                if (!string.IsNullOrWhiteSpace(EmailParam.OtherDetails))
                {
                    otherUserDetails = JsonConvert.DeserializeObject<Users>(EmailParam.OtherDetails);
                }

                var setup = await ReadEmailCreadential(ServerId);

                string subject =  setup.Subject.Replace("{CompanyName}", AppSettingsConfig.CompanyName());

                string mailBody = setup.BodyText;

                double PinExpireTime = AppSettingsConfig.PinExpireTime();

                if (!string.IsNullOrWhiteSpace(Amount))
                {
                    Amount = Formatter.FormattedAmount(Convert.ToDecimal(Amount));
                }
                if (!string.IsNullOrWhiteSpace(Date))
                {
                    Date = Formatter.FormatTransDate(Convert.ToDateTime(Date));
                }

                mailBody = mailBody
                            .Replace("{fullname}", EmailParam.FullName)
                            .Replace("{Pin}", EmailParam.Pin)
                            .Replace("{EmailAddress}", EmailParam.ReceiverEmail)
                            .Replace("{AcctDetails}", otherUserDetails.WalletAcct)
                            .Replace("{WalletNo}", WalletNo)
                            .Replace("{PhoneNo}", otherUserDetails.PhoneNumber)
                            .Replace("{PhoneNo}", PhoneNo)
                            .Replace("{refCode}", otherUserDetails.ReferralCode)
                            .Replace("{refCode}", otherUserDetails.ReferralCode)
                            .Replace("{TempaTag}", otherUserDetails.TempaTag)
                            .Replace("{Amount}", Amount)
                            .Replace("{TransRefNo}", TransRefNo)
                            .Replace("{Date}", Date)
                            .Replace("{TempaTag}", otherUserDetails.TempaTag)
                            .Replace("{expirePeriod}", PinExpireTime.ToString())
                            .Replace("{CompanyName}", AppSettingsConfig.CompanyName());
                

                string SenderEmail = Cryptors.Decrypt(setup.SenderEmail);
                string SenderPassword = Cryptors.Decrypt(setup.ServerPassword);

                MailMessage message = new MailMessage();
                message.To.Add(new MailAddress(EmailParam.ReceiverEmail));
                message.From = new MailAddress(SenderEmail);

                message.Subject = subject;
                message.Body = mailBody;

                message.IsBodyHtml = true;

                try
                {

                    using (var smtpclient = new SmtpClient())
                    {
                        try
                        {
                            var credential = new NetworkCredential
                            {
                                UserName = SenderEmail,
                                Password = SenderPassword
                            };

                            smtpclient.Credentials = credential;
                            smtpclient.Host = setup.ServerIP;
                            smtpclient.Port = Convert.ToInt32(setup.ServerPort);
                            smtpclient.EnableSsl = true;

                            smtpclient.Send(message);
                            _appResponse.ResponseCode = "00";
                            _appResponse.ResponseMessage = "Success";
                            return _appResponse;

                        }
                        catch (Exception ex)
                        {
                            var exM = ex == null ? ex.InnerException.Message : ex.Message;
                            
                            _appResponse.ResponseCode = "99";
                            _appResponse.ResponseMessage = "ErrorSendingEmail";

                            LogSendFailedEmail logSendFailedEmail = new LogSendFailedEmail();

                            logSendFailedEmail.Subject = message.Subject;
                            logSendFailedEmail.MailBody = message.Body;
                            logSendFailedEmail.ReceiverEmail = EmailParam.ReceiverEmail;
                            logSendFailedEmail.SenderEmail = SenderEmail;
                            logSendFailedEmail.ServerId = ServerId;
                            logSendFailedEmail.Status = "Failed";

                            await _dbContext.AddAsync(logSendFailedEmail);

                            int save = await _IUnitOfContext.Save();

                            return _appResponse;
                        }
                    }

                }
                catch (Exception ex)
                {
                    var exM = ex == null ? ex.InnerException.Message : ex.Message;
                    return _appResponse;
                }
            }
            catch (Exception ex1)
            {

                var exM1 = ex1 == null ? ex1.InnerException.Message : ex1.Message;
                return _appResponse;
            }

            return _appResponse;
        }
    }


}