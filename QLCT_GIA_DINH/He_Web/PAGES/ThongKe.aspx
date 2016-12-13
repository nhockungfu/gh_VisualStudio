<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ThongKe.aspx.cs" Inherits="WebSite_ThongKe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="CSS\ThongKe.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="NoiDungTrangWeb" runat="Server">
    <asp:Label ID="lbNam" runat="server" Text="Năm:"></asp:Label>
    <asp:TextBox ID="tbNam" runat="server"></asp:TextBox>
    <asp:Label ID="lbOverChar" runat="server" Text="\"></asp:Label>
    <asp:Label ID="lbThang" runat="server" Text="Tháng:"></asp:Label>
    <asp:Label ID="lbChung" runat="server" Text="Tên gia đình"></asp:Label>
    <asp:TextBox ID="tbChung" runat="server"></asp:TextBox>
    <asp:Label ID="lbRieng1" runat="server" Text="Tên thành viên 1"></asp:Label>
    <asp:TextBox ID="tbRieng1" runat="server"></asp:TextBox>
    <asp:Label ID="lbRieng2" runat="server" Text="Tên thành viên 2"></asp:Label>
    <asp:TextBox ID="tbRieng2" runat="server"></asp:TextBox>
    <asp:Label ID="lbRieng3" runat="server" Text="Tên thành viên 3"></asp:Label>
    <asp:TextBox ID="tbRieng3" runat="server"></asp:TextBox>
    <asp:Label ID="lbRieng4" runat="server" Text="Tên thành viên 4"></asp:Label>
    <asp:TextBox ID="tbRieng4" runat="server"></asp:TextBox>
</asp:Content>
