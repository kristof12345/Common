using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Common.Application.Extensions
{
    public static class EnumExtensions
    {
        public static string GetAttributeValue<TEnum>(this TEnum enumVal) where TEnum : struct
        {
            var enumType = typeof(TEnum);
            var memInfo = enumType.GetMember(enumVal.ToString());
            var attr = memInfo.First().GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();
            if (attr != null) return attr.Value;
            return string.Empty;
        }

        public static string GetAttributeValue<TEnum>(this TEnum? enumVal) where TEnum : struct
        {
            return enumVal.HasValue ? enumVal.Value.GetAttributeValue() : "";
        }

        public static T GetValueFromAttribute<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(EnumMemberAttribute)) is EnumMemberAttribute attribute)
                {
                    if (attribute.Value == description || field.Name == description) return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", nameof(description));
        }

        public static List<string> GetAttributeList<TEnum>() where TEnum : struct
        {
            return Enum.GetValues(typeof(TEnum)).Cast<Enum>().Select(val => val.GetAttribute<EnumMemberAttribute>()?.Value).ToList();
        }

        private static TAttribute GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name).GetCustomAttributes(false).OfType<TAttribute>().SingleOrDefault();
        }
    }
}