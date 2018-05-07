<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sign_Up.aspx.cs" Inherits="slider.Sign_Up" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
        <link rel="stylesheet" type="text/css" href="Sign_UpCSS.css" />

    <title>Sign Up | Let's Connect</title>

    <!--    Script for Checking various User Data Fields    -->
          
    <script type="text/javascript">

        function Submit() {


            if (document.getElementById('First_Name').value == "")
            {
                alert("First Name shouldn't be empty");
            }
            else
                if (checkName(document.getElementById('First_Name').value))
                {

                    if (document.getElementById('Last_Name').value == "")
                        alert("Last Name shouldn't be empty");

                    else if (checkName(document.getElementById('Last_Name').value))
                    {
                        if (!(document.getElementById('Male_Button').checked || document.getElementById('Female_Button').checked)) {
                            alert("Provide A Gender");
                        }

                        else if (document.getElementById("Days_List").Value == "0" || document.getElementById("Month_List").Value == "0" || document.getElementById("Year_List").Value == "0") {
                            alert("Complete Date of Birth is Missing");
                        }

                        else if (document.getElementById('Email').value == "")
                            alert("Provide an E-mail");

                        else if (document.getElementById('Password').value == "")
                            alert("Password shouldn't be empty");

                        else if (document.getElementById('Re_Password').value == "")
                            alert("Re-enter the password");

                        else {
                            password = document.getElementById('Password').value;
                            re_password = document.getElementById('Re_Password').value;
                            if (password != re_password)
                                alert("Passwords don't match");
                            else if (!checkEmail(document.getElementById('Email').value))
                                alert("Invalid E-mail");
                            else {
                                document.getElementById("ValueHiddenField1").value = "1";
                                return;
                            }
                        }
                    }
                }
            document.getElementById("ValueHiddenField1").value = "0";
        }

        function checkName(name) {
            length = name.length;
            for (i = 0; i < length; i++)
                if ((name[i] < 'A' || name[i] > 'Z') && (name[i] < 'a' || name[i] > 'z')) {
                    alert("Name can only contain alphabets");
                    return false;
                }
            return true;
        }

        function checkEmail(email) {
            length = email.length;
            for (i = 0; i < length; i++) {
                if (email[i] == '@')
                    break
            }
            if (i != length) {
                i++;
                if ((email[i] < 'A' || email[i] > 'Z') && (email[i] < 'a' || email[i] > 'z'))
                    return false;
                else {
                    com = ".com"
                    for (i; i < length; i++) {
                        for (j = 0, k = i; j < 4; j++, k++)
                            if (email[k] != com[j])
                                break;
                        if (j == 4)
                            break;
                    }
                    if (i != length)
                        return true;
                    else
                        return false;
                }

            }
            else
                return false;
        }

    </script>                     


</head>

<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="ValueHiddenField1" />

        <div>

            <div style="float:left;">
            <video width="500" height="500" controls >
                <source src="vd.mp4" type="video/mp4">
                <object data="vd.mp4" width="320" height="240">
                    <embed width="320" height="240" src="vd.mp4">
                </object>
            </video>

            </div>

            <div class="pad">
                <asp:TextBox ID="First_Name" Class="txtBoxesOrange" runat="server" placeholder="First Name"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox ID="Last_Name" Class="txtBoxesOrange" runat="server" placeholder="Last Name"></asp:TextBox>
                <br />
                <br />

                I am: 
             &nbsp&nbsp&nbsp 
             <asp:RadioButton ID="Male_Button" GroupName="Gender" runat="server" />
                Male
             &nbsp&nbsp&nbsp 
             <asp:RadioButton ID="Female_Button" GroupName="Gender" runat="server" />
                Female
             <br />
                <br />

                Date of Birth
                <br />
                <br />

                <asp:DropDownList ID="Days_List" runat="server">
                    <asp:ListItem Text="Select Day" Value="0"></asp:ListItem>

                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                    <asp:ListItem Text="13" Value="13"></asp:ListItem>
                    <asp:ListItem Text="14" Value="14"></asp:ListItem>
                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                    <asp:ListItem Text="16" Value="16"></asp:ListItem>
                    <asp:ListItem Text="17" Value="17"></asp:ListItem>
                    <asp:ListItem Text="18" Value="18"></asp:ListItem>
                    <asp:ListItem Text="19" Value="19"></asp:ListItem>
                    <asp:ListItem Text="20" Value="20"></asp:ListItem>
                    <asp:ListItem Text="21" Value="21"></asp:ListItem>
                    <asp:ListItem Text="22" Value="22"></asp:ListItem>
                    <asp:ListItem Text="23" Value="23"></asp:ListItem>
                    <asp:ListItem Text="24" Value="24"></asp:ListItem>
                    <asp:ListItem Text="25" Value="25"></asp:ListItem>
                    <asp:ListItem Text="26" Value="26"></asp:ListItem>
                    <asp:ListItem Text="27" Value="27"></asp:ListItem>
                    <asp:ListItem Text="28" Value="28"></asp:ListItem>
                    <asp:ListItem Text="29" Value="29"></asp:ListItem>
                    <asp:ListItem Text="30" Value="30"></asp:ListItem>
                    <asp:ListItem Text="31" Value="31"></asp:ListItem>

                </asp:DropDownList>


                <asp:DropDownList ID="Month_List" runat="server">
                    <asp:ListItem Text="Select Month" Value="0"></asp:ListItem>
                    <asp:ListItem Text="January" Value="Jan"></asp:ListItem>
                    <asp:ListItem Text="February" Value="Feb"></asp:ListItem>
                    <asp:ListItem Text="March" Value="Mar"></asp:ListItem>
                    <asp:ListItem Text="April" Value="Apr"></asp:ListItem>
                    <asp:ListItem Text="May" Value="May"></asp:ListItem>
                    <asp:ListItem Text="June" Value="Jun"></asp:ListItem>
                    <asp:ListItem Text="July" Value="Jul"></asp:ListItem>
                    <asp:ListItem Text="August" Value="Aug"></asp:ListItem>
                    <asp:ListItem Text="September" Value="Sep"></asp:ListItem>
                    <asp:ListItem Text="October" Value="Oct"></asp:ListItem>
                    <asp:ListItem Text="November" Value="Nov"></asp:ListItem>
                    <asp:ListItem Text="December" Value="Dec"></asp:ListItem>
                </asp:DropDownList>


                <asp:DropDownList ID="Year_List" runat="server">
                    <asp:ListItem Text="Select Year" Value="0"></asp:ListItem>
                    <asp:ListItem Text="1998" Value="1998"></asp:ListItem>
                    <asp:ListItem Text="1997" Value="1997"></asp:ListItem>
                    <asp:ListItem Text="1996" Value="1996"></asp:ListItem>
                    <asp:ListItem Text="1995" Value="1995"></asp:ListItem>
                    <asp:ListItem Text="1994" Value="1994"></asp:ListItem>
                    <asp:ListItem Text="1993" Value="1993"></asp:ListItem>
                    <asp:ListItem Text="1992" Value="1992"></asp:ListItem>
                    <asp:ListItem Text="1991" Value="1991"></asp:ListItem>
                    <asp:ListItem Text="1990" Value="1990"></asp:ListItem>

                </asp:DropDownList>

                <br />
                
                <br />
                <asp:TextBox ID="Email" Class="txtBoxesOrange" runat="server" placeholder="Email"></asp:TextBox>
                <br />
                <br />

                <asp:TextBox ID="Password" type="password" Class="txtBoxesOrange" runat="server" placeholder="Password"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox ID="Re_Password" type="password" Class="txtBoxesOrange" runat="server" placeholder="Confirm Password"></asp:TextBox>
                <br />
                <br />

                <asp:Button ID="Sign_up" Class="signUp_button" OnClick="Sign_Up_Button_Click" runat="server" Text="Sign Up" />

            <br />
                <br/>
      <p id="message" runat="server" style="color:blanchedalmond; font-style:italic; font-family:Constantia">
        </p>
            <br />
            </div>



        </div>
    </form>
</body>
</html>

