<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="onlineCoach.SignIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row"><h2 class="title">Sign in</h2></div>
    <div class="row infoP">
         

        
        <div class="col-sm-6 ">
                
                <div class="form-group">
                    <input id="email" name="email" type="text" placeholder="Email Address..." class="form-control input-md field" required="" runat="server">
                </div>
                
                <div class="form-group">
                    <input id="password" name="password" type="password" placeholder="Password..." class="form-control input-md field" required="" runat="server">
                </div>

                <div class="form-group">
                    <asp:Button ID="sign" runat="server" Text="Sign in" CssClass="btn btn-primary button" OnClick="sign_Click"/>
                     
                </div>
            

        <p class="cntr"><a runat="server" href="~/SignUp">Create an account</a></p>

        </div>
        <div class="col-sm-6"><p class="cntr">Sign in to view and update your account details</p>
            <p class="cntr"><img src="Content/SignIn.PNG" width="45%" class="cntr"/></p>

            
        </div>
 


            
                
        
    </div>
</div>
</asp:Content>
