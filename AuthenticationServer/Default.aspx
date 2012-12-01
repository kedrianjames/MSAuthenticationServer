<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="AuthenticationServer._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Start Server" />
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
            Text="Stop Server" />
        <asp:Label ID="Label2" runat="server"></asp:Label>
    </p>
</asp:Content>
