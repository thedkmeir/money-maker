<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.Master" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="MoneyMaker_Online.add" EnableSessionState="True" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
    <br />
    <br />
    <div class="container" style="font-size: 18px;">

        <div class="container">
            <div class="span3">
                <asp:Label ID="Label6" runat="server" Text="Income / Outcome"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CheckBox5_CheckedChanged">
                <asp:ListItem Value="0">Select</asp:ListItem>
                <asp:ListItem Value="1">Income</asp:ListItem>
                <asp:ListItem Value="2">Outcome</asp:ListItem>
            </asp:DropDownList>
            </div>
        </div>
        
        <br />
        <br />

        <div class="container">
            
            <div class="span3">
                <asp:Label ID="Label1" runat="server" Style="z-index: 1;" Text="Money"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" Style="z-index: 1;"></asp:TextBox>
            </div>
        
            <div class="span3">
                <asp:Label ID="Label3" runat="server" Style="z-index: 1;" Text="Description"></asp:Label>
                <textarea ID="TextArea1" runat="server" Style="z-index: 1; resize: none;" cols="30" name="S1" rows="5" draggable="auto"></textarea>
            </div>


        </div>

        <div class="container">
            <div class="span1_5">
                <asp:CheckBox ID="CheckBox5" runat="server" style="vertical-align:auto" OnCheckedChanged="CheckBox5_CheckedChanged" AutoPostBack="True"/>
                <label for="Checkbox1" style="float:right">&nbsp Monthly</label>
            </div>
        </div>

        <br />

        <div class="container"> 
            <div class="span1_5"> 
                <asp:CheckBox ID="CheckBox3" Visible="false" runat="server" style="vertical-align:auto" AutoPostBack="True" OnCheckedChanged="CheckBox3_CheckedChanged" />
                <label ID="paymentslabel" for="CheckBox2" style="float:right" ><%=pay %></label>
            </div>

            <div class="span1_5"> 
                <asp:TextBox ID="TextBox2" Visible="false" runat="server"></asp:TextBox>
            </div>
        </div>


        <br />

        <div class="container"> 
            <div class="span3"> 
                <asp:Label ID="Label2" runat="server" Text="Type Group"></asp:Label>
                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnTextChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
            </div>


            <div class="span3"> 
                <asp:Label ID="Label5" runat="server" Text="Type"></asp:Label>
                <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList>
            </div>
        </div>

       <br />

            <div class="span9">
                <asp:Button ID="Button1" class="btn btn-success btn-large" runat="server" Style="z-index: 1; float:right" Text="Add" OnClick="Button1_Click" />
            </div>

        <div class="container">
            <div class="span8">
                <asp:Label ID="Label4" runat="server" Style="z-index: 1; margin-bottom: 20px; color:darkred;" Text=""></asp:Label>
            </div>
        </div>
        <br />
        <br />
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
