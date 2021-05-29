using Newtonsoft.Json.Converters;

namespace Common.Web
{
    public class JsonDateConverter : IsoDateTimeConverter
    {
        public static string DefaultFormat { get; } = "yyyy.MM.dd.HH:mm:ss";

        public static string DefaultDateFormat { get; } = "yyyy.MM.dd.";

        public JsonDateConverter()
        {
            DateTimeFormat = DefaultFormat;
        }
    }
}
