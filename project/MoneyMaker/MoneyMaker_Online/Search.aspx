<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="MoneyMaker_Online.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
    <br />
    <br />
    <div class="container" style="font-size: 18px; z-index: 1;">

        <div class="container">

            <div class="span4">
                <asp:Label ID="Label1" runat="server" Style="z-index: 1;" Text="Money"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox1" runat="server" Style="z-index: 1;"></asp:TextBox>

            </div>

            <div class="span4">
                <asp:Label ID="Label2" runat="server" Style="z-index: 1;" Text="Description"></asp:Label>
                <textarea id="TextArea1" runat="server" style="z-index: 1; resize: none;" cols="30" name="S1" rows="5"></textarea>
            </div>

            <div class="span3">
                <asp:Label ID="Label3" runat="server" Text="Date"></asp:Label>
                <br />
                <asp:Button ID="Button1" class="btn btn-success btn-large" runat="server" Text="from" OnClick="Button1_Click" />
                <asp:Label ID="Label4" runat="server" Text="Chose date"></asp:Label>
                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="false" Style="z-index: 1; position: absolute;" BackColor="#89C236" ForeColor="White">
                    <DayHeaderStyle BackColor="#006600" ForeColor="White" />
                    <DayStyle ForeColor="White" />
                    <SelectedDayStyle BackColor="#006600" />
                    <TitleStyle BackColor="#006600" />
                </asp:Calendar>
                <br />
                <br />
                <asp:Button ID="Button2" class="btn btn-success btn-large" runat="server" Text="  to  " OnClick="Button2_Click" />
                <asp:Label ID="Label5" runat="server" Text="Chose date"></asp:Label>
                <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged" Visible="false" Style="z-index: 1; position: absolute;" BackColor="#89C236" ForeColor="White">
                    <DayHeaderStyle BackColor="#006600" ForeColor="White" />
                    <DayStyle ForeColor="White" />
                    <SelectedDayStyle BackColor="#006600" />
                    <TitleStyle BackColor="#006600" />
                </asp:Calendar>
            </div>
        </div>
        <br />
        <div class="container">
            <div class="span4">
                <asp:Label ID="Label6" runat="server" Text="Type Group"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="Label7" runat="server" Text="Group"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
            </div>
            <br />
            <div class="span2">
                <asp:CheckBox ID="CheckBox1" runat="server"/>
                <asp:Label ID="Label8" runat="server" Text="Monthly"></asp:Label>
                <br />
                <br />
                <br />
                <br />
                <asp:CheckBox ID="CheckBox2" runat="server"/>
                <asp:Label ID="Label9" runat="server" Text="Date"></asp:Label>
            </div>

            <div class="span2">
                <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList>
            </div>
            <br />
        </div>

        <br />

        <div class="container">
            

            <div class="span2" style="float: right">
                <asp:Button ID="Button4" class="btn btn-success btn-large" runat="server" style="vertical-align:super; float: right" Text="Search" OnClick="Button4_Click" />
            </div>

            <div class="span2" style="float: right">
                <asp:Button ID="Button5" class="btn btn-success btn-large" runat="server" style="vertical-align:super; float: right" Text="Edit" OnClick="Button5_Click" />
            </div>

            <div class="span2" style="float: right">
                <asp:Button ID="Button3" class="btn btn-success btn-large" runat="server" style="vertical-align:super; float: right" Text="Delete" OnClick="Button3_Click" />
            </div>

            <div class="span8">
                <asp:Label ID="Label12" runat="server" style="color: darkred;" Text=""></asp:Label>
            </div>
        </div>

        <br />

        <div class="container" style="overflow: auto">
            <asp:GridView ID="GridView1" runat="server" Style="z-index: 0;" Width="100%" ViewStateMode="Enabled" BackColor="#89C236" ForeColor="White" PageSize="2" OnRowDataBound="GridView1_RowDataBound" AutoGenerateSelectButton="True" AllowSorting="True" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <AlternatingRowStyle Font-Bold="False" />
                <HeaderStyle BackColor="#006600" ForeColor="White" />
                <RowStyle HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#BAED88" ForeColor="Black" />
            </asp:GridView>
        </div>

    </div>

    
    <br />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
