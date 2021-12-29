using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Common.Web
{
    public abstract class ParserBase<T> : JsonConverter<T>
    {
        protected string NoneValue = "None";

        protected static readonly CultureInfo culture = new CultureInfo("en-US");

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }

    public sealed class LongParser : ParserBase<long>
    {
        public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (value == NoneValue) return (long)0;
            return long.Parse(value);
        }
    }

    public sealed class DecimalParser : ParserBase<decimal>
    {
        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (value == NoneValue) return (decimal)0;
            return decimal.Parse(value, culture);
        }
    }
}