﻿
namespace Wpf_Morbius.Tools
{
    public static class StringHelper
    {
        public static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static string FullName(string firstname, string name)
        {
            return StringHelper.UppercaseFirst(firstname) + " " + name.ToUpper();
        }
    }
}
