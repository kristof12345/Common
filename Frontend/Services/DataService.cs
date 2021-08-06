using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Common.Web
{
    public class DataService<T>
    {
        private readonly HttpClient Http;

        public DataService(HttpClient http) { Http = http; }

        public async Task<T> LoadFromJson(string file)
        {
            return await Http.GetFromJsonAsync<T>(file);
        }
    }
}