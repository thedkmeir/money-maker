<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MoneyMaker_Online.Register" %>

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

                <asp:Label ID="Label1" runat="server" Text="First Name" Style="z-index: 1;"></asp:Label>

            </div>

            <div class="span3">

                <asp:TextBox ID="TextBox1" runat="server" Style="z-index: 1;"></asp:TextBox>

            </div>

        </div>

        <div class="container">

            <div class="span2">

                <asp:Label ID="Label2" runat="server" Text="Last Name" Style="z-index: 1;"></asp:Label>

            </div>

            <div class="span3">

                <asp:TextBox ID="TextBox2" runat="server" Style="z-index: 1;"></asp:TextBox>

            </div>

        </div>

        <div class="container">

            <div class="span2">

                <asp:Label ID="Label3" runat="server" Text="Password" Style="z-index: 1;"></asp:Label>

            </div>

            <div class="span3">

                <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" Style="z-index: 1;" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>

            </div>

        </div>

        <div class="container">

            <div class="span2">

                <asp:Label ID="Label4" runat="server" Text="Money" Style="z-index: 1;"></asp:Label>

            </div>

            <div class="span3">

                <asp:TextBox ID="TextBox4" runat="server" Style="z-index: 1;"></asp:TextBox>

            </div>

        </div>

        <div class="container">

            <div class="span2">

                <asp:Label ID="Label5" runat="server" Text="Email" Style="z-index: 1;"></asp:Label>

            </div>

            <div class="span3">

                <asp:TextBox ID="TextBox5" runat="server" Style="z-index: 1;"></asp:TextBox>

            </div>

            <div class="span3">

                <asp:Button ID="Button1" class="btn btn-success btn-large" runat="server" Style="z-index: 1;" Text="Register" OnClick="Button1_Click" />

            </div>

        </div>
        <br />
        <div class="container">

            <div class="span3">
                <asp:Label ID="Label6" runat="server" Style="z-index: 1; margin-bottom: 20px; color: darkred;" Text=""></asp:Label>
            </div>

        </div>
    </div>
    <br />
    <br />
    <br />
</asp:Content>
