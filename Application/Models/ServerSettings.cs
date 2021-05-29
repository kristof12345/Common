namespace Common.Application.Models
{
    public class ServerSettings
    {
        public static ServerSettings Instance { get; set; }

        public string BaseUrl { get; set; }
    }
}
