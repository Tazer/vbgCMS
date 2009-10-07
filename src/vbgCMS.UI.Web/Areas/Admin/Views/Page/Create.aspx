<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master"
    Inherits="System.Web.Mvc.ViewPage<vbgCMS.Infrastructure.CMS.Page>" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Create</h2>
    <fieldset>
        <legend></legend>
        <% using(Html.BeginForm())
	        { %>
	        <%= Html.EditorFor(c => c) %>
	    <%--<ol>
            <li>
                <label>
                    Title:</label><br />
                <%= Html.TextBox() %></li>
        </ol>--%>
        <%  } %>
    </fieldset>
</asp:Content>
