<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookingsTable.aspx.cs" Inherits="onlineCoach.BookingsTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
    <h2 class="title">Bookings</h2>
    <p id="empty" runat="server"></p>
    <div class="col-sm-12 searchArea">
    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control input-md searchBox" placeholder="Search by name..."></asp:TextBox>
    <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="Search" CssClass="btn btn-default searchButton"/>
        </div>
    <h4 id ="count" runat="server"></h4>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="15" Width="100%" OnRowCommand="GridView1_RowCommand" HeaderStyle-BackColor="#d9230f" HeaderStyle-Height="30">  
                    <Columns>  
                        
                        <asp:TemplateField HeaderText="Name" ControlStyle-Width="200" HeaderStyle-ForeColor="white">  
                            <ItemTemplate>  
                                
                                <asp:TextBox ID="name" runat="server" Text='<%# Eval("Name") %>' CssClass="editField form-control input-md"></asp:TextBox>
                                <asp:Label ID="id" runat="server" Text='<%# Eval("BookingId") %>' Visible="false"></asp:Label>
                            </ItemTemplate>  
                        </asp:TemplateField>  
                        
                         <asp:TemplateField HeaderText="Email address" ControlStyle-Width="200" HeaderStyle-ForeColor="white">  
                            <ItemTemplate>  
                                <asp:TextBox ID="email" runat="server" Text='<%# Eval("EmailAddress") %>' CssClass="form-control input-md editField"></asp:TextBox>  
                                 <asp:RegularExpressionValidator ID="emailVal" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="email" ErrorMessage="Invalid Email Format" Display="Dynamic" ForeColor="red"></asp:RegularExpressionValidator>
                            </ItemTemplate>  
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Contact No." ControlStyle-Width="110" HeaderStyle-ForeColor="white">  
                            <ItemTemplate>  
                                <asp:TextBox ID="conNo" runat="server" Text='<%# Eval("ContactNo") %>' CssClass="form-control input-md editField"/>
                                 <asp:CompareValidator ID="cv" runat="server" ControlToValidate="conNo" Type="Integer" Operator="DataTypeCheck" ErrorMessage="Invalid contact number" Display="Dynamic" ForeColor="Red"/>
                            </ItemTemplate>  
                        </asp:TemplateField>  

                         <asp:TemplateField HeaderText="Preferred date" ControlStyle-Width="120" HeaderStyle-ForeColor="white">  
                            <ItemTemplate>  
                                <asp:TextBox ID="lecDate" runat="server" Text='<%# Eval("LectDate") %>' CssClass="form-control input-md editField"/>
                                <asp:CompareValidator ErrorMessage="Invalid date format" Display="Dynamic" ID="bdayVal" ControlToValidate="lecDate" Operator="DataTypeCheck" Type="Date" runat="server"  ForeColor="red"></asp:CompareValidator> 
                            </ItemTemplate>  
                        </asp:TemplateField>  

                         <asp:TemplateField HeaderText="Date placed" ControlStyle-Width="180" HeaderStyle-ForeColor="white">  
                            <ItemTemplate>  
                                <asp:Label ID="dtPlaced" runat="server" Text='<%# Eval("DatePlaced") %>'/>
                            </ItemTemplate>  
                        </asp:TemplateField>  

                          <asp:TemplateField HeaderText="Status" ControlStyle-Width="100" HeaderStyle-ForeColor="white">  
                            <ItemTemplate >  
                               
                                <asp:DropDownList ID="status" runat="server" DataSourceID="StatusSource" DataTextField="Status" DataValueField="Id" SelectedValue='<%# Eval("Status") %>' CssClass="form-control input-md editField">
                                    
                     
                                    </asp:DropDownList>
                                <asp:SqlDataSource ID="StatusSource" runat="server" ConnectionString="<%$ ConnectionStrings:OCDB%>" SelectCommand="Select * from Status" SelectCommandType="Text"></asp:SqlDataSource>
                            </ItemTemplate>  

                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Save" HeaderStyle-ForeColor="white">  
                            <ItemTemplate>  
                                <asp:Button ID="saveButton" runat="server" Text="Save changes" CommandName="saveBooking" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CssClass="btn btn-secondary" />
                            </ItemTemplate>  
                        </asp:TemplateField> 
                     <asp:TemplateField HeaderText="Delete" HeaderStyle-ForeColor="white">  
                            <ItemTemplate>  
                                <asp:Button ID="deleteButton" runat="server" Text="Delete" CommandName="deleteBooking" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CssClass="btn btn-secondary" OnClientClick="return confirm('Are you sure?')"/>
                            </ItemTemplate>  
                        </asp:TemplateField> 

 
                    </Columns>  
        
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />  
                    <HeaderStyle ForeColor="Yellow"  />  
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />  
                    <RowStyle BackColor="FloralWhite" ForeColor="Black"  Height="100" CssClass="gridBorder"/>  
                    <SelectedRowStyle BackColor="Black" Font-Bold="True" ForeColor="#CCFF99" />  
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />  
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />  
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />  
                    <SortedDescendingHeaderStyle BackColor="#002876" />  
       
      
                </asp:GridView> 

             
        
    
        
    
           
               
     
            
                           
</asp:Content>
