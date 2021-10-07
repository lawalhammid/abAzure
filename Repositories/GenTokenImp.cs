using AuthenticationApi.IRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationApi.Repositories
{
    public class GenTokenImp : IGenToken
    {
        public async Task<object> GenNewToken()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("AppSettings.json");
            IConfiguration configuration = configurationBuilder.Build();

            string SignInkey = configuration["JsW:ke"];
            string expiryTime = configuration["JsW:expTime"];
            string issuer = configuration["JsW:ww"];

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SignInkey));

            int exPiryInMinute = Convert.ToInt32(expiryTime);
            var ttt = DateTime.UtcNow.AddMinutes(exPiryInMinute);
            string month = string.Empty, day = string.Empty;
            if (ttt.Month < 10)
            {
                month = "0" + ttt.Month;
            }
            else
            {
                month = ttt.Month.ToString();
            }
            if (ttt.Day < 10)
            {
                day = "0" + ttt.Day;
            }
            else
            {
                day = ttt.Day.ToString();
            }

            var expiryDayTime = $"{ttt.Year}-{month}-{day} {ttt:HH:mm:ss}";

            var token =   new JwtSecurityToken(
                           issuer: issuer,
                           audience: issuer,
                           expires: DateTime.UtcNow.AddMinutes(exPiryInMinute),
                           signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)

                            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
