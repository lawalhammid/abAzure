using AuthenticationApi.ViewModel.Responses;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Utility
{
    public static class AppSettingsConfig 
    {
        public static double  PinExpireTime()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("AppSettings.json");
            IConfiguration configuration = configurationBuilder.Build();

            return  Formatter.ValIntergers(configuration["PinExpireTime"]);
        }

        public static ProvidusBankCredentialResponse ProvidusBankCredential()
        {
            try
            {
                IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                configurationBuilder.AddJsonFile("AppSettings.json");

                IConfiguration configuration = configurationBuilder.Build();

                return new ProvidusBankCredentialResponse
                {
                    EndPoint = configuration["ProvidusBankCredential:EndPoint"],
                    UserName = Cryptors.Decrypt(configuration["ProvidusBankCredential:UserName"]),
                    Password = Cryptors.Decrypt(configuration["ProvidusBankCredential:Password"])
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static ProvidusBankVirtualServerResponse ProvidusVirtualServer()
        {
            try
            {
                IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                configurationBuilder.AddJsonFile("AppSettings.json");

                IConfiguration configuration = configurationBuilder.Build();

                return new ProvidusBankVirtualServerResponse
                {
                    UrlAcctCreation = (configuration["ProvidusBankVirtualServer:UrlAcctCreation"]),
                    ClientId = (configuration["ProvidusBankVirtualServer:Client-Id"]),
                    XAuthSign = (configuration["ProvidusBankVirtualServer:x-Auth-Sign"])
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string WEMAAcctPrefix()
        {
            try
            {
                IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                configurationBuilder.AddJsonFile("AppSettings.json");

                IConfiguration configuration = configurationBuilder.Build();
                
                string prefix = configuration["WEMABankVirtualServer:PrefixForVirtualAccount"];
                return prefix;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string GetDefaultCon()
        {
            try
            {
                IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                configurationBuilder.AddJsonFile("AppSettings.json");

                IConfiguration configuration = configurationBuilder.Build();
                string ConnectionStrings = configuration["ConnectionStrings:DatabaseConnectionString"];
             

                return ConnectionStrings;
            }
            catch (Exception ex)
            {
                var exM = ex == null ? ex.InnerException.Message : ex.Message;
               
                return String.Empty;
            }

        }

        public static string GetControllerToUse()
        {
            try
            {
                IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                configurationBuilder.AddJsonFile("AppSettings.json");

                IConfiguration configuration = configurationBuilder.Build();
                return  configuration["ActiveControllers"];


            }
            catch (Exception ex)
            {
                var exM = ex == null ? ex.InnerException.Message : ex.Message;

                return String.Empty;
            }

        }

        public static string GetTempaTeamContact()
        {
            try
            {
                IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                configurationBuilder.AddJsonFile("AppSettings.json");

                IConfiguration configuration = configurationBuilder.Build();
                return configuration["TempaContactDeveloperTeam"];


            }
            catch (Exception ex)
            {
                var exM = ex == null ? ex.InnerException.Message : ex.Message;

                return String.Empty;
            }

        }

        public static string CompanyName()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("AppSettings.json");
            IConfiguration configuration = configurationBuilder.Build();
           
           

            return configuration["CompanyName"];
        }
    }
}