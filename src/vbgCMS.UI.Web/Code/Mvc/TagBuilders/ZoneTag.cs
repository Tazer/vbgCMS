using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace vbgCMS.UI.Web.Code.Mvc.TagBuilders
{
    public class ZoneTag : IDisposable
    {
        private bool _disposed;
        private readonly HttpResponseBase _httpResponse;

        protected TagBuilder tag;

        public ZoneTag(HttpResponseBase response)
        {
            if (response == null)
                throw new ArgumentNullException("httpResponse");

            _httpResponse = response;
        }

        // Mayby not the best way :)
        public ZoneTag Build(string id, int width)
        {
            tag = new TagBuilder("div");

            tag.Attributes.Add("id", id);
            tag.Attributes.Add("style", string.Format("width:{0}%;", width));
            tag.AddCssClass("zone");

            _httpResponse.Write(tag.ToString(TagRenderMode.StartTag));

            return this;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                _httpResponse.Write(tag.ToString(TagRenderMode.EndTag));
            }
        }

        public void EndZone()
        {
            Dispose(true);
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}
