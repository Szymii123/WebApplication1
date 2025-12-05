using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace WebApplication1.Models
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var member = enumValue
                .GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault();

            if (member != null)
            {
                var displayAttribute = member
                    .GetCustomAttribute<DisplayAttribute>();

                if (displayAttribute != null)
                {
                    return displayAttribute.GetName() ?? enumValue.ToString();
                }
            }

            return enumValue.ToString();
        }
    }
}