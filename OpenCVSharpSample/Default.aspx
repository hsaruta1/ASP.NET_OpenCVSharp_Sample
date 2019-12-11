<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OpenCVSharpSample.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            width: 1359px;
            height: 646px;
        }
        #imgCtrl {
            height: 644px;
            width: 999px;
        }
    </style>
</head>
<body style="height: 621px">
    <form id="form1" runat="server">
        
        
        &nbsp;<asp:Button ID="GrayScale" runat="server" Text="グレースケール" Width="113px" OnClick="GrayScale_Click" />
        &nbsp;&nbsp;　<asp:Button ID="Sobel" runat="server" OnClick="Sobel_Click" Text="エッジ検出" Width="108px" />
        　　<asp:Button ID="snooth" runat="server" OnClick="snooth_Click" Text="平滑化" Width="79px" />
        　　<asp:Button ID="Dilate" runat="server" OnClick="Dilate_Click" Text="画像膨張" Width="87px" />
&nbsp; 　<asp:Button ID="Erode" runat="server" OnClick="Erode_Click" Text="画像収縮" Width="75px" />
&nbsp; 　<asp:Button ID="Hough" runat="server" OnClick="Hough_Click" Text="輪郭取得" Width="98px" />
        　　<asp:Button ID="origin" runat="server" OnClick="origin_Click" Text="元画像を表示" Width="119px" />
        
        <p>
        <img runat="server" id="imgCtrl" /></p>
        <p>
    </form>
</body>
</html>
