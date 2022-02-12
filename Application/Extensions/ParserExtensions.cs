using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Common.Application
{
    public abstract class ParserBase<T> : JsonConverter<T>
    {
        protected string NoneValue = "None";

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
            return value == NoneValue ? 0 : long.Parse(value);
        }
    }

    public sealed class DecimalParser : ParserBase<decimal>
    {
        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return value == NoneValue ? 0 : decimal.Parse(value, new CultureInfo("en-US"));
        }
    }

    public sealed class CapitalizeParser : ParserBase<string>
    {
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return value.Capitalize();
        }
    }

    public sealed class TimeParser : ParserBase<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dateTime.AddSeconds(long.Parse(value));
        }
    }
}