<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="eLIBRARY.adminlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    

    
<div class="container">
        <div class="row">
            <div class="col-md-5 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150px" src="imgs/admin.png">

                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Admin Login</h3>

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
                                <center>
                                    <div class="form-label">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="username" ></asp:TextBox>
                                    </div>
                                    <div class="form-label">
                                        <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" EnableViewState="False" TextMode="Password"></asp:TextBox>
                                    </div>
                                     <div class="form-label d-grid gap-2">
                                         <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                                    </div>
                                    
                                   

                                </center>
                            </div>
                        </div>
                    </div>
                </div>

                <a href="homepage.aspx"><< Back to Home</a>
                </br>
            </div>

        </div>
    </div>

</asp:Content>
