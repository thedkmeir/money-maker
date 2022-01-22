<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="MoneyMaker_Online.Edit" %>

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
                <asp:Label ID="Label1" runat="server" Style="text-decoration-style: solid;" Text="Old information:" Font-Bold="true"></asp:Label>
            </div>
        </div>

        <br />

        <div class="container">
            
                <div class="span3" <%=moneyhide %>>
                    <asp:Label ID="Label2" runat="server" Text="Money:&nbsp"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text="!!!"></asp:Label>
                </div>
            

            <div class="span3" <%=moneyhide %>>
                <asp:Label ID="Label4" runat="server" Text="date:&nbsp"></asp:Label>
                <asp:Label ID="Label5" runat="server" Text="!!!"></asp:Label>
            </div>

            <div class="span3">
                <asp:Label ID="Label6" runat="server" Text="Type group:&nbsp"></asp:Label>
                <asp:Label ID="Label7" runat="server" Text="!!!"></asp:Label>
            </div>

            <div class="span3">
                <asp:Label ID="Label8" runat="server" Text="Type:&nbsp"></asp:Label>
                <asp:Label ID="Label9" runat="server" Text="!!!"></asp:Label>
            </div>

        </div>

        <br />
        <br />

        <div class="container">

            <div class="span3">
                <asp:Label ID="Label13" runat="server" Text="Description:&nbsp"></asp:Label>
                <asp:Label ID="Label14" runat="server" Style="width: 220px; position: relative;" Text="!!!"></asp:Label>
            </div>

        </div>

        <br />
        <br />
        <br />
        <br />

        <div class="container">
            <div class="span3">
                <asp:Label ID="Label12" runat="server" Style="text-decoration-style: solid;" Text="New information:" Font-Bold="true"></asp:Label>
            </div>
        </div>

        <br />

        <div class="container">
            <div class="span3" <%=moneyhide %>>
                <asp:Label ID="Label10" runat="server" Text="Money"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" Width="180px"></asp:TextBox>
            </div>

            <div class="span3" <%=moneyhide %>>
                <asp:Button ID="Button1" class="btn btn-success btn-large" runat="server" Text="choose" OnClick="Button1_Click" />
                <asp:Label ID="Label11" runat="server" Text="Chose date"></asp:Label>
                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="false" Style="z-index: 1; position: absolute;" BackColor="#89C236" ForeColor="White">
                    <DayHeaderStyle BackColor="#006600" ForeColor="White" />
                    <DayStyle ForeColor="White" />
                    <SelectedDayStyle BackColor="#006600" />
                    <TitleStyle BackColor="#006600" />
                </asp:Calendar>
            </div>

            <div class="span3">
                <asp:Label ID="Label15" runat="server" Text="Type group"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
            </div>

            <div class="span3">
                <asp:Label ID="Label16" runat="server" Text="Type"></asp:Label>
                <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
            </div>
        </div>

        <br />
        <br />

        <div class="container">
            <div class="span4">
                <asp:Label ID="Label17" runat="server" Style="z-index: 1;" Text="Description"></asp:Label>
                <textarea id="TextArea1" runat="server" style="z-index: 1; resize: none;" cols="30" name="S1" rows="5"></textarea>
            </div>
        </div>

        <div class="container">
            <div class="span2" style="float: right; vertical-align: bottom;">
                <asp:Button ID="Button2" class="btn btn-success btn-large" Style="vertical-align: bottom;" runat="server" Text="Update" OnClick="Button2_Click" />
            </div>
            <div class="span2">
                <asp:Label ID="Label18" runat="server" Style="color: darkred;" Text=""></asp:Label>
            </div>
        </div>

        <br />
        <br />

    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
