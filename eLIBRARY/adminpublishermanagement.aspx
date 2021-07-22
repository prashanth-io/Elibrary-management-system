<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminpublishermanagement.aspx.cs" Inherits="eLIBRARY.adminpublishermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
     $(document).ready(function () {
         $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
         // $('#myTable').DataTable();
     });
      
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

  <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                       
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Publisher Details</h3>
                                   
                                </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/publisher.png">

                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                
                                    <hr>

                                
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-md-4">
                                
                                    <div class="form-label">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Publisher ID" ></asp:TextBox>
                                         <asp:Button CssClass="btn btn-primary" ID="Button2" runat="server" Text="Go" OnClick="Button2_Click" />
                                            </div>
                                    </div> 

                                
                            </div>
                              <div class="col-md-8">
                                
                                    
                                   <div class="form-label">
                                       <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Publisher Name" ></asp:TextBox>
                                    </div>
                                
                            </div>
                        </div>
                       

                       

                        
                        <div class="row">
                            <div class="col-4 ">
                                
                                   
                                  
                                <asp:Button CssClass="btn btn-lg btn-block btn-success" ID="Button3" runat="server" Text="Add" OnClick="Button3_Click" />
                                   

                                
                            </div>
                             <div class="col-4 ">
                                
                                   
                                  
                                <asp:Button CssClass="btn btn-lg btn-block btn-primary" ID="Button4" runat="server" Text="Update" OnClick="Button4_Click" />
                                   

                                
                            </div>
                             <div class="col-4 ">
                                
                                   
                                  
                                <asp:Button CssClass="btn btn-lg btn-block btn-warning" ID="Button5" runat="server" Text="Delete" OnClick="Button5_Click" />
                                   

                                
                            </div>


                        </div>

                    </div>
                </div>

                
                </br>
            </div>

            <div class="col-md-6">
                 <div class="card">
                    <div class="card-body">
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Publisher List</h3>
                                   
                                    
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                
                                    <hr>

                                
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [publisher_master_tb1]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="publisher_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="publisher_id" HeaderText="publisher_id" ReadOnly="True" SortExpression="publisher_id" />
                                        <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
                                    </Columns>
                                </asp:GridView>

                            </div>
                        </div>

                    </div>
                </div>
            </div>



        </div>
    </div>

</asp:Content>
