using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Common.Application;

namespace Common.Backend;

public static class SerializerExtensions
{
    public static JsonSerializerOptions CustomSerializerOptions { get; set; }

    static SerializerExtensions()
    {
        CustomSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        CustomSerializerOptions.Converters.Add(new DateParser());
    }
}

public abstract class ParserBase<T> : JsonConverter<T>
{
    protected string NoneValue = "None";

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}

public sealed class IntParser : ParserBase<int>
{
    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = (int)reader.GetDecimal();
        return value;
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

public class DateParser : ParserBase<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var date = DateTime.Parse(reader.GetString());
        return DateTime.SpecifyKind(date, DateTimeKind.Utc);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(Format.DateFormat));
    }
}

public sealed class TimeParser : ParserBase<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetInt64();
        var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        return dateTime.AddSeconds(value);
    }
}
