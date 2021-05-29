using System;
using System.Net.Http;
using Common.Application.Models;

namespace Common.Web
{
    public class AppService
    {
        public HttpClient InvestmentClient { get; private set; }

        public AppService(ServerSettings settings)
        {
            InvestmentClient = new HttpClient { BaseAddress = new Uri(settings.BaseUrl) };
        }
    }
}
