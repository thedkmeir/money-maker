<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.Master" AutoEventWireup="true" CodeBehind="Tables.aspx.cs" Inherits="MoneyMaker_Online.Tables" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
    <div class="container" style="text-align:center;">
        <div class="row" style="text-align:center;">
            <%--<div class="span4" style="text-align:center;">--%>
                <asp:Button ID="Button2" class="btn btn-success" runat="server" style="float:left" Text="&lt;--- Last year" OnClick="Button2_Click" />
           <%-- </div>--%>
            
            <%--<div class="span4" style="text-align:center;">--%>
                <asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Size="Large" Text="Label"></asp:Label>
            <%--</div>--%>
            
            <%--<div class="span4">--%>
                <asp:Button ID="Button1" class="btn btn-success" runat="server" style="float:right" Text="Next year ---&gt;" OnClick="Button1_Click" />
            <%--</div>--%>
        </div>
        <asp:Chart ID="Chart1" runat="server" Width="1280" Height="720">
            <Series>
                <asp:Series Name="Series1" ToolTip="#SERIESNAME\nMonth = #LEGENDTEXT\nMoney = #VAL{C}">
                </asp:Series>
                <asp:Series Name="Series2" ToolTip="#SERIESNAME\nMonth = #LEGENDTEXT\nMoney = #VAL{C}">
                </asp:Series>
                <asp:Series Name="Series3" ToolTip="#SERIESNAME\nMonth = #LEGENDTEXT\nMoney = #VAL{C}">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
            <Titles>
                
                <asp:Title Font="Microsoft Sans Serif, 12pt" Name="Title1">
                </asp:Title>
            </Titles>
        </asp:Chart>
        <br />
        <div class="row" style="text-align:center;">
            <%--<div class="span4">--%>
                <asp:Button ID="Button3" class="btn btn-success" runat="server" style="float:left;" Text="Previous Table" OnClick="Button3_Click" />
            <%--</div>--%>
            
            <%--<div class="span4">--%>
                <asp:Label ID="Label2" runat="server" Font-Bold="true" Font-Size="Large" Text="Label"></asp:Label>
            <%--</div>--%>

            <%--<div class="span4">--%>
                <asp:Button ID="Button4" class="btn btn-success" runat="server" style="float:right;" Text="Next Table" OnClick="Button4_Click" />
            <%--</div>--%>
        </div>
        <br />
        <br />
        
    </div>
    <br />
</asp:Content>
