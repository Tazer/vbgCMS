<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Install/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Completed
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Completed</h2>
    <%=ViewData["Feedback"]%>
</asp:Content>
