using System;
using System.Net.Http;

namespace Common.Backend;

public interface ISchedulerService
{
    void AddSingleApiCall(string url, HttpMethod method, TimeSpan interval);

    void AddRecurringApiCall(string url, HttpMethod method, string interval);
}
