using System;
using System.Net.Http;
using System.Threading.Tasks;
using Common.Application;

namespace Common.Web
{
    public class UserService<IUser>
    {
        private readonly HttpClient Client;

        private const string url = "/users/";

        public UserService(HttpClient client)
        {
            Client = client;
        }

        public async Task<IUser> Find(string id)
        {
            var response = await Client.GetAsync(url + id);
            return await response.Content.ReadAsAsync<IUser>();
        }

        public async Task<PagedResult<IUser>> Search(string username, int page)
        {
            var range = new Span((page - 1) * Span.PageSize, Span.PageSize);
            var response = await Client.GetAsync(url + range + "&username=" + username);
            return await response.Content.ReadAsAsync<PagedResult<IUser>>();
        }

        public async Task<Response> Create(IUser user)
        {
            var response = await Client.PostAsJsonAsync(url, user);
            if (response.IsSuccessStatusCode) return Response.Success;
            return await response.Content.ReadAsAsync<Response>();
        }

        public async Task<Response> ChangePassword(ChangePasswordRequest request)
        {
            var response = await Client.PatchAsJsonAsync(url, request);
            if (response.IsSuccessStatusCode) return Response.Success;
            return await response.Content.ReadAsAsync<Response>();
        }

        public async Task<Response> Delete(string username)
        {
            var response = await Client.DeleteAsync(url + username);
            if (response.IsSuccessStatusCode) return Response.Success;
            return await response.Content.ReadAsAsync<Response>();
        }

        public async Task<Response> UploadProfile(MultipartFormDataContent file, string username)
        {
            if (file == null) return new Response("File was empty.");
            var response = await Client.PostAsync(url + username + "/profile", file);
            return await response.Content.ReadAsAsync<Response>();
        }
    }
}