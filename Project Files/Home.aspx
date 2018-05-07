<%@ Page Title="" Language="C#" MasterPageFile="~/Lets_Connect.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="slider.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <link rel="stylesheet" type="text/css" href="coda-slider.css" />

    <h1>HOME</h1>
  
  
        <h2>  Update Status</h2>

        <asp:TextBox ID="writeStatus" CssClass="txtBoxes1" runat="server" placeholder="What's on your mind?" style="width: 600px;	height:200px; position:absolute; resize:none" TextMode="MultiLine">


        
        </asp:TextBox>

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
       
        <asp:Button ID="PostButton" CssClass="buttonCss1" runat="server" Text="Post" Width="119px" OnClick="UpdateStatus"/> 
        <br />
    <br /> 

<asp:DataList runat="server" ID="StatusDataList">
        
       <ItemTemplate>
            <div id="status">
                                <div id="name">
                     <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="true" Font-Size="Large" Font-Underline="true" Text='<%# DataBinder.Eval(Container.DataItem,"First_Name") %>'></asp:LinkButton>
                </div>
                    <div id ="time1">
                            <asp:Label runat="server" ID="time" ForeColor="whitesmoke"  Text='<%# Eval("DateAndTime") %>'></asp:Label>
                    </div>
                <br />
                <br />
                <div id="statement">
                    <asp:Label runat="server" Font-Size="Larger" Width="600px" ForeColor="whitesmoke" ID="description" Text='<%# Eval("Statement") %>'></asp:Label>
                </div>
               
               <!-- <div id="like">
                    <asp:Button ID="Button2" CssClass="buttonCss1" ForeColor="Wheat" runat="server" Text="Like" />
                    <asp:TextBox ID="likecount" Height="10px" Width="10px" runat="server"></asp:TextBox>
                </div> -->
            </div>
            <br />
        </ItemTemplate>
    </asp:DataList>
         
  
</asp:Content>
