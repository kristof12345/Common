using System.Text.Json;

namespace Common.Web
{
    public class JsonDateConverter 
    {
        public static string DefaultFormat { get; } = "yyyy.MM.dd.HH:mm:ss";

        public static string DefaultDateFormat { get; } = "yyyy.MM.dd.";

        public JsonDateConverter()
        {
            
        }
    }
}
