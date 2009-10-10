<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<vbgCMS.Infrastructure.CMS.Page>" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Edit</h2>
    
    <%= Html.ValidationSummary() %>
        
    <fieldset>
        <legend></legend>
        <% using(Html.BeginForm())
	        { %>
	        <%= Html.EditorFor(c => c) %>
	        
	        <p><input type="submit" value="Save" /></p>
        <%  } %>
    </fieldset>
    <div id="Edit">
    <% foreach (var zone in Model.Zones)
       {
           using (Html.BeginZone(zone))
           { %>
            <ul>
                <li><%= Html.Image("~/Content/Images/ajax-loader.gif", new { alt = "loading..." })%></li>
            </ul>
        <% }
       } %>
    </div>
</asp:Content>