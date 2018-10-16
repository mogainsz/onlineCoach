<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="onlineCoach.Booking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container">
        <h2 class="title">Book a lecture</h2>
    <div class="row infoP">
         
            
                <div class="col-sm-6">
                <div class="form-group">
                    <input id="orgName" name="orgName" type="text" placeholder="Company/School/Organization..." class="form-control input-md field" required="" runat="server">
                </div>

                <div class="form-group">
                    <input id="email" name="email" type="text" placeholder="Email Address..." class="form-control input-md field" required="" runat="server">
                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="email" ErrorMessage="Invalid Email Format" CssClass="validationS" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
                    
                <div class="form-group">
                     <input id="contactNumber" name="contactNumber" type="text" placeholder="Contact Number..." class="form-control input-md field" runat="server">
                    <asp:CompareValidator ID="cv" runat="server" ControlToValidate="contactNumber" Type="Integer" Operator="DataTypeCheck" ErrorMessage="Invalid contact number" Display="Dynamic" CssClass="validationS" />
                </div>
                <div class="form-group">
                    
                        <input id="date" name="date" class="form-control input-md field" placeholder="Pick date..." type="text" runat="server">
                    <asp:CompareValidator ErrorMessage="Invalid date format" Display="Dynamic" ID="valcDate" ControlToValidate="date" Operator="DataTypeCheck" Type="Date" runat="server" CssClass="validationS"></asp:CompareValidator> 
                        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" CssClass="field" Width="280"></asp:Calendar>
                        
                            
                </div>

                <div class="form-group">
                    <asp:Button ID="book" runat="server" Text="Book now" CssClass="btn btn-primary button" OnClick="book_Click"/>
                    
                </div>
           
        </div>
        <div class="col-sm-6">
            <p class="cntr">We offer a 1 hour lecture about healthy living and exercise at a cheap cost of just $50</p>
            <br />
            <p class="cntr">Pick your preferred lecture date and we'll be in contact to confirm with you</p>
            <p class="cntr"><img src="Content/businessman-607788_960_720.png" width="70%"/></p>
        </div>
    </div>
</div>
</asp:Content>
