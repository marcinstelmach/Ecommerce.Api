using System;
using Streetwood.Core.Domain.Enums;

namespace Streetwood.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string GetName(this UserType userType)
        {
             return Enum.GetName(typeof(UserType), userType);
        }
    }
}
