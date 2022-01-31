using System.Text.Json;

namespace Common.Application
{
    public static class Utils
    {
        public static T DeepCopy<T>(T other)
        {
            return JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(other));
        }
    }
}