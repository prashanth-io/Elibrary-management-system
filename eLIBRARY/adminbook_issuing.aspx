<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbook_issuing.aspx.cs" Inherits="eLIBRARY.adminbook_issuing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
       
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                       
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Book Issuing</h3>
                                   
                                </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/book.png">

                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                
                                    <hr>

                                
                            </div>
                        </div>

                         <div class="row">
                           
                              <div class="col-md-6">
                                
                                    
                                   <div class="form-label">
                                       <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Member Id" ></asp:TextBox>
                                    </div>
                                
                            </div>
                              <div class="col-md-6">
                                
                                    <div class="form-label">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Book ID" ></asp:TextBox>
                                         <asp:Button CssClass="btn btn-primary" ID="Button2" runat="server" Text="Go" OnClick="Button2_Click" />
                                            </div>
                                    </div> 

                                
                            </div>
                        </div>
                       

                               <div class="row">
                           
                              <div class="col-md-6">
                                
                                    
                                   <div class="form-label">
                                       <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Member Name" ReadOnly="True"></asp:TextBox>
                                    </div>
                                
                            </div>
                            <div class="col-md-6">
                                
                                    
                                   <div class="form-label">
                                       <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Book Name" ReadOnly="True"></asp:TextBox>
                                    </div>
                                
                            </div>
                             
                             
                        </div>
                       
                          <div class="row">
                           
                              <div class="col-md-6">
                                
                                    <label>Start Date</label>
                                   <div class="form-label">
                                       <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Start Date" ReadOnly="False" TextMode="Date"></asp:TextBox>
                                    </div>
                                
                            </div>
                            <div class="col-md-6">
                                
                                    <label>End Date</label>
                                   <div class="form-label">
                                       <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="End Date" ReadOnly="False" TextMode="Date"></asp:TextBox>
                                    </div>
                                
                            </div>
                             
                             
                        </div>
                       
                       

                        
                        <div class="row">
                            <div class="col-6  d-grid gap-2">
                                
                                   
                                  
                                <asp:Button CssClass="btn btn-lg btn-block btn-success" ID="Button3" runat="server" Text="Issue" OnClick="Button3_Click" />
                                   

                                
                            </div>
                             
                             <div class="col-6 d-grid gap-2 ">
                                
                                   
                                  
                                <asp:Button CssClass="btn btn-lg btn-block btn-warning" ID="Button5" runat="server" Text="Return" OnClick="Button5_Click" />
                                   

                                
                            </div>


                        </div>

                    </div>
                </div>
                 <a href="homepage.aspx"><< Back to Home</a>
                

                
                </br>
            </div>

            <div class="col-md-6">
                 <div class="card">
                    <div class="card-body">
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Issued Book List</h3>
                                   
                                    
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                
                                    <hr>

                                
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_issue_tb1]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="Member Id" SortExpression="member_id" />
                                        <asp:BoundField DataField="member_name" HeaderText="Member Name" SortExpression="member_name" />
                                        <asp:BoundField DataField="book_id" HeaderText="Book Id" SortExpression="book_id" />
                                        <asp:BoundField DataField="book_name" HeaderText="Book Nmae" SortExpression="book_name" />
                                        <asp:BoundField DataField="issue_date" HeaderText="Issue Date" SortExpression="issue_date" />
                                        <asp:BoundField DataField="due_date" HeaderText="Due Date" SortExpression="due_date" />
                                    </Columns>
                                </asp:GridView>

                            </div>
                        </div>

                    </div>
                </div>
            </div>



        </div>
    </div>
    <br>
</asp:Content>
