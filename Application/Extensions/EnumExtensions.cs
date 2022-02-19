using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Common.Application
{
    public static class EnumExtensions
    {
        public static string GetAttributeValue<TEnum>(this TEnum enumVal) where TEnum : struct, Enum
        {
            var enumType = typeof(TEnum);
            var memInfo = enumType.GetMember(enumVal.ToString());
            var attr = memInfo.First().GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();
            return attr != null ? attr.Value : Enum.GetName(enumVal);
        }

        public static string GetAttributeValue<TEnum>(this TEnum? enumVal) where TEnum : struct, Enum
        {
            return enumVal.HasValue ? enumVal.Value.GetAttributeValue() : string.Empty;
        }

        public static TEnum GetValueFromAttribute<TEnum>(string description) where TEnum : struct, Enum
        {
            foreach (var field in typeof(TEnum).GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(EnumMemberAttribute)) is EnumMemberAttribute attribute)
                {
                    if (attribute.Value == description || field.Name == description) return (TEnum)field.GetValue(null);
                }
            }

            return Enum.Parse<TEnum>(description);
        }

        public static List<string> GetAttributeList<TEnum>() where TEnum : struct, Enum
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Select(val => val.GetAttributeValue()).ToList();
        }
    }
}