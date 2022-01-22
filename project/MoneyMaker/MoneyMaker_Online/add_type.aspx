<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.Master" AutoEventWireup="true" CodeBehind="add_type.aspx.cs" Inherits="MoneyMaker_Online.add_type" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            $("input").keyup(function (event) {
                //get the source of the event
                var s = event.target.id;
                s = s.split("_");

                var all;
                var ele;
                var val = $(this).val();

                if (s[1] == "TextBox1") {
                    //clearing listbox1
                    $('#ListBox1 option').remove();
                    document.getElementById('<%=ListBox1.ClientID %>').innerHTML = "";


                //getting all data from listbox3
                all = document.getElementById('<%=ListBox3.ClientID %>').innerHTML;

                //getting the correct listbox to fill with data
                ele = document.getElementById('<%=ListBox1.ClientID %>');
            }
            else if (s[1] == "TextBox2") {
                //clearing listbox2
                $('#ListBox2 option').remove();
                document.getElementById('<%=ListBox2.ClientID %>').innerHTML = "";

                //getting all data from listbox4
                all = document.getElementById('<%=ListBox4.ClientID %>').innerHTML;

                //getting the correct listbox to fill with data
                ele = document.getElementById('<%=ListBox2.ClientID %>');

            }

            all = all.split("$");
            var n;
            var t;
            for (var i = 1; i < all.length; i++) {
                n = all[i].split("<");
                t = n[0].toUpperCase();
                if (t.startsWith(val.toUpperCase()) || val == "") {
                    t = new Option(n[0], n[0]);
                    $(t).html(n[0]);
                    ele.append(t);
                }
            }
            });
        });
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
    <br />
    <br />
    <div class="container" style="font-size: 18px; z-index: 1;">
        <div class="span3">
            <asp:Label ID="Label4" runat="server" Text="Add Type Group:"></asp:Label>

            <br />
            <br />
            <div class="span3">
                <asp:Label ID="Label" runat="server" Text="Enter Type Group:"></asp:Label>
                <asp:TextBox ID="TextBox1" type="text" runat="server" Style="margin-top: 4px;"></asp:TextBox>
            </div>
            <div class="span3">
                <br />
                <asp:ListBox ID="ListBox1" runat="server" Rows="6" AutoPostBack="true" CausesValidation="True" ClientIDMode="AutoID"></asp:ListBox>
            </div>
            <div class="span3">
                <asp:Button ID="Button1" class="btn btn-success btn-large" Style="float: right;" runat="server" Text="Add" OnClick="Button1_Click" />
            </div>
            <div class="span3">
                <asp:Label ID="Label5" runat="server" Text="" Style="color: darkred;"></asp:Label>
            </div>
        </div>

        <div class="span2">
        </div>

        <div class="span3">
            <asp:Label ID="Label1" runat="server" Text="Add Type:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Select Type Group:"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" Style="margin-top: 4px;" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
        </div>

        <div class="span3">
            <br />
            <br />
            <div class="span3">
                <asp:Label ID="Label3" runat="server" Text="Enter Type:"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox2" type="text" runat="server" Style="margin-top: 4px;"></asp:TextBox>
            </div>

            <div class="span3">
                <br />
                <asp:ListBox ID="ListBox2" runat="server" AutoPostBack="false" Rows="6"></asp:ListBox>
            </div>
            <div class="span3">
                <asp:Button ID="Button2" class="btn btn-success btn-large" Style="float: right;" runat="server" Text="Add" OnClick="Button2_Click" />
            </div>
            <div class="span3">
                <asp:Label ID="Label6" runat="server" Text="" Style="color: darkred;"></asp:Label>
            </div>

        </div>


    </div>
    <br />
    <br />
    <br />

    <asp:ListBox ID="ListBox3" runat="server" Style="display: none;"></asp:ListBox>
    <asp:ListBox ID="ListBox4" runat="server" Style="display: none;"></asp:ListBox>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

