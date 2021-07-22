﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbook_inventory.aspx.cs" Inherits="eLIBRARY.adminbook_inventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   
      <script type="text/javascript">
          $(document).ready(function () {
              $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
              $('#myTable').DataTable();
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
                                    <h3>Book Details</h3>
                                   
                                </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <center>
                                    <img id="imgview" width="100px" src="imgs/book.png">

                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                
                                    <hr>

                                
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                
                                <asp:FileUpload onchange="readURL(this);" CssClass="form-control" ID="FileUpload1" runat="server" />

                                
                            </div>
                        </div>

                         <div class="row">

                              <div class="col-md-4">
                                <label>Book ID</label>
                                    <div class="form-label">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Book ID"></asp:TextBox>
                                            <asp:Button ID="Button3" CssClass="form-control btn btn-primary" runat="server" Text="Go" OnClick="Button3_Click" />
                                            </div>
                                    </div> 

                                
                            </div>
                           
                              <div class="col-md-8">
                                
                                    <label>Book Name</label>
                                   <div class="form-label">
                                       <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Book Name" ></asp:TextBox>
                                    </div>
                                
                            </div>
                             
                            
                             
                        </div>
                       

                           <div class="row">

                             
                              <div class="col-md-4">
                                
                                    <label>Language</label>
                                   <div class="form-label">
                                       <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                                         <asp:ListItem Text="English" Value="English" />
                                         <asp:ListItem Text="Kannada" Value="Kannada" />
                                         <asp:ListItem Text="Hindi" Value="Hindi" />
                                         <asp:ListItem Text="Telugu" Value="Telugu" />
                                         <asp:ListItem Text="Tamil" Value="Tamil" />
                                       </asp:DropDownList>
                                        

                                    </div>
                                     <label>Publisher Name</label>
                                   <div class="form-label">
                                       <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server">
                                         <asp:ListItem Text="Publisher 1" Value="Publisher 1" />
                                         <asp:ListItem Text="Publisher 2" Value="Publisher 2" />
                                         
                                       </asp:DropDownList>
                                        

                                    </div>
                                
                            </div>
                           
                                  
                              <div class="col-md-4">
                                
                                    <label>Author Name</label>
                                   <div class="form-label">
                                       <asp:DropDownList CssClass="form-control" ID="DropDownList3" runat="server">
                                         <asp:ListItem Text="A1" Value="a1" />
                                         <asp:ListItem Text="a2" Value="a2" />
                                       
                                       </asp:DropDownList>
                                        

                                    </div>
                                     <label>Publish Date</label>
                                   <div class="form-label">
                                     
                                       <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Date" TextMode="Date"></asp:TextBox>
                                    </div>
                                
                            </div>
                               
                              <div class="col-md-4">
                                
                                    <label>Genre</label>
                                   <div class="form-label">
                                       <asp:ListBox CssClass="form-control" ID="ListBox1" runat="server" SelectionMode="Multiple" Rows="4">
                                            <asp:ListItem Text="Action" Value="Action" />
                              <asp:ListItem Text="Adventure" Value="Adventure" />
                              <asp:ListItem Text="Comic Book" Value="Comic Book" />
                              <asp:ListItem Text="Self Help" Value="Self Help" />
                              <asp:ListItem Text="Motivation" Value="Motivation" />
                              <asp:ListItem Text="Healthy Living" Value="Healthy Living" />
                              <asp:ListItem Text="Wellness" Value="Wellness" />
                              <asp:ListItem Text="Crime" Value="Crime" />
                              <asp:ListItem Text="Drama" Value="Drama" />
                              <asp:ListItem Text="Fantasy" Value="Fantasy" />
                              <asp:ListItem Text="Horror" Value="Horror" />
                              <asp:ListItem Text="Poetry" Value="Poetry" />
                              <asp:ListItem Text="Personal Development" Value="Personal Development" />
                              <asp:ListItem Text="Romance" Value="Romance" />
                              <asp:ListItem Text="Science Fiction" Value="Science Fiction" />
                              <asp:ListItem Text="Suspense" Value="Suspense" />
                              <asp:ListItem Text="Thriller" Value="Thriller" />
                              <asp:ListItem Text="Art" Value="Art" />
                              <asp:ListItem Text="Autobiography" Value="Autobiography" />
                              <asp:ListItem Text="Encyclopedia" Value="Encyclopedia" />
                              <asp:ListItem Text="Health" Value="Health" />
                              <asp:ListItem Text="History" Value="History" />
                              <asp:ListItem Text="Math" Value="Math" />
                              <asp:ListItem Text="Textbook" Value="Textbook" />
                              <asp:ListItem Text="Science" Value="Science" />
                              <asp:ListItem Text="Travel" Value="Travel" />

                                       </asp:ListBox>
                                    </div>
                                
                            </div>
                             
                            
                             
                        </div>
                       

                              <div class="row">

                             
                              <div class="col-md-4">
                                
                                    <label>Edition</label>
                                   <div class="form-label">
                                       <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="Edition" ></asp:TextBox>
                                    </div>
                                
                            </div>
                           
                              <div class="col-md-4">
                                
                                    <label>Book cost(per unit)</label>
                                   <div class="form-label">
                                       <asp:TextBox CssClass="form-control" ID="TextBox12" runat="server" placeholder="Book Cost" TextMode="Number"></asp:TextBox>
                                    </div>
                                
                            </div>
                               
                              <div class="col-md-4">
                                
                                    <label>Pages</label>
                                   <div class="form-label">
                                       <asp:TextBox CssClass="form-control" ID="TextBox13" runat="server" placeholder="pages" TextMode="Number"></asp:TextBox>
                                    </div>
                                
                            </div>
                             
                            
                             
                        </div>

                            <div class="row">

                             
                              <div class="col-md-4">
                                
                                    <label>Actual Stock</label>
                                   <div class="form-label">
                                       <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Actual Stock" TextMode="Number"></asp:TextBox>
                                    </div>
                                
                            </div>
                           
                              <div class="col-md-4">
                                
                                    <label>Current Stock</label>
                                   <div class="form-label">
                                       <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Current Stock" TextMode="Number" ReadOnly="True"></asp:TextBox>
                                    </div>
                                
                            </div>
                               
                              <div class="col-md-4">
                                
                                    <label>Issued Books</label>
                                   <div class="form-label">
                                       <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Issued Books" TextMode="Number" ReadOnly="True"></asp:TextBox>
                                    </div>
                                
                            </div>
                             
                            
                             
                        </div>
                       

                               <div class="row">
                           
                             
                            <div class="col-md-12">
                                
                                    <label>Book Description </label>
                                   <div class="form-label">
                                       <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Book Description"  TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                
                            </div>
                             
                             
                        </div>
                       
                        
                       
                       

                        
                        <div class="row">
                           
                             
                             <div class="col-4 d-grid gap-2">
                                
                                   
                                  
                                <asp:Button CssClass="btn btn-lg btn-block btn-success" ID="Button5" runat="server" Text="Add" OnClick="Button5_Click" />
                                   

                                
                            </div>
                              <div class="col-4 d-grid gap-2">
                                
                                   
                                  
                                <asp:Button CssClass="btn btn-lg btn-block btn-primary" ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
                                   

                                
                            </div>

                              <div class="col-4 d-grid gap-2">
                                
                                   
                                  
                                <asp:Button CssClass="btn btn-lg btn-block btn-danger" ID="Button2" runat="server" Text="Delete" OnClick="Button2_Click" />
                                   

                                
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
                                    <h3>Book Inventory List</h3>
                                   
                                    
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                
                                    <hr>

                                
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_master_tb1]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="BOOK_ID" ReadOnly="True" SortExpression="book_id" />
                                        <asp:TemplateField>

                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-10">
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <asp:Label ID="Label1" Font-Bold="True" runat="server" Text='<%# Eval("book_name") %>' Font-Size="X-Large"></asp:Label>
                                                                </div>
                                                            </div>
                                                             <div class="row">
                                                                <div class="col-12">

                                                                    &nbsp;Author:&nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("author_name") %>'></asp:Label>
                                                                    |&nbsp; Gener:&nbsp;<asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("gener") %>'></asp:Label>
                                                                    | Language:<asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("language") %>'></asp:Label>
                                                                 </div>
                                                            </div>
                                                             <div class="row">
                                                                <div class="col-12">

                                                                    Publisher:<asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                                    | Publish Date:<asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                                    | Pages:&nbsp;<asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("no_of_pages") %>'></asp:Label>
                                                                    |&nbsp;Edition:<asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>
                                                                    <br /> 

                                                                </div>
                                                            </div>
                                                             <div class="row">
                                                                <div class="col-12">

                                                                    Cost:<asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                                    | Actual Stock:&nbsp;
                                                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                                    |Availabl:<asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                             <div class="row">
                                                                <div class="col-12">

                                                                    Description:<asp:Label ID="Label12" runat="server" Font-Bold="True" Text='<%# Eval("book_description") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <asp:Image CssClass="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>' /></div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>

                                        </asp:TemplateField>
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
