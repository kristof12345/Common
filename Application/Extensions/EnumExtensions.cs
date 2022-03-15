using System.Runtime.Serialization;

namespace Common.Application;

public static class EnumExtensions
{
    public static IEnumerable<string> GetAttributeList<TEnum>()
    {
        return Enum.GetValues(GetEnumType<TEnum>()).Cast<TEnum>().Select(val => val.GetAttributeValue());
    }

    public static string GetAttributeValue<TEnum>(this TEnum enumVal)
    {
        if (enumVal == null) return string.Empty;
        var type = GetEnumType<TEnum>();
        var memInfo = type.GetMember(enumVal.ToString());
        if (memInfo.Empty()) return Enum.GetName(type, enumVal);
        var attr = memInfo.First().GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();
        return attr != null ? attr.Value : Enum.GetName(type, enumVal);
    }

    public static TEnum GetValueFromAttribute<TEnum>(string description)
    {
        foreach (var field in GetEnumType<TEnum>().GetFields())
        {
            if (Attribute.GetCustomAttribute(field, typeof(EnumMemberAttribute)) is EnumMemberAttribute attribute)
            {
                if (attribute.Value == description || field.Name == description) return (TEnum)field.GetValue(null);
            }
        }

        return (TEnum)Enum.Parse(GetEnumType<TEnum>(), description);
    }

    private static Type GetEnumType<TEnum>()
    {
        return Nullable.GetUnderlyingType(typeof(TEnum)) ?? typeof(TEnum);
    }
}
