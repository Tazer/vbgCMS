<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<vbgCMS.Infrastructure.CMS.Page>" %>
<ol>
    <li>
        <label>
            Title:</label><br />
        <%= Html.EditorFor(c => c.Title) %></li>
    <li>
        <label>
            Slug:</label><br />
            <%= Html.TextBox("Slug", Model.Slug, new { disabled = "disabled" })%></li>
    <li>
        <label>
            Zone template:</label><br />
        <ul>
            <% foreach (var zoneTemplate in this.ZoneTemplates())
               { %>
                <li>
                <%= Html.RadioButton("zoneTemplate", zoneTemplate.Value)%>
                <label><%= zoneTemplate.Key %></label></li>     
            <% } %>
        </ul>
    </li>
</ol>
