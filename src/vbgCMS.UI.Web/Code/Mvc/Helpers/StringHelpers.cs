using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace vbgCMS.UI.Web.Code.Mvc.Helpers
{
    public static class StringHelpers
    {
        public static string ToSlugString(this string source)
        {
            var regex = new Regex(@"([^a-z0-9\-]?)");
            string slug = "";

            if (!string.IsNullOrEmpty(source))
            {
                slug = source.Trim().ToLower();
                slug = slug.Replace(' ', '-');
                slug = slug.Replace("---", "-");
                slug = slug.Replace("--", "-");
                if (regex != null)
                    slug = regex.Replace(slug, "");

                if (slug.Length * 2 < source.Length)
                    return "";

                if (slug.Length > 100)
                    slug = slug.Substring(0, 100);
            }

            return HttpUtility.UrlEncode(slug);
        }
    }
}
