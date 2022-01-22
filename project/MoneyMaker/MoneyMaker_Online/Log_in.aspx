<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.Master" AutoEventWireup="true" CodeBehind="Log_in.aspx.cs" Inherits="MoneyMaker_Online.Log_in" EnableSessionState="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <br />
    <br />
    <br />
    <div class="container" style="font-size: 18px;">

        <div class="container">

            <div class="span2">

                <asp:Label ID="Label1" runat="server" Style="z-index: 1;" Text="Email"></asp:Label>

            </div>

            <div class="span3">

                <asp:TextBox ID="TextBox1" runat="server" Style="z-index: 1;"></asp:TextBox>

            </div>

        </div>

        <div class="container">

            <div class="span2">

                <asp:Label ID="Label3" runat="server" Style="z-index: 1;" Text="Password"></asp:Label>

            </div>

            <div class="span3">

                <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" Style="z-index: 1;"></asp:TextBox>

            </div>



            <div class="span3">
                <asp:Button ID="Button1" class="btn btn-success btn-large" runat="server" OnClick="Button1_Click" Style="z-index: 1; margin-bottom: 20px" Text="Login" />

                <asp:Button ID="Button2" class="btn btn-success btn-large" runat="server" OnClick="Button2_Click" Style="z-index: 1; margin-bottom: 20px" Text="Register" />
            </div>
        </div>
        <div class="container">
            <div class="span3">
                <asp:Label ID="Label4" runat="server" Style="z-index: 1; margin-bottom: 20px; color: darkred;" Text=""></asp:Label>
            </div>
        </div>
        <br />
        <br />
    </div>
</asp:Content>
