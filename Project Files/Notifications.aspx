<%@ Page Title="Notifications" Language="C#" MasterPageFile="~/Lets_Connect.Master" AutoEventWireup="true" CodeBehind="Notifications.aspx.cs" Inherits="slider.Notifications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function Change() {
            document.getElementById("Button4").style.backgroundColor = "Green";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



     <h1>Notifications</h1>



    <asp:TextBox runat="server" ID="UserEmail" CssClass="txtBoxes" placeHolder="Copy Users Email here & Click on the Button of your choice"></asp:TextBox>
     <asp:DataList runat="server" ID="NotificationsDataList">
        <ItemTemplate>
       
                    <asp:LinkButton ID="SenderName" Font-Size="medium" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"First_Name") %>'></asp:LinkButton>
                     &nbsp sent you a Friend Request&nbsp
            Email: <asp:Label ID="Email" Font-Size="Medium" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem,"Email_ID") %>'></asp:Label>
              
             <asp:Button ID="Accept" runat="server" CssClass="addfriend" ForeColor="Wheat" Text="Accept" Width="119px"  />
            &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
             <asp:Button ID="Decline" runat="server" CssClass="addfriend" ForeColor="Wheat" Text="Decline" Width="119px"  />
    
              
                 <br />
            
        </ItemTemplate>
    </asp:DataList>


</asp:Content>
