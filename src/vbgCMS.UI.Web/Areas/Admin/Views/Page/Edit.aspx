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
</asp:Content>