using RestSharp;
using System;
using System.Net;

namespace BTC.BlockChainAPI
{
    public static class APIBlockChain
    {
        private static readonly RestClient client = new RestClient
        {
            BaseUrl = new Uri("https://blockchain.info")
        };
        public static string GetBlockToHash(string blockHash, out HttpStatusCode httpStatusCode)
        {
            RestRequest request = new RestRequest
            {
                Resource = $@"/rawblock/{blockHash}"
            };
            RestResponse response = client.Execute(request) as RestResponse;
            httpStatusCode = response.StatusCode;
            return response.Content;
        }
        public static string GetBlockToHeight(long blockHeight, out HttpStatusCode httpStatusCode)
        {
            RestRequest request = new RestRequest
            {
                Resource = $@"/block-height/{blockHeight}?format=json"
            };
            RestResponse response = client.Execute(request) as RestResponse;
            httpStatusCode = response.StatusCode;
            return response.Content;
        }
        public static string GetLatestBlocks(out HttpStatusCode httpStatusCode)
        {
            RestRequest request = new RestRequest
            {
                Resource = $@"/block-height/?format=json"
            };
            RestResponse response = client.Execute(request) as RestResponse;
            httpStatusCode = response.StatusCode;
            return response.Content;
        }
    }
}
