<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master"
    Inherits="System.Web.Mvc.ViewPage<System.Collections.Generic.IEnumerable<vbgCMS.Infrastructure.CMS.Page>>" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <table>
        <thead>
            <tr>
                <th>
                    Id
                </th>
                <th>
                    Title
                </th>
                <th>
                </th>
            </tr>
        </thead>
        <tbody>
            <% if (Model.IsEmpty())
               { %>
               <tr><td colspan="3">There is no pages.</td></tr>
            <% } %>
            <% foreach (var page in Model)
               { %>
            <tr>
                <td>
                    <%= page.Id %>
                </td>
                <td>
                    <%= page.Title %>
                </td>
                <td>
                    <a>Edit</a>
                </td>
            </tr>
            <% } %>
        </tbody>
    </table>
    <br />
    <a href="/Admin/Page/Create">Create a page</a>
</asp:Content>
