<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnalyticalDashboard.aspx.cs" Inherits="onlineCoach.AnalyticalDashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >
    <div class="container">
        <h2 class="title">Analytics</h2>
    <div class="row">
        <div class="col-sm-6">
             <h4 class="title">Website ratings</h4>
    <asp:Chart ID="Chart1" runat="server" Height="500" Width="500">
        <Series>
            <asp:Series Name="Series1"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
        </div>
        <div class="col-sm-6">
            <h4 class="title">Booking status</h4>
    <asp:Chart ID="Chart2" runat="server" Height="500" Width="500">
        <Series>
            <asp:Series Name="Series1"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea2"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
            </div>
        </div>
        </div>
</asp:Content>
