﻿using AdfToArm.Core.Logs;
using System;
using System.Linq;
using System.Runtime.Serialization;

namespace AdfToArm.Core
{
    public static class EnumExtensions
    {
        public static T ToEnum<T>(this string str)
        {
            var enumType = typeof(T);
            foreach (var name in Enum.GetNames(enumType))
            {
                var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name)
                    .GetCustomAttributes(typeof(EnumMemberAttribute), true))
                    .Single();

                if (enumMemberAttribute.Value == str)
                    return (T)Enum.Parse(enumType, name);
            }

            Logger.Instance.Error($"Unable to get {enumType.Name} from {str}");
            throw new AdfParseException($"Unable to get {enumType.Name} from {str}");
        }
    }
}
