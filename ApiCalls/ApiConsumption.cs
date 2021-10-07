using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using AuthenticationApi.Utility;
using Microsoft.Extensions.Logging;

namespace AuthenticationApi.ApiCalls
{
    public class ApiConsumption
    {
        //private readonly ILogger<ApiConsumption> _logger;
        //public ApiConsumption(ILogger<ApiConsumption> logger)
        //{
        //    _logger = logger;
        //}
        public async Task<string> GetObject11(string EndPointFunction, string Parameter = null)
        {
            try
            {
                var client = new HttpClient();

                var getProperty = AppSettingsConfig.ProvidusBankCredential();

                var url = $"{getProperty.EndPoint}{EndPointFunction}";

                var response = await client.GetAsync(url);

                if (response.StatusCode.ToString() == "OK")
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    return result;
                }

                return null;
            }
            catch (Exception ex)
            {
                var exM = ex.StackTrace;
                return "error";
            }

        }

        public async Task<string> GetObject(string EndPoint, string Function, string paramList = null)
        {
            try
            {
                //var client = new RestClient(EndPointAndFunction);

                //var request = new RestRequest(Method.GET);
                ////request.AddHeader("Authorization", "Basic RklSU1VTRVIwMzpkcHIwM0BmaXJz");
                //request.AddHeader("Content-Type", "application/json");
                //request.AddHeader("Accept", "application/json");
                //request.AddParameter("application/json", paramList, ParameterType.RequestBody);
                //IRestResponse response = await client.ExecuteAsync(request);

                //var client = new RestClient(EndPointAndFunction);
                //IRestResponse restResponse = client.Get(new RestRequest(resource));

                //var result = response;

                var client = new RestClient(EndPoint);
                var request = new RestRequest(Function, Method.GET);
                var result = await client.ExecuteAsync<string>(request);//.Data;

                return result.Data;
            }
            catch (Exception ex)
            {
                var exM = ex.StackTrace;
                return "error";
            }

        }
        public async Task<string> PostObject(string EndPointAndFunction, string paramList = null)
        {
            string val = string.Empty;
            try
            {
                var client = new RestClient(EndPointAndFunction);
                //client.Timeout = -1;

                var request = new RestRequest(Method.POST);
                //request.AddHeader("Authorization", "Basic RklSU1VTRVIwMzpkcHIwM0BmaXJz");
                request.AddHeader("Client-Id", "dGVzdF9Qcm92aWR1cw==");
                request.AddHeader("ClientId", "dGVzdF9Qcm92aWR1cw==");
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.AddParameter("application/json", paramList, ParameterType.RequestBody);
                IRestResponse response = await client.ExecuteAsync(request);

                var result = response.Content;


                return result = response.Content;

            }
            catch (Exception ex)
            {
                var emX = ex.StackTrace;
                return null;

            }

        }

        public async Task<string> PostVirtuObject(string EndPointAndFunction, string paramList = null)
        {
            string result = string.Empty;
            try
            {

                var getProvidusBankServer = AppSettingsConfig.ProvidusVirtualServer();

                using (var client = new HttpClient())
                {
                    string SessionID = ApiSessionGeneration.GenerateSessionID();

                    client.BaseAddress = new Uri(EndPointAndFunction);
                    client.DefaultRequestHeaders.Accept.Clear();

                    client.DefaultRequestHeaders.Add("X-Auth-Signature", getProvidusBankServer.XAuthSign);
                    client.DefaultRequestHeaders.Add("Client-Id", getProvidusBankServer.ClientId);
                    client.DefaultRequestHeaders.Add("X-CUST-SESSIONID", SessionID);

                    var stringContent = new StringContent(paramList, Encoding.UTF8, "application/json");

                    var response =  client.PostAsync(EndPointAndFunction, stringContent).Result;

                     result = await response.Content.ReadAsStringAsync();
                }

                return result;

            }
            catch (Exception ex)
            {

                //_logger.LogError($"ApiConsumption error: {ex.StackTrace}");
                return null;

            }
        }

    }

}
