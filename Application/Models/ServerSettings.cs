namespace Common.Application;

public class ServerSettings
{
    public static ServerSettings Instance { get; set; }

    public string Version { get; set; }

    public string BaseUrl { get; set; }

    public string RenderMode { get; set; }
}
