<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminmembermanagement.aspx.cs" Inherits="eLIBRARY.adminmembermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
     $(document).ready(function () {
         $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
         // $('#myTable').DataTable();
     });
      
     </script>
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
                                    <h3>Member Details</h3>
                                   
                                </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/user1.png">

                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                
                                    <hr>

                                
                            </div>
                        </div>

                         <div class="row">

                              <div class="col-md-3">
                                <label>Member ID</label>
                                    <div class="form-label">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Member ID"></asp:TextBox>
                                        <asp:LinkButton CssClass="btn btn-primary" ID="LinkButton4" runat="server" OnClick="LinkButton4_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                            </div>
                                    </div> 

                                
                            </div>
                           
                              <div class="col-md-4">
                                
                                    <label>Full Name</label>
                                   <div class="form-label">
                                       <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Full Name" ReadOnly="True"></asp:TextBox>
                                    </div>
                                
                            </div>
                             
                              <div class="col-md-5">
                                 
                                    <label>Acoount status</label>
                                   <div class="form-label">
                                         <div class="input-group">
                                             <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Account status" ReadOnly="True"></asp:TextBox>
                                         
                                              <asp:LinkButton CssClass="btn btn-success me-1" ID="LinkButton2" runat="server" OnClick="LinkButton2_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                              <asp:LinkButton CssClass="btn btn-primary me-1"  ID="LinkButton3" runat="server" OnClick="LinkButton3_Click"><i class="fas fa-clock"></i></asp:LinkButton>
                                                <asp:LinkButton  CssClass="btn btn-warning " ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><i class="fas fa-times-circle"></i></asp:LinkButton>
                                             
                                            </div>
                                    </div>
                                
                            </div>
                             
                        </div>
                       

                           <div class="row">

                             
                              <div class="col-md-3">
                                
                                    <label>DOB</label>
                                   <div class="form-label">
                                       <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="dd/mm/yyyy"  ReadOnly="True"></asp:TextBox>
                                    </div>
                                
                            </div>
                           
                              <div class="col-md-4">
                                
                                    <label>Contact No</label>
                                   <div class="form-label">
                                       <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Contact No" ReadOnly="True"></asp:TextBox>
                                    </div>
                                
                            </div>
                               
                              <div class="col-md-5">
                                
                                    <label>Email ID</label>
                                   <div class="form-label">
                                       <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Email ID" ReadOnly="True"></asp:TextBox>
                                    </div>
                                
                            </div>
                             
                            
                             
                        </div>
                       

                              <div class="row">

                             
                              <div class="col-md-4">
                                
                                    <label>State</label>
                                   <div class="form-label">
                                       <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="State" ReadOnly="True"></asp:TextBox>
                                    </div>
                                
                            </div>
                           
                              <div class="col-md-4">
                                
                                    <label>City</label>
                                   <div class="form-label">
                                       <asp:TextBox CssClass="form-control" ID="TextBox12" runat="server" placeholder="city" ReadOnly="True"></asp:TextBox>
                                    </div>
                                
                            </div>
                               
                              <div class="col-md-4">
                                
                                    <label>pincode</label>
                                   <div class="form-label">
                                       <asp:TextBox CssClass="form-control" ID="TextBox13" runat="server" placeholder="pincode" ReadOnly="True"></asp:TextBox>
                                    </div>
                                
                            </div>
                             
                            
                             
                        </div>
                       

                               <div class="row">
                           
                             
                            <div class="col-md-12">
                                
                                    <label>Full Address </label>
                                   <div class="form-label">
                                       <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Address" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                
                            </div>
                             
                             
                        </div>
                       
                        
                       
                       

                        
                        <div class="row">
                           
                             
                             <div class="col-8 d-grid gap-2 mx-auto ">
                                
                                   
                                  
                                <asp:Button CssClass="btn btn-lg btn-block btn-danger" ID="Button5" runat="server" Text="Delete User permanently" OnClick="Button5_Click" />
                                   

                                
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
                                    <h3>Member List</h3>
                                   
                                    
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                
                                    <hr>

                                
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [member_master_tb1]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="ID" ReadOnly="True" SortExpression="member_id" />
                                        <asp:BoundField DataField="full_name" HeaderText="NAME" SortExpression="full_name" />
                                        <asp:BoundField DataField="account_status" HeaderText="ACCOUNT STATUS" SortExpression="account_status" />
                                        <asp:BoundField DataField="contact_no" HeaderText="CONTACT" SortExpression="contact_no" />
                                        <asp:BoundField DataField="email" HeaderText="EMAIL" SortExpression="email" />
                                        <asp:BoundField DataField="state" HeaderText="STATE" SortExpression="state" />
                                        <asp:BoundField DataField="city" HeaderText="CITY" SortExpression="city" />
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
