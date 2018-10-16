<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="onlineCoach.UserPage" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="title">
    <h2 ><span id="currUser" runat="server" >Log in to view and update your profile</span></h2>
    <a href="SignIn.aspx" id="login" runat="server" style="text-align:center;">Click here to log in</a>
    </div>

    <div class="container" id="profContainer" visible="false" runat="server">

        
        <h4 class="title" id="pHeading" runat="server">General info</h4>
    <div class="row infoP">
        
        <div class="col-sm-6">
    <p id="name" runat="server" class="info"></p>
     <p id="gender" runat="server" class="info"></p>
    <p id="birthday" runat="server" class="info"></p>
     <p id="weight" runat="server" class="info"></p>
     <p id="height" runat="server" class="info"></p>
     <p id="bmi" runat="server" class="info"></p>
                   <p id="actvLvl" runat="server" class="info"></p>
     <p id="goalWeight" runat="server" class="info"></p>
     
     <p id="email" runat="server" class="info"></p>
     

    <asp:Button ID="editProf" runat="server" Text="Edit profile" CssClass="btn btn-primary" OnClick="editProf_Click"/>

        </div>

         <div class="col-sm-6">
           
             <p id="about" runat="server" class="info"></p>
        
            

        </div>
        </div>
        <h4 class="title">Stats info</h4>
        <div class="row infoP"> 
            
              <div class="col-sm-7">
                  <p id="bmiChrtL" runat="server" class="info"><b>BMI chart: </b></p>
            <img src="Content/bmi-chart.png" width="89%" />
                  
            
                  
                

            </div>

            <div class="col-sm-5">
                <div class="info">
             <p id="calsInfo" runat="server"></p>
             <p id="loseCals" runat="server" ></p>
             <p id="maintCals" runat="server" ></p>
             <p id="gainCals" runat="server" ></p>
              
             
                 </div>
                <div class="info">
                    <p><b>Important: </b></p>
                    <p>The above caloric breakdown is just a general guide line based on the info you have provided, please adjust your calories accordingly if you are gaining/losing weight too quickly or contact one of our trainers for help</p>
                </div>

                <p class="info"><b>your health status:</b></p>
                <asp:Panel ID="Panel1" runat="server" class="info panelText1" BackColor="#FF8800" Width="100%" Height="40" ForeColor="Black" Direction="LeftToRight" HorizontalAlign="Center"><p id="bmiChrt" runat="server" ></p> </asp:Panel>
                <br />
                 <p id="currWeight" runat="server" class="info"></p>
               
                
             <asp:Panel ID="Panel2" runat="server" class="info panelText1" BackColor="Red" Width="10%" Height="40" ForeColor="Black" Direction="LeftToRight" HorizontalAlign="Center"><p id="goalChrt" runat="server"></p> </asp:Panel>
            </div>
         
          
        </div>
    </div>

    
</asp:Content>
