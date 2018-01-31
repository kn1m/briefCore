namespace briefCore.Controllers.Extensions
{
    using System;
    using System.Collections.Generic;

    public static class DictionaryExtensions
    {
        public static string GetString(this Dictionary<string, string> dictionary)
        {
            var result = string.Empty;

            foreach (var entry in dictionary)
            {
                result += entry.Key + ": " + entry.Value + Environment.NewLine;
            }

            return result;
        }
    }
}