<%@ Page Title="" Language="C#" MasterPageFile="~/Lets_Connect.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="slider.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="coda-slider.css" />


    <h1>SEARCH</h1>

    <br />
    <br />
    <asp:TextBox ID="SearchBox" CssClass="txtBoxes" placeholder="You can Find friends from here." runat="server" Width="247px"></asp:TextBox>&nbsp&nbsp

     <asp:Button ID="SearchButton" runat="server" CssClass="addfriend" ForeColor="Wheat" Text="Search" Width="119px" OnClick="Search_Button_Click" />
    <asp:TextBox runat="server" ID="UserEmail" CssClass="txtBoxes" placeHolder="Copy Users Email here & Click on Add as Friend"></asp:TextBox>
     <div id="message" runat="server">
    </div>

    <asp:DataList runat="server" ID="SearchDataList">
        <ItemTemplate>
            <div id="search">
                   <asp:label ID="name" Font-Size="Medium" runat="server">Name:</asp:label> 
                        <asp:LinkButton Font-Size="Medium" ID="F_Name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"First_Name") %>'></asp:LinkButton>
                    <asp:Label ID="L_Name" Font-Size="Medium" runat="server"  Text='<%# Eval("Last_Name") %>'></asp:Label>
                    <br />
                   
                    <asp:Label ID="Genderlbl" Font-Size="Medium" runat="server" Text="Label">Gender: </asp:Label>
                        <asp:Label ID="Gender" Font-Size="Medium" runat="server"  Text='<%# Eval("Gender") %>'></asp:Label>
                     <br />
                 <asp:Label ID="countrylbl" font-size="Medium" runat="server">Country: </asp:Label>   
                        <asp:Label ID="Country" Font-Size="Medium" runat="server"  Text='<%# Eval("Country") %>'></asp:Label>
                     <br />
                  <asp:Label ID="emaillbl" Font-Size="Medium" runat="server">E-mail:</asp:Label>   
                        <asp:Label ID="Email" Font-Size="Medium" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem,"Email_ID") %>'></asp:Label>
                <br />
                <br />
                    <div id="add">
                            <asp:Button ID="AddFriend" CssClass="addfriend" ForeColor="Wheat" runat="server" Text="Add as Friend" onclick="Add_Friend"/>
                    </div>
            </div>
            <br />
        </ItemTemplate>
    </asp:DataList>


</asp:Content>
