<%@ Page Title="" Language="C#" MasterPageFile="~/Lets_Connect.Master" AutoEventWireup="true" CodeBehind="Photos.aspx.cs" Inherits="slider.Photos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Photos</h1>



     <asp:FileUpload ID="ImageUploadToDB" Width="300px" runat="server" />
        <asp:Button ID="btnUploadImage" runat="server" Text="Upload Photo" OnClick="SAVE_IMAGE"
            ValidationGroup="vg" />
    <br />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" onclick="LOAD_IMAGE" 
        Text="Show Images" />
        <br />
    
    <br />
        </br>

   
    <asp:DataList ID="PhotosDataList" runat="server"  RepeatDirection="Vertical">
            <ItemTemplate>
                 <asp:Image ID="Image1" Width="600px" Height="200px" runat ="server"   ImageUrl='<%# Eval("URL") %>'/>
                <br />
                <br />
            </ItemTemplate>
        </asp:DataList>
    
   

              

    <br />

    <br />
    <br />
    <br />

    <br />
    <br />
     <br />

    <br />
    <br />



  
   
  
</asp:Content>



