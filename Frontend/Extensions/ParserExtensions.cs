using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Common.Web
{
    public abstract class ParserBase : JsonConverter
    {
        protected string NoneValue = "None";

        protected static readonly CultureInfo culture = new CultureInfo("en-US");

        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { throw new NotSupportedException(); }
    }

    public sealed class LongParser : ParserBase
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            if (value == NoneValue) return (long)0;
            return long.Parse(value);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }

    public sealed class DecimalParser : ParserBase
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            if (value == NoneValue) return (decimal)0;
            return decimal.Parse(value, culture);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}