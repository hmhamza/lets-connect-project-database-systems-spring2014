<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JqueryImageSlider.aspx.cs" Inherits="UI_JqueryImageSlider" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Jquery Image Slider</title>
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
                transition_speed: 500,
                transition_interval: 3000,
                panel_width: 765,
                panel_height: 298,
                frame_width: 120,
                frame_height: 90,
                show_panels: true,
                show_panel_nav: true,
                enable_overlays: true,
                easing: 'swing',
                panel_animation: 'slide',
                panel_scale: 'crop',
                show_filmstrip: true,
                infobar_opacity: 0.0,
                enable_slideshow: true,
                autoplay: true
            });
        });
	
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <ul id="sliderImageGallery">
            <li>
                <img src="../images/slidingImage/1.jpg" alt="image1" title="Lone Tree Yellowstone" data-description="A solitary tree surviving another harsh" /></li>
            <li>
                <img src="../images/slidingImage/2.jpg" alt="image2" /></li>
            <li>
                <img src="../images/slidingImage/3.jpg" alt="image3" /></li>
            <li>
                <img src="../images/slidingImage/4.jpg" alt="image4" /></li>
            <li>
                <img src="../images/slidingImage/5.jpg" alt="image5" /></li>
        </ul>
    </div>
    </form>
</body>
</html>
