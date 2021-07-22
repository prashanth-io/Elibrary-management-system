<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewbook.aspx.cs" Inherits="eLIBRARY.viewbook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

     <div class="container-fluid">
        <div class="row">
           

            <div class="col-md-12">
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
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server"></asp:GridView>

                            </div>
                        </div>

                    </div>
                </div>
                 <a href="homepage.aspx"><< Back to Home</a>
                

                
                </br>
            </div>



        </div>
    </div>
    <br>
</asp:Content>
