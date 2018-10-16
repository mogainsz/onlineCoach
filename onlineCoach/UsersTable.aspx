<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsersTable.aspx.cs" Inherits="onlineCoach.UsersTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div class="container">
       <div class="row">
           <h1 class="title">View users</h1>
       
           <div class="col-sm-6">
               <h4 class="title">Users</h4>

               <asp:Panel runat="server" Height="500px" ScrollBars="Vertical">
                       <div class="col-sm-12 searchArea">
    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control input-md searchBox" placeholder="Search by last name..."></asp:TextBox>
    <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="Search"  CssClass="btn btn-default searchButton" />
        </div>
                   <h4 id ="count" runat="server"></h4>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="10" Width="100%" OnRowCommand="GridView1_RowCommand" RowStyle-Height="50" HeaderStyle-BackColor="#d9230f" HeaderStyle-Height="30">  
                    <Columns>  
                        <asp:TemplateField HeaderText="First name" HeaderStyle-ForeColor="white">  
                            <ItemTemplate>  
                                
                                <asp:Label ID="fName" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                                
                                <asp:Label ID="weight" Visible="false" runat="server" Text='<%# Eval("Weight") %>' />
                                <asp:Label ID="height" Visible="false" runat="server" Text='<%# Eval("Height") %>' />
                                <asp:Label ID="bday" Visible="false" runat="server" Text='<%# Eval("Birthday") %>' />
                                <asp:Label ID="actvLvl" Visible="false" runat="server" Text='<%# Eval("ActivityLevel") %>' />
                                <asp:Label ID="bmi" Visible="false" runat="server" Text='<%# Eval("BMI") %>' />
                                <asp:Label ID="about" Visible="false" runat="server" Text='<%# Eval("About") %>' />
                                <asp:Label ID="goalWeight" Visible="false" runat="server" Text='<%# Eval("GoalWeight") %>' />
                                <asp:Label ID="gender" Visible="false" runat="server" Text='<%# Eval("Gender") %>' />
                            </ItemTemplate>  
                        </asp:TemplateField>  
                        
                         <asp:TemplateField HeaderText="Last name" HeaderStyle-ForeColor="white">  
                            <ItemTemplate>  
                                <asp:Label ID="lName" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Email address" HeaderStyle-ForeColor="white">  
                            <ItemTemplate>  
                                <asp:Label ID="email" runat="server" Text='<%# Eval("EmailAddress") %>' />
                            </ItemTemplate>  
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="View" HeaderStyle-ForeColor="white" >  
                            <ItemTemplate>  
                                <asp:Button ID="viewButton" runat="server" Text="View profile" CommandName="viewUser" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CssClass="btn btn-secondary"/>
                            </ItemTemplate>  
                        </asp:TemplateField> 
                         
                    </Columns>  
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />  
                    
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />  
                    <RowStyle BackColor="FloralWhite" ForeColor="black" CssClass="gridBorder" />  
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />  
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />  
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />  
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />  
                    <SortedDescendingHeaderStyle BackColor="#002876" />  
                </asp:GridView>  
            
    </asp:Panel>
               </div>
           <div class="col-sm-6">
               <h4 class="title">User info</h4>
               
               <div id="currUserInfo" runat="server" visible="false">
               <p id="name" runat="server" class="info"></p>
     <p id="dGender" runat="server" class="info"></p>
    <p id="dBirthday" runat="server" class="info"></p>
     <p id="dWeight" runat="server" class="info"></p>
     <p id="dHeight" runat="server" class="info"></p>
     <p id="dBmi" runat="server" class="info"></p>
      <p id="dActvLvl" runat="server" class="info"></p>
     <p id="dGoalWeight" runat="server" class="info"></p>
     
     <p id="dEmail" runat="server" class="info"></p>
               <p id="dAbout" runat="server" class="info"></p>
               
                  <div class="info">
             <p id="calsInfo" runat="server"></p>
             <p id="loseCals" runat="server" ></p>
             <p id="maintCals" runat="server" ></p>
             <p id="gainCals" runat="server" ></p>
              
             
                 </div>
               <p class="info"><b>Health status: </b> </p>
               <asp:Panel ID="Panel1" runat="server" class="info panelText" BackColor="#FF8800" Width="100%" Height="21" ForeColor="Black" Direction="LeftToRight" HorizontalAlign="Center"><p id="bmiChrt" runat="server" ></p> </asp:Panel>
               <br />
               <p class="info"><b>Weight progress: </b> </p>
               <asp:Panel ID="Panel2" runat="server" class="info panelText" BackColor="Red" Width="100%" Height="21" ForeColor="Black" Direction="LeftToRight" HorizontalAlign="Center"><p id="goalChrt" runat="server"></p> </asp:Panel>
               </div>
           </div>
       </div>
       </div>
</asp:Content>
