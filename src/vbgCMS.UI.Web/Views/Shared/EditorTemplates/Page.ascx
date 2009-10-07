<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<vbgCMS.Infrastructure.CMS.Page>" %>
<ol>
    <li>
        <label>
            Title:</label><br /><%= Html.EditorFor(c => c.Title) %></li>
</ol>
