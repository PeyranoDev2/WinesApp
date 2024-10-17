using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class EnumExtensions
    {
        public static string ToFriendlyString(this Enum value)
        {
            return value.ToString().Replace("_", " "); 
        }
    }
}