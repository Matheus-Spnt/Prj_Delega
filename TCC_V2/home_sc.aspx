<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home_sc.aspx.cs" Inherits="TCC_V2.home_sc" %>

<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="estilo.css" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css2?family=Oxanium&display=swap" rel="stylesheet">
    <style>
        body {
            font-family: 'Oxanium', sans-serif;
        }        
    </style>
    <title>Hub Vota&ccedil;a&#771;o</title>
</head>  
<body>
    <form runat="server">
    <header class="hedr2">
        <img class="user_pic"  src="../IMG/Mask_group.svg" >
        <asp:Label ID="lbl_user1" class="user_name" runat="server" Text="João da Silva"></asp:Label>
        <h1 class="h1_user">PORTO DELEGA</h1>
        <a class="link_leave" href="index.aspx">Sair -></a>
    </header>
    <div class="bar_4"></div>
    <h2 class="titulo_reco" >A Fazer</h2>
    <div class="vota_1" >
        <img class="vota_logo" src="../IMG/sparkles.svg" alt="Icone de votacao">
        <div class="bar_5" ></div>
    </div>
    <asp:Panel ID="Panel1" runat="server">
    </asp:Panel>
    <h2 class="titulo_reco_2" >Finalizadas</h2>
    
    <asp:Panel ID="Panel2" runat="server" >
    </asp:Panel>
    
    
    </form>
</body>
</html>
