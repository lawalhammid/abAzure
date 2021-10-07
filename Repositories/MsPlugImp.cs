using AuthenticationApi.DbContexts;
using AuthenticationApi.IRepositories;
using AuthenticationApi.ViewModel.Parameters;
using AuthenticationApi.ViewModel.Responses;
using AutoMapper;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationApi.Repositories
{
    /*This class consumes the msplug  api in the website(https://www.msplug.com/)*/
    public class MsPlugImp: IMsPlug
    {
        private readonly TempaAuthContext _dbContext;

        private AppResponse _appResponse = new AppResponse();
        IUnitOfContext _IUnitOfContext;
        private readonly IMapper _mapper;

        public MsPlugImp(TempaAuthContext dbContext, IUnitOfContext IUnitOfContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _IUnitOfContext = IUnitOfContext;
            _mapper = mapper;
        }

        //This function get all the available plan for buying data 
       public async Task<IEnumerable<MsPlugGetDataPlanResponse>> GetDataPlan()
        {
            //var client = new RestClient("https://www.msplug.com/api/plans");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Authorization", "Token 5044df777830aba72999674d5e5f6e48ea55ee69");
            //request.AddHeader("Content-Type", "application/json");
            //request.AddHeader("Accept", "application/json");
            //request.AddParameter("text/plain", "", ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);

            // //var res = JsonConvert.DeserializeObject<IEnumerable<MsPlugGetDataPlanResponse>>(response.Content);
            // var client = new HttpClient();
            //// client.DefaultRequestHeaders.Add("Authorization", "Token  5044df777830aba72999674d5e5f6e48ea55ee69");

            // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", $"  5044df777830aba72999674d5e5f6e48ea55ee69");
            // // var getProperty = AppSettingsConfig.ProvidusBankCredential();

            // var url = $"https://www.msplug.com/api/plans";

            // var response = await client.GetAsync(url);

            //HttpClient httpClient = new HttpClient();
            //HttpRequestMessage request = new HttpRequestMessage();
            //request.RequestUri = new System.Uri("https://www.msplug.com/api/plans");
            //request.Method = HttpMethod.Get;
            //request.Headers.Add("Authorization", "Token 5044df777830aba72999674d5e5f6e48ea55ee69");
            //HttpResponseMessage response = await httpClient.SendAsync(request);
            //var responseString = await response.Content.ReadAsStringAsync();
            //var statusCode = response.StatusCode;

            // var client = new RestClient("https://www.msplug.com/api/plans");
            // client.Timeout = -1;
            // var request = new RestRequest(Method.GET);
            // request.AddHeader("Authorization", "Token 5044df777830aba72999674d5e5f6e48ea55ee69");
            // request.AddParameter("text/plain", "", ParameterType.RequestBody);
            // IRestResponse response = client.Execute(request);
            //var fff = response.Content;
            try
            {
                //using (var httpClient = new HttpClient())
                //{
                //    httpClient.BaseAddress = new Uri("https://www.msplug.com");
                //    httpClient.DefaultRequestHeaders.Accept.Clear();
                //    //httpClient.DefaultRequestHeaders.Authorization = new
                //       // System.Net.Http.Headers.AuthenticationHeaderValue("Token 5044df777830aba72999674d5e5f6e48ea55ee69");

                //    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Token=5044df777830aba72999674d5e5f6e48ea55ee69");

                //    HttpResponseMessage response = await httpClient.GetAsync("https://www.msplug.com/api/plans");
                //    if (response.StatusCode == HttpStatusCode.OK)
                //    {
                //        string result = await response.Content.ReadAsStringAsync();
                //        if (string.IsNullOrEmpty(result))
                //            return null;
                //        else
                //            return null;
                //    }
                //    else if (response.StatusCode == HttpStatusCode.Unauthorized)
                //    {
                //        throw new UnauthorizedAccessException();
                //    }
                //    else
                //    {
                //        throw new Exception(await response.Content.ReadAsStringAsync());
                //    }
                //}

                //var client = new RestClient("https://www.msplug.com/api/plans");
                //client.Timeout = -1;
                //var request = new RestRequest(Method.GET);
                //request.AddHeader("Authorization", "Token 5044df777830aba72999674d5e5f6e48ea55ee69");
                //request.AddParameter("text/plain", "", ParameterType.RequestBody);
                //IRestResponse response = client.Execute(request);
                //Console.WriteLine(response.Content);


                //using (WebClient wc = new WebClient())
                //{
                //    wc.Headers.Add("Content-Type", "application/json");
                //    wc.Headers.Add("Authorization", "Token 5044df777830aba72999674d5e5f6e48ea55ee69");
                //    wc.Encoding = Encoding.UTF8;
                //    var jsonRespStr = wc.DownloadString("https://www.msplug.com/api/plans");
                //}

                /* Below works airtime */
                /*
                    var client = new RestClient("https://www.msplug.com/api/buy-airtime/");
                    client.Timeout = -1;
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("Content-Type", "application/json");
                    request.AddHeader("Authorization", "Token 5044df777830aba72999674d5e5f6e48ea55ee69");
                    request.AddHeader("a8241fa9e53abf478adcb902f82313c30d6c1067", "");
                    request.AddParameter("application/json", "{\"network\":\"MTN\",\r\n\"amount\": \"100\",\r\n\"phone\":\"08063363372\",\r\n\"device_id\":\"SHIGM89U\",\r\n\"sim_slot\":\"sim1\",\r\n\"airtime_type\":\"VTU\",\r\n\"webhook_url\":\"http://www.msplug.com/buyairtime/webhook/\"\r\n}", ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
                    Console.WriteLine(response.Content);
                */

                /*Below is for data. Note: to change USSD to SMS */
                /* 
                 var client = new RestClient("https://www.msplug.com/api/buy-data/");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Token 5044df777830aba72999674d5e5f6e48ea55ee69");
                request.AddHeader("a8241fa9e53abf478adcb902f82313c30d6c1067", "");
                request.AddParameter("application/json", "{\"network\":\"MTN\",\r\n\"plan_id\": 3840,\r\n\"phone\":\"08063363372\",\r\n\"device_id\":\"SHIGM89U\",\r\n\"sim_slot\":\"sim1\",\r\n\"request_type\":\"SMS\",\r\n\"webhook_url\":\"http://www.msplug.com/buydata/webhook/\"\r\n}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                */

            }
            catch(Exception ex)
            {

            }
            return null;
            //return res;
        }

        //This function is use to buy airtime for user from login users wallet 
        public async  Task<AppResponse> BuyAirtme(MsPlugBuyAirtimeParam MsPlugBuyAirtimeParam)
        {
            string hhh = "{\"network\":\"mynetwork\",\r\n\"amount\": \"myamt\",\r\n\"phone\":\"benNo\",\r\n\"device_id\":\"SHIGM89U\",\r\n\"sim_slot\":\"sim1\",\r\n\"airtime_type\":\"VTU\",\r\n\"webhook_url\":\"http://www.msplug.com/buyairtime/webhook/\"\r\n}"
                .Replace("myamt", MsPlugBuyAirtimeParam.amount.ToString())
                .Replace("benNo", MsPlugBuyAirtimeParam.phone.ToString())
                .Replace("mynetwork", MsPlugBuyAirtimeParam.network.ToString());
           
              //Below works
              var client = new RestClient("https://www.msplug.com/api/buy-airtime/");
              client.Timeout = -1;
              var request = new RestRequest(Method.POST);
              request.AddHeader("Content-Type", "application/json");
              request.AddHeader("Authorization", "Token 5044df777830aba72999674d5e5f6e48ea55ee69");
              request.AddHeader("a8241fa9e53abf478adcb902f82313c30d6c1067", "");
              request.AddParameter("application/json", hhh, ParameterType.RequestBody);
              IRestResponse response = await client.ExecuteAsync(request);
              
            /*
            MsPlugBuyAirtimeParam.network = MsPlugBuyAirtimeParam.network.ToUpper();

             var param = JsonConvert.SerializeObject(MsPlugBuyAirtimeParam);

            var client = new RestClient("https://www.msplug.com/api/buy-airtime/");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Token 5044df777830aba72999674d5e5f6e48ea55ee69");
            request.AddHeader("a8241fa9e53abf478adcb902f82313c30d6c1067", "");
            request.AddParameter("application/json", param, ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);
            */

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return new AppResponse
                {
                     ResponseCode = "00",
                     ResponseTrueOrFalse =  true,
                     ResponseMessage = response.Content
                };
                
            }

            return new AppResponse
            {
                ResponseCode = "01",
                ResponseTrueOrFalse = false,
                ResponseMessage = response.Content
            };
        }
        public async Task<AppResponse> BuyData(MsPlugBuyDataParam MsPlugBuyDataParam)
        {
            /*Below is for data. Note: to change USSD to SMS */
            /* 
             
            var client = new RestClient("https://www.msplug.com/api/buy-data/");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Token 5044df777830aba72999674d5e5f6e48ea55ee69");
            request.AddHeader("a8241fa9e53abf478adcb902f82313c30d6c1067", "");
            request.AddParameter("application/json", "{\"network\":\"MTN\",\r\n\"plan_id\": 3840,\r\n\"phone\":\"08063363372\",\r\n\"device_id\":\"SHIGM89U\",\r\n\"sim_slot\":\"sim1\",\r\n\"request_type\":\"SMS\",\r\n\"webhook_url\":\"http://www.msplug.com/buydata/webhook/\"\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
             if (response.StatusCode == HttpStatusCode.OK)
                   {
                        return true
                   }
            Console.WriteLine(response.Content);
            */
            MsPlugBuyDataParam.request_type = "SMS";
            MsPlugBuyDataParam.webhook_url = "http://www.msplug.com/buydata/webhook";

            var param = JsonConvert.SerializeObject(MsPlugBuyDataParam);

            var client = new RestClient("https://www.msplug.com/api/buy-data/");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Token 5044df777830aba72999674d5e5f6e48ea55ee69");
            request.AddHeader("a8241fa9e53abf478adcb902f82313c30d6c1067", "");
         
            request.AddParameter("application/json", param, ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return new AppResponse
                {
                    ResponseCode = "00",
                    ResponseTrueOrFalse = true,
                    ResponseMessage = response.Content
                };

            }


            return new AppResponse
            {
                ResponseCode = "01",
                ResponseTrueOrFalse = false,
                ResponseMessage = response.Content
            };
        }
    }
}
