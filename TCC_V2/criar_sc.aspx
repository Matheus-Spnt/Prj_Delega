<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="criar_sc.aspx.cs" Inherits="TCC_V2.criar_sc" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="estilo.css" rel="stylesheet" type="text/css" >
    <link href="https://fonts.googleapis.com/css2?family=Oxanium&display=swap" rel="stylesheet">
    <style>
        body {
            font-family: 'Oxanium', sans-serif;
        }
    </style>
    <title>Criar vota&ccedil;a&#771;o</title>
</head>
<body>
    <header class="hedr2">
        <img class="user_pic"  src="../IMG/Mask_group.svg" >
        <asp:Label ID="lbl_user1" class="user_name" runat="server" Text="Joao da Silva"></asp:Label>
        <h1 class="h1_user">PORTO DELEGA</h1>
        <a class="link_leave" href="user_sc.aspx">Voltar -></a>
    </header>
    <div class="bar_4"></div>
    <div class="vota" >
        <img class="vota_logo" src="../IMG/sparkles.svg" alt="Icone de vota&ccedil;a&#771;o">
        <div class="bar_5" ></div>
        <p class="vota_txt_4" >IDs de cargos</p>
        <p class="vota_txt_2" >1-Transporte</p>
        <p class="vota_txt_2" >2-Carregador</p>
        <p class="vota_txt_2" >3-Vistoria</p>
    </div>
    <div class="box_resul_5" >
        <div class="campo_voto_fc_3">
            <form runat="server" >
                <div class="cria_log_3" >
                    <p style="margin-top: 10px; margin-left: 40px; margin-bottom: -1px; color:white;">Titulo Fun&ccedil;a&#771;o:</p>  
                    <asp:TextBox ID="txt_titulo" placeholder="Carregar caixas" class="user1" runat="server"></asp:TextBox> <br>
                    <p style="margin-top: 5px; margin-left: 40px; margin-bottom: -1px; color:white;">Descri&ccedil;a&#771o:</p>  
                    <asp:TextBox ID="txt_desc" class="pass1" placeholder="Deve-se carregar caixas" runat="server"></asp:TextBox>  <br>
                    <p style="margin-top: 5px; margin-left: 40px; margin-bottom: -1px; color:white;">Nome Funcionario:</p>  
                    <asp:TextBox ID="txt_func" class="pass1" placeholder="Maria Oliveira" runat="server"></asp:TextBox> <br>
                    <p style="margin-top: 5px; margin-left: 40px; margin-bottom: -1px; color:white;">Cargo:</p>  
                    <asp:TextBox ID="txt_cargo" class="pass1" placeholder="1" runat="server"></asp:TextBox> <br>
                    <asp:Label ID="lblMsg" class="mens" runat="server" Text=""></asp:Label>
                </div>
                
                <div class="v_btn_2">
                    <asp:CheckBox ID="cbm1" class="v_btn_" runat="server" />
                    <label style="color: white; margin-left: -150px; margin-top: 10px;" for="conf">Confirmo a cria&ccedil;a&#771;o da fun&ccedil;a&#771;o</label><br> 
                    <asp:Button ID="btn_upload" OnClick="btn_upload_Click" class="v_btn_3" runat="server" Text="Criar" />
                </div>
            </form>
        </div>
    </div>
</body>
</html>
