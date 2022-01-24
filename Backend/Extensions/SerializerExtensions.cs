using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Common.Backend
{
    public static class SerializerExtensions
    {
        public static JsonSerializerOptions CustomSerializerOptions { get; set; }

        static SerializerExtensions()
        {
            CustomSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            CustomSerializerOptions.Converters.Add(new DateTimeParser());
        }
    }

    public class DateTimeParser : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var date = DateTime.Parse(reader.GetString());
            return DateTime.SpecifyKind(date, DateTimeKind.Utc);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy.MM.dd"));
        }
    }
}