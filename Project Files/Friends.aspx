<%@ Page Title="" Language="C#" MasterPageFile="~/Lets_Connect.Master" AutoEventWireup="true" CodeBehind="Friends.aspx.cs" Inherits="slider.Friends" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <h1>FRIENDS</h1>
  

     <asp:DataList runat="server" ID="FriendsDataList">
        <ItemTemplate>
        <div id="myFrns">
              <div id="textAlign">
                   <asp:Label ID="Label1" Font-Size="medium" runat="server" Text=" Name:"></asp:Label>
                    <asp:LinkButton ID="F_Name" Font-Size="medium" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"First_Name") %>'></asp:LinkButton>
                    <asp:Label ID="L_Name" Font-Size="medium" runat="server"  Text='<%# Eval("Last_Name") %>'></asp:Label>
                    <br />
                   <asp:Label ID="Label2" Font-Size="medium" runat="server" Text=" Gender:"></asp:Label>
                    <asp:Label ID="Gender" Font-Size="medium" runat="server"  Text='<%# Eval("Gender") %>'></asp:Label>
                     <br />
                   <asp:Label ID="Label3" Font-Size="medium" runat="server" Text="Age:"></asp:Label>
                      <asp:Label ID="Age" Font-Size="medium" runat="server"  Text='<%# Eval("Age") %>'></asp:Label>
                     <br />
                   <asp:Label ID="Label4" Font-Size="medium" runat="server" Text="Country:"></asp:Label>
                     <asp:Label ID="Country" Font-Size="medium" runat="server"  Text='<%# Eval("Country") %>'></asp:Label>
                     <br />
                   <asp:Label ID="Label5" Font-Size="medium" runat="server" Text="E-mail:"></asp:Label>
                     <asp:Label ID="Email" Font-Size="medium" runat="server"  Text='<%# Eval("Email_ID") %>'></asp:Label>
              </div>
       </div>
            <br />
            
        </ItemTemplate>
    </asp:DataList>


</asp:Content>
