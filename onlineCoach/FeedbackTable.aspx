<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FeedbackTable.aspx.cs" Inherits="onlineCoach.FeedbackTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
     <h2 class="title">Recent feedback</h2>
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="10" HeaderStyle-BackColor="#d9230f" HeaderStyle-Height="30">  
                    <Columns>  
                        
                        <asp:TemplateField HeaderText="Name" ControlStyle-Width="200" HeaderStyle-ForeColor="white">  
                            <ItemTemplate>  
                                
                                <asp:Label ID="name" runat="server" Text='<%# Eval("FullName") %>'></asp:Label>
                                
                            </ItemTemplate>  
                        </asp:TemplateField>  
                        
                         <asp:TemplateField HeaderText="Email address" ControlStyle-Width="200" HeaderStyle-ForeColor="white">  
                            <ItemTemplate>  
                                <asp:Label ID="lName" runat="server" Text='<%# Eval("EmailAddress") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Comment" HeaderStyle-ForeColor="white">  
                            <ItemTemplate>  
                                <asp:Label ID="email" runat="server" Text='<%# Eval("Comment") %>'/>
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
