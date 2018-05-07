<%@ Page Title="" Language="C#" MasterPageFile="~/Lets_Connect.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="slider.Messages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <h1>MESSAGES</h1>
  

     <asp:DataList runat="server" ID="MessagesDataList">
        <ItemTemplate>
          
            Name: <asp:LinkButton ID="F_Name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"First_Name") %>'></asp:LinkButton>
           
           &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
           
            sent On: <asp:Label ID="Date" runat="server"  Text='<%# Eval("DateAndTime") %>'></asp:Label>
             <br />
           <asp:Label ID="Message" runat="server"  Text='<%# Eval("Message") %>'></asp:Label>
       
        </ItemTemplate>
            </asp:DataList>











</asp:Content>
