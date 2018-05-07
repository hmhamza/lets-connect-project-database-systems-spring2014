<%@ Page Title="Friend Request" Language="C#" MasterPageFile="~/Lets_Connect.Master" AutoEventWireup="true" CodeBehind="AddFriends.aspx.cs" Inherits="slider.AddFriends" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Friend Request</h1>
    <link rel="stylesheet" type="text/css" href="coda-slider.css" />
    
    <div>
        <asp:TextBox id="msg" CssClass="txtBoxes1" runat="server" TextMode="MultiLine" placeholder="Type your message here."></asp:TextBox>
    </div>
    <br />
    <div>
        <asp:Button ID="SendMsg" CssClass="buttonCss1" ForeColor="Wheat" runat="server" Text="Send" OnClick="Add_Friend" />
    </div>

    </asp:Content>