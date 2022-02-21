using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Common.Application;

public static class EnumExtensions
{
    public static List<string> GetAttributeList<TEnum>()
    {
        return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Select(val => val.GetAttributeValue()).ToList();
    }

    public static string GetAttributeValue<TEnum>(this TEnum enumVal)
    {
        var enumType = typeof(TEnum);
        var memInfo = enumType.GetMember(enumVal.ToString());
        var attr = memInfo.First().GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();
        return attr != null ? attr.Value : Enum.GetName(typeof(TEnum), enumVal);
    }

    public static TEnum GetValueFromAttribute<TEnum>(string description)
    {
        foreach (var field in typeof(TEnum).GetFields())
        {
            if (Attribute.GetCustomAttribute(field, typeof(EnumMemberAttribute)) is EnumMemberAttribute attribute)
            {
                if (attribute.Value == description || field.Name == description) return (TEnum)field.GetValue(null);
            }
        }

        return (TEnum)Enum.Parse(typeof(TEnum), description);
    }
}
