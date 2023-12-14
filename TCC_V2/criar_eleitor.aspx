<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="criar_eleitor.aspx.cs" Inherits="TCC_V2.criar_eleitor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <title>Cadastra Eleitores</title>
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
    <div class="box_resul_2" >
        <div class="campo_voto_fc_3">
            <form runat="server" >
                <div class="cria_log" >
                    <p style="margin-top: 10px; margin-left: 40px; margin-bottom: -1px; color:white;">Nome:</p>  
                    <asp:TextBox class="user1" placeholder="Joa&#771;o da Silva" ID="cad_user" runat="server"  ></asp:TextBox> <br>
                    <p style="margin-top: 10px; margin-left: 40px; margin-bottom: -1px; color:white;">Senha:</p>  
                    <asp:TextBox class="pass1" placeholder="******" ID="cad_user_pass1" runat="server"  ></asp:TextBox> <br>
                    <p style="margin-top: 10px; margin-left: 40px; margin-bottom: -1px; color:white;">Confirma Senha:</p>  
                    <asp:TextBox class="pass1" placeholder="******" ID="cad_user_pass2" runat="server"  ></asp:TextBox> <br>
                    <p style="margin-top: 10px; margin-left: 40px; margin-bottom: -1px; color:white;">CPF:</p>  
                    <asp:TextBox class="user1" placeholder="xx.xxx.xxx-x" ID="cad_user_cpf" runat="server"  ></asp:TextBox> <br>
                    <p style="margin-top: 10px; margin-left: 40px; margin-bottom: -1px; color:white;">Cargo:</p>  
                    <asp:TextBox class="pass1" placeholder="1" ID="cad_user_cargo" runat="server"  ></asp:TextBox> <br>
                    <asp:Label ID="lblMsg" class="mens" runat="server" Text=""></asp:Label>
                </div>
                <div class="v_btn_2">
                    <asp:CheckBox ID="cbm1" class="v_btn_" runat="server" />
                    <label style="color: white; margin-left: -150px; margin-top: 10px;" for="conf">Confirmo o cadastro do Funiconário</label><br> 
                    <asp:Button class="btn2" ID="btn_cad" OnClick="btn_cad_Click" runat="server" Text="Cadastrar" />
                </div>
            </form>
        </div>
    </div>
</body>
</html>
