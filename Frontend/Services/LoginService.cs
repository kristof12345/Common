using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Common.Application;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Common.Web
{
    public class LoginService
    {
        public event Func<Task> LoginEvent;

        private readonly HttpClient Client;

        private readonly ILocalStorageService LocalStorage;

        private readonly ISessionStorageService SessionStorage;

        public AppUser User { get; private set; }

        public LoginService(HttpClient client, ILocalStorageService localStorage, ISessionStorageService sessionStorage)
        {
            Client = client;
            LocalStorage = localStorage;
            SessionStorage = sessionStorage;
        }

        public async Task<Response> Login(LoginRequest request)
        {
            try
            {
                var response = await Client.PutAsJsonAsync("login", request);

                if (response.IsSuccessStatusCode)
                {
                    return SaveUser(await response.Content.ReadAsAsync<AppUser>());
                }

                return await response.Content.ReadAsAsync<Response>();
            }
            catch (Exception)
            {
                return new Response("Unable to connect to server: " + Client.BaseAddress);
            }
        }

        public Response SaveUser(AppUser user)
        {
            User = user;
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.Token);
            LoginEvent?.Invoke();
            return Response.Success;
        }

        public async Task Logout()
        {
            User = null;
            await SessionStorage.ClearAsync();
            await LocalStorage.ClearAsync();
            LoginEvent?.Invoke();
        }
    }
}
