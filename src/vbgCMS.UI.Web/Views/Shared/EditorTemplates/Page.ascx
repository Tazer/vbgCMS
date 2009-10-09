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
                <%-- Make checked nicer --%>
                <%= Html.RadioButton("zoneTemplate", zoneTemplate.Value, zoneTemplate.Value == "100")%>
                <label><%= zoneTemplate.Key %></label></li>     
            <% } %>
        </ul>
    </li>
</ol>
