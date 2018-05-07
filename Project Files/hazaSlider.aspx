<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hazaSlider.aspx.cs" Inherits="slider.hazaSlider" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <link rel="stylesheet" type="text/css" href="Sign_InCSS1.css" />

    <title>Let's Connect</title>

    <!-- First, add jQuery (and jQuery UI if using custom animation -->
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>


    <!-- Second, add the Slider Control and Animation plugins -->
    <script src="../Scripts/jquery.SliderControl.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.SliderAnimation.js" type="text/javascript"></script>


    <!-- Third, add the GalleryView Javascript and CSS files -->
    <link href="../Styles/jquery.ImageSliderGalleryview.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.ImageSliderGalaryView.js" type="text/javascript"></script>


        <script type="text/javascript">
            $(function () {
                $('#sliderImageGallery').galleryView({
                    transition_speed: 2000,
                    transition_interval: 5000,
                    panel_width: 1220,
                    panel_height: 300,
                    frame_width: 90,
                    frame_height: 60,
                    show_panels: true,
                    show_panel_nav: true,
                    enable_overlays: false,
                    easing: 'swing',
                    panel_animation: 'slide',
                    panel_scale: 'crop',
                    show_filmstrip: false,
                    infobar_opacity: 5.0,
                    enable_slideshow: true,
                    autoplay: true,

                });
            });


    </script>

    <script type="text/javascript">

        function Submit() {

            if (document.getElementById('Email').value == "")
                alert("Enter an E-mail");
            else if (!checkEmail(document.getElementById('Email').value))
                alert("Enter the correct Email");
            else if (document.getElementById('Password').value == "")
                alert("Enter a Password");
            else {
                document.getElementById('ValueHiddenField').value = "1";
                return;
            }
            document.getElementById('ValueHiddenField').value = "0";
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
        <asp:HiddenField id="ValueHiddenField" runat="server"/>

        <span style="  text-shadow: 12px 5px 2px #ffa853; padding-left:10px;   color: white; font: 35px snap ITC; float: left;">Let's Connect.</span>

        <span style=" padding-right:7px; color: white; display: block; font: 35px Segoe Marker; float: right;">Where You Connect!!!</span>


        <div class="slider" >
            <ul id="sliderImageGallery">
                <li>
                    <img src="../I/5.jpg" alt="image1" title="Lone Tree Yellowstone" data-description="A solitary tree" /></li>
                <li>
                    <img src="../I/2.jpg" alt="image2" /></li>
                <li>
                    <img src="../I/4.jpg" alt="image3" /></li>
                <li>
                    <img src="../I/3.jpg" alt="image4" /></li>
                <li>
                    <img src="../I/1.jpg" alt="image5" /></li>
             
                   <%--<li>
                    <img src="../Images/SlidingImage/5.jpg" alt="image5" /></li>--%>
              
            </ul>
        </div>
        <!-- Slider -->

        <div align="center">
            <br/>
         <br/>
        <asp:TextBox ID="Email" Class="txtBoxes" runat="server" placeholder="Email"></asp:TextBox>
            <br/>
        <br/>
        <asp:TextBox ID="Password" type="password" Class="txtBoxes" runat="server" placeholder="Password"></asp:TextBox>
            <br/>
      <p id="message" runat="server" style="color:blanchedalmond; font-style:italic; font-family:Constantia">
        </p>
            <br />
      <%--  <asp:CheckBox ID="Remember" runat="server" /> Remember Me  
         </br>
        </br>--%>
             
            <asp:Button ID="sign_in" Class="in_button" OnClick="Search_Button_Click" runat="server" Text="Sign In" />
            
        </div>

        <p style="color: white; font: 20px Maiandra GD; text-align:center">      Don't have an account yet,&nbsp
        
           
              <a onclick="javascript:window.open('Sign_Up.aspx','false');">
                  <asp:Button ID="Button1" Class="up_button" runat="server" Text="Sign Up" />
              </a>

        </p>

    </form>

</body>
</html>
