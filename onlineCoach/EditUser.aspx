<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="onlineCoach.EditUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 
    <div class="row"><h2 class="title">Edit profile</h2></div>
     
    <div class="row infoP">
        <div class="col-sm-6">
         <div class="form-group">
                <label id="fNameLabel" runat="server">First name:</label>
                <input id="fName" name="fName" type="text" class="form-control input-md" required="" runat="server" placeholder="New first name...">
         </div>

        <div class="form-group">
            <label id="lNameLabel" runat="server">Last name:</label>
                <input id="lName" name="lName" type="text" class="form-control input-md" required="" runat="server" placeholder="New last name...">
         </div>

        <label id="genderLabel" runat="server">Gender:</label>
        <asp:RadioButtonList ID="gender" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" Width="250">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:RadioButtonList>

         <div class="form-group">
             <label id="birthdayLabel" runat="server">Birthday(dd/mm/yyyy):</label>
                <input id="birthday" name="birthday" type="text" class="form-control input-md"  runat="server" placeholder="Your birthday...">
                           <asp:CompareValidator ErrorMessage="Invalid date format" Display="Dynamic" ID="bdayVal" ControlToValidate="birthday" Operator="DataTypeCheck" Type="Date" runat="server"  ForeColor="red"></asp:CompareValidator> 

         </div>

        <div class="form-group">
            <label id="weightLabel" runat="server">Weight(KG):</label>
                <input id="weight" name="weight" type="text" class="form-control input-md"  runat="server" placeholder="Your weight in KG...">
            <asp:RegularExpressionValidator ID="weightVal" ControlToValidate="weight" runat="server" ErrorMessage="Invalid Weight" Display="Dynamic" ValidationExpression="[0-9]*\.?[0-9]*" ForeColor="red"></asp:RegularExpressionValidator>
         </div>

        <div class="form-group">
            <label id="heightLabel" runat="server">Height(CM):</label>
                <input id="height" name="height" type="text" class="form-control input-md"  runat="server" placeholder="Your Height in CM...">
            <asp:RegularExpressionValidator ID="heightVal" ControlToValidate="height" runat="server" ErrorMessage="Invalid height" Display="Dynamic" ValidationExpression="[0-9]*\.?[0-9]*" ForeColor="red"></asp:RegularExpressionValidator>
         </div>

        <div class="form-group">
            <label id="bmiLabel" runat="server">BMI: </label>
         </div>

        

        
            </div>
        <div class="col-sm-6">
            <div class="form-group">
            <label id="actvLvlLabel" runat="server">Activity Level: </label>
                
                <asp:DropDownList ID="actvLvl" runat="server" class="form-control input-md">
                    <asp:ListItem>Sedentary (little or no exercise) </asp:ListItem>
                    <asp:ListItem>Lightly active (light exercise/sports 1-3 days/week) </asp:ListItem>
                    <asp:ListItem>Moderatetely active (moderate exercise/sports 3-5 days/week) </asp:ListItem>
                    <asp:ListItem>Very active (hard exercise/sports 6-7 days a week) </asp:ListItem>
                    <asp:ListItem>Extra active (very hard exercise/sports & physical job or 2x training) </asp:ListItem>
                </asp:DropDownList>
         </div>

        <div class="form-group">
            <label id="goalWeightLabel" runat="server">Goal weight(KG):</label>
                <input id="goalWeight" name="goalWeight" type="text" class="form-control input-md "  runat="server" placeholder="Your goal weight...">
            <asp:RegularExpressionValidator ID="goalWghtVal" ControlToValidate="goalWeight" runat="server" ErrorMessage="Invalid goal weight" Display="Dynamic" ValidationExpression="[0-9]*\.?[0-9]*" ForeColor="red"></asp:RegularExpressionValidator>
         </div>

        <div class="form-group">
            <label id="aboutLabel" runat="server">About me:</label>
                <textarea id="about" name="about" type="text" class="form-control input-md" runat="server" placeholder="Tell us about yourself..." style="min-height:150px"></textarea>
         </div>

        <div class="form-group">
            <label id="emailLabel" runat="server">Email address:</label>
                <input id="email" name="email" type="text" class="form-control input-md" required="" runat="server" placeholder="Your new email address...">
            <asp:RegularExpressionValidator ID="emailVal" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="email" ErrorMessage="Invalid Email Format" Display="Dynamic" ForeColor="red"></asp:RegularExpressionValidator>
         </div>
        </div>
     </div>

    <div class="row saveCont cntr">
         <div class="form-group">
                    <asp:Button ID="save" runat="server" Text="Save changes" CssClass="btn btn-primary editButton" OnClick="save_Click" OnClientClick="return confirm('Are you sure?')"/>
                     <asp:Button ID="cancel" runat="server" Text="Cancel" CssClass="btn btn-primary editButton" OnClick="cancel_Click" OnClientClick="return confirm('Are you sure?')"/>
            </div>
    </div>
    
</asp:Content>
