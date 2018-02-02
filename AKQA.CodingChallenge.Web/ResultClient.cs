using System;
using System.Collections.Generic;
using System.Net;
using RestSharp;

namespace AKQA.CodingChallenge.Web
{
    public interface IResultClient
    {
        string GetAmountInWords(decimal amount);
    }
    public class ResultClient : IResultClient
    {
        private readonly RestClient _client;
        public ResultClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public string GetAmountInWords(decimal amount)
        {
            string url = $"Currency/{amount}/";
            var request = new RestRequest(url, Method.GET);
            var response = _client.Execute(request);
            return response.Content;
        }
    }
}
