<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="onlineCoach.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="title">Sign up</h2>
    <div class="row infoP">
         
            
                
        <div class="col-sm-6">
                <div class="form-group">
                    <input id="fName" name="fName" type="text" placeholder="First name..." class="form-control input-md field" required="" runat="server">
                </div>

                <div class="form-group">
                    <input id="lName" name="lName" type="text" placeholder="Last name..." class="form-control input-md field" required="" runat="server">
                </div>
                
                <div class="form-group">
                    <input id="email" name="email" type="text" placeholder="Email Address..." class="form-control input-md field" required="" runat="server">
                </div>
                
                <div class="form-group">
                    <input id="password" name="password" type="password" placeholder="Password..." class="form-control input-md field" required="" runat="server">
                </div>

                <div class="form-group">
                    <asp:Button ID="join" runat="server" Text="Sign up" cssClass="btn btn-primary button" OnClick="join_Click"/>
                     
                </div>
            

        <p class="cntr"><a runat="server" href="~/SignIn">Already have an account?</a></p>
        </div>
        <div class="col-sm-6">
            Create your free account now and enjoy the full benefits of our website!
            <p class="cntr"><img src="Content/SignUp.png" width="60%"/></p>
        </div>
    </div>
</div>
</asp:Content>
