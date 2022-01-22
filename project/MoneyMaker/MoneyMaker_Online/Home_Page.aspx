<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.Master" AutoEventWireup="true" CodeBehind="Home_Page.aspx.cs" Inherits="MoneyMaker_Online.Home_Page" EnableSessionState="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- start: Meta -->
    <meta charset="utf-8">
    <title>GotYA FREE BOOTSTRAP THEME by BootstrapMaster</title>
    <meta name="description" content="GotYa Free Bootstrap Theme" />
    <meta name="keywords" content="Template, Theme, web, html5, css3, Bootstrap" />
    <meta name="author" content="Łukasz Holeczek from creativeLabs" />
    <!-- end: Meta -->

    <!-- start: Mobile Specific -->
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <!-- end: Mobile Specific -->

    <!-- start: Facebook Open Graph -->
    <meta property="og:title" content="" />
    <meta property="og:description" content="" />
    <meta property="og:type" content="" />
    <meta property="og:url" content="" />
    <meta property="og:image" content="" />
    <!-- end: Facebook Open Graph -->

    <!-- start: CSS -->
    <link href="css/bootstrap.css" rel="stylesheet">
    <link href="css/bootstrap-responsive.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Droid+Sans:400,700">
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Droid+Serif">
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Boogaloo">
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Economica:700,400italic">
    <!-- end: CSS -->

    <!-- Le HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
      <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->

</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="wrapper">

        <!--start: Container -->
        <div class="container">

            <!-- start: Hero Unit - Main hero unit for a primary marketing message or call to action -->
            <div class="hero-unit">
                <p>
                    Easy Money is a free utility designed to help you manage your economy and save money in an easy and effective way.
                </p>
                <p><a class="btn btn-success btn-large" href="Introduction.aspx" runat="server">Learn more &raquo;</a></p>
            </div>
            <!-- end: Hero Unit -->
            <br />
            <br />
            <!-- start: Row -->
            <div class="row">

                <div class="span4" style="width: 31.5%">
                    <div class="icons-box" style="text-align: center; align-content: center; align-items: center">
                        <i class="ico-ok circle big"></i>
                        <div class="title">
                            <h2>Easy to use</h2>
                        </div>
                        <p style="font-size: 20px;">
                            The utility is very simple to use and it has no complicated operations.
                        </p>
                        <div class="clear"></div>
                    </div>
                </div>

                <div class="span4" style="width: 31.5%">
                    <div class="icons-box">
                        <i class="ico-ipad circle big"></i>
                        <div class="title">
                            <h2>Save Money</h2>
                        </div>
                        <p style="font-size: 20px;">
                            The utility collects all the information the user puts into it and it shows diagrams and important notes.
                        </p>
                        <div class="clear"></div>
                    </div>
                </div>

                <div class="span4" style="width: 31.5%">
                    <div class="icons-box">
                        <i class="ico-heart circle big"></i>
                        <div class="title">
                            <h2>User friendly</h2>
                        </div>
                        <p style="font-size: 20px;">
                            The design of the site is very easy to navigate and use.
                        </p>
                        <div class="clear"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- end: Row -->
</asp:Content>
