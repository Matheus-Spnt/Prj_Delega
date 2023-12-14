<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TCC_V2.login" %>



<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link href="estilo.css" rel="stylesheet" type="text/css"/>
    <link href="https://fonts.googleapis.com/css2?family=Oxanium&display=swap" rel="stylesheet"/>
    <style>
        body {
            font-family: 'Oxanium', sans-serif;
        }
    </style>
    <title>Login</title>
</head>
<body>
    <form runat="server">
    <div class="squ">
        <div class="img_hoder">
            <h1 style="margin-left: 95px; font-size: 55px; color:white;">PORTO DELEGA</h1>
            <img class="foto_log1" src="../IMG/IMG-computer-LOG.svg" alt="Imagem de login">    
        </div>
        <div class="bar"></div>
        <div class="log1">
            <form action="home_sc.aspx" target="_self">
                <p style="font-size: 25px; margin-left: 40px; color:white;">Login</p>
                <p style="margin-top: 10px; margin-left: 40px; margin-bottom: -1px; color:white;">CPF:</p>
                <asp:TextBox class="user1" placeholder="XXXXXXXXXXX" ID="log_user" runat="server"  ></asp:TextBox> <br>
                <p style="margin-top: 5px; margin-left: 40px; margin-bottom: -1px; color:white;">Senha:</p>  
                <asp:TextBox class="pass1" placeholder="******" ID="log_user_pass1" runat="server"  ></asp:TextBox> <br>
                <a style="margin-top: 10px; margin-left: 40px; margin-bottom: -1px; color:lightskyblue; float: left;" href="login_adm.aspx">Login Administrador</a>  
                <asp:Button class="btn1" ID="btn_log" OnClick="btn_log_Click" runat="server" Text="Entrar" />
            </form>
            <asp:Label ID="lblMsg" class="mens" runat="server" Text=""></asp:Label>
        </div>
    </div>
   </form>
</body>
</html>
