<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<vbgCMS.Infrastructure.CMS.Page>" %>
<ol>
    <li>
        <label>
            Title:</label><br />
        <%= Html.EditorFor(c => c.Title) %></li>
    <li>
        <label>
            Zone template:</label><br />
        <ul>
            <% foreach (var zoneTemplate in new Dictionary<string, string>() { { "1 Column", "100" }, { "2 Column(50/50)", "48;48" }, { "2 Column(30/70)", "28;68" }, { "1 Column(100) + 2 Column(30/70)", "100;28;68" } })
               { %>
                <li>
                <%= Html.RadioButton("zoneTemplate", zoneTemplate.Value)%>
                <label><%= zoneTemplate.Key %></label></li>     
            <% } %>
        </ul>
    </li>
</ol>
