<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="MoneyMaker_Online.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="container" id="verify" style="font-size: 18px;" runat="server">

        <br />
        <br />
        <br />

        <div class="span7">
            <br />
            <asp:Label ID="Label1" runat="server" Text="In order to change or see any of your personal information please enter your password in order to varify identity.."></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" TextMode="Password" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label7" runat="server" Text="" style="color:darkred;"></asp:Label>
            <asp:Button ID="Button1" class="btn btn-success btn-large" Style="float: right;" Auto="true" runat="server" Text="Enter" OnClick="Button1_Click" />
        </div>
        <br />
        <br />
        <br />
    </div>

    <div class="container" id="change" runat="server" style="font-size: 18px; margin-bottom:50px;">
        <br />
        <br />
        <br />
        <div class="span7">
            <h3 style="color: #333333"><u>Change info:</u></h3>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Name:"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

            <br />
            <br />

            <asp:Label ID="Label4" runat="server" Text="Last name:"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

            <br />
            <br />

            <asp:Label ID="Label5" runat="server" Text="Password:"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>

            <br />
            <br />

            <asp:Label ID="Label6" runat="server" Text="Email:"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>

            <br />
            <br />


            <asp:Button ID="Button2" class="btn btn-success btn-large" Style="float: right;" runat="server" Text="Change" OnClick="Button2_Click" />
            <br />
            <br />
            <br />
            <asp:Button ID="Button3" class="btn btn-success btn-large" Style="float: right;" runat="server" Text="Delete the account" OnClientClick="return confirm('Are you sure?');" OnClick="Button3_Click" />
            <br />
            <br />
            <asp:Label ID="Label8" runat="server" Text="" style="color:darkred;"></asp:Label>

        </div>

        <div class="span7" style="margin-left: 100px;">
            <h3 style="color: #333333"><u>Month Summery:</u></h3>
            <br />
            <div class="span6">
                <p>
                    you spent: <%=spent %>
                    <br />
                    and earned: <%=earned %>
                    <br />
                    <br />
                    over all: <%=llnie %>
                </p>
            </div>



            <div class="span3" style="margin-top: 25px">
                <asp:Label ID="Label9" runat="server" Text="Date"></asp:Label>
                <br />
                <asp:Button ID="Button4" class="btn btn-success btn-large" runat="server" Text="from" OnClick="Button4_Click" />
                <asp:Label ID="Label10" runat="server" Text="Choose date"></asp:Label>
                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="false" Style="z-index: 1; position: absolute;" BackColor="#89C236" ForeColor="White">
                    <DayHeaderStyle BackColor="#006600" ForeColor="White" />
                    <DayStyle ForeColor="White" />
                    <SelectedDayStyle BackColor="#006600" />
                    <TitleStyle BackColor="#006600" />
                </asp:Calendar>
                <br />
                <br />
                <br />
                <asp:Button ID="Button5" class="btn btn-success btn-large" runat="server" Text="  to  " OnClick="Button5_Click" />
                <asp:Label ID="Label11" runat="server" Text="Choose date"></asp:Label>
                <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged" Visible="false" Style="z-index: 1; position: absolute;" BackColor="#89C236" ForeColor="White">
                    <DayHeaderStyle BackColor="#006600" ForeColor="White" />
                    <DayStyle ForeColor="White" />
                    <SelectedDayStyle BackColor="#006600" />
                    <TitleStyle BackColor="#006600" />
                </asp:Calendar>


            </div>
            <div class="span3" style="margin-top: 25px">
                <asp:Label ID="Label12" runat="server" Text="Type Group"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="Label13" runat="server" Text="Group"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
            </div>
            <br />
            <br />
            <br />

            <div class="span3" style="float: right; margin-top: 25px;">
                <asp:Button ID="Button6" class="btn btn-success btn-large" Style="float: right;" runat="server" Text="Calculate" OnClick="Button6_Click" />
            </div>

            <br />
            <br />
            <br />

            <div class="span6" <%=calc_hidden %> style="margin-top: 25px">
                <h3><u><b>Results:</b></u></h3>
                <br />
                <p>
                    Between <%=Calendar1.SelectedDate.ToString("yyyy/MM/dd") %> and <%=Calendar2.SelectedDate.ToString("yyyy/MM/dd") %>
                    <br />
                    <br />
                    From the catagory <%=DropDownList1.SelectedValue.ToString() %> -> <%=DropDownList2.SelectedValue.ToString() %>
                    <br />
                    <br />
                    you spent: <%=spents %>
                    <br />
                    and earned: <%=earneds %>
                    <br />
                    <br />
                    over all: <%=llnies %>
                </p>
            </div>
        </div>
        <br />
        <br />
        <br />
    </div>


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
