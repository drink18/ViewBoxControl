using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace multiViewBox
{
    public static class WildcardRegexString
    {
        /// <summary>
        /// 通配符转正则
        /// </summary>
        /// <param name="wildcardStr"></param>
        /// <returns></returns>
        public static string GetWildcardRegexString(string wildcardStr)
        {
            Regex replace = new Regex("[.$^{\\[(|)*+?\\\\]");
            return replace.Replace(wildcardStr,
                       delegate (Match m)
                       {
                           switch (m.Value)
                           {
                               case "?":
                                   return ".?";
                               case "*":
                                   return ".*";
                               default:
                                   return "\\" + m.Value;
                           }
                       }) + "$";
        }

        /// <summary>
        /// 获取通配符的正则
        /// </summary>
        /// <param name="wildcarStr"></param>
        /// <param name="ignoreCase">是否忽略大小写</param>
        /// <returns></returns>
        public static Regex GetWildcardRegex(string wildcarStr, bool ignoreCase)
        {
            if (ignoreCase)
            {
                return new Regex(GetWildcardRegexString(wildcarStr));
            }
            return new Regex(GetWildcardRegexString(wildcarStr), RegexOptions.IgnoreCase);
        }
    }
}
