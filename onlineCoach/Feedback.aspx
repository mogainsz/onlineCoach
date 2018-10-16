<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="onlineCoach.Feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="title">Leave your feedback</h2>
    <div class="row infoP">
         
           
                <div class="col-sm-6">
                <div class="form-group">
                    <input id="name" name="name" type="text" placeholder="Your name..." class="form-control input-md field" required="" runat="server">
                </div>

                <div class="form-group">
                    <input id="email" name="email" type="text" placeholder="Email Address..." class="form-control input-md field" required="" runat="server">
                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="email" ErrorMessage="Invalid Email Format" CssClass="validationS" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>

                <div class="form-group">
                     <textarea id="comment" name="comment" type="text" placeholder="Your comment..." class="form-control input-md field" runat="server" style="min-height:150px"></textarea>
    
                </div>

                <div class="form-group">
                    <h5 class="title1">Overall rating</h5>
                    <asp:RadioButtonList ID="FeedbackRL" runat="server" RepeatDirection="Horizontal" Width="50%" TextAlign="Left" CssClass="field">
                        <asp:ListItem Text="0" Value="0" Selected="True"/>
                        <asp:ListItem Text="1" Value="1"/>
                        <asp:ListItem Text="2" Value="2"/>
                        <asp:ListItem Text="3" Value="3"/>
                        <asp:ListItem Text="4" Value="4"/>
                        <asp:ListItem Text="5" Value="5"/>
                    </asp:RadioButtonList>
    
                </div>
                

                <div class="form-group">
                    <asp:Button ID="sendComment" runat="server" Text="Submit" CssClass="btn btn-primary button" OnClick="sendComment_Click"/>
                     
                </div>
            </div>
        <div class="col-sm-6">
            <p class="cntr">Feel free to send us your feedback about our website, what you like, what you dont like, any feedback is appreciated</p>
            <br /><br />
            <p class="cntr">
                <img src="Content/feedback-2044701_960_720.png" width="65%" />
                </p>
        </div>
        
    </div>
</div>
</asp:Content>
