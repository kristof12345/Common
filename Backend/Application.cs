namespace Common.Backend;

public static class App
{
    public static string Url { get; set; }

    public static string Environment { get; set; }

    //public static TokenSettings TokenSettings { get; set; }

    public static IServiceProvider Services { get; set; }
}
