using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vbgCMS.UI.Web.Code
{
    public static class KeyManager
    {
        //Maby not use session because of scaling purposes.
        //public static class Session
        //{

        //}

        public static class ViewData
        {
            public const string CurrentSite = "CurrentSite";
            public const string ZoneTemplatesList = "ZoneTemplatesList";
        }

        public static class QueryStrings
        {

        }
    }
}
