using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.IO;


namespace TCC_V2
{
    public partial class criar_eleitor : System.Web.UI.Page
    {
        int usuario1;
        cls_dado_banco_31682.cls_dado_banco_31682 banco = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario1 = Convert.ToInt32(Session["adm"]);

            banco = new cls_dado_banco_31682.cls_dado_banco_31682();
            banco.linhaConexao = cls_con_banco_31682.cls_con_banco_31682.Local();
            MySqlDataReader dados = null;

            #region Nome

            string nomeQuery = "SELECT nome_adm FROM administrador WHERE id_adm = @UsuarioID;";
            List<MySqlParameter> nomeParametros = new List<MySqlParameter>
            {
                new MySqlParameter("@UsuarioID", usuario1)
            };

            if (!banco.ConsultaPar(nomeQuery, nomeParametros, ref dados))
            {
                lbl_user1.Text = "Erro";
            }

            if (dados.Read())
            {
                lbl_user1.Text = dados["nome_adm"].ToString();
            }

            #endregion

        }
        protected void btn_cad_Click(object sender, EventArgs e)
        {
            #region Teste
            if (cad_user.Text == "") { lblMsg.Text = "Nome do usuário é Obrigatório!"; return; }
            if (cad_user_pass1.Text == "") { lblMsg.Text = "Senha é Obrigatório!"; return; }
            if (cad_user_pass2.Text == "") { lblMsg.Text = "Confirmar senha é Obrigatório!"; return; }
            if (cad_user_cargo.Text == "") { lblMsg.Text = "Cargo é Obrigatório!"; return; }
            if (cad_user_cpf.Text == "") { lblMsg.Text = "CPF do usuário é Obrigatório!"; return; }

            if (cad_user_pass1.Text != cad_user_pass2.Text)
            {
                lblMsg.Text = "Ambas as senhas devem ser iguais";
            }

            #endregion

            string comando = "INSERT INTO funcionario (nome_funcionario, cpf_funcionario, senha_funcionario , administrador_id_adm, cargos_id_cargos) " +
            " VALUES (@NomeFun, @CpfFun, @SenhaFun, @IDAdm, @IDCargo);";

            List<MySqlParameter> parametros = new List<MySqlParameter>
            {
                new MySqlParameter("@NomeFun", cad_user.Text),
                new MySqlParameter("@CpfFun", cad_user_cpf.Text),
                new MySqlParameter("@SenhaFun", cad_user_pass1.Text),
                new MySqlParameter("@IDAdm", lbl_user1.Text),
                new MySqlParameter("@IDCargo", cad_user_cargo.Text)
            };

            if (!banco.Execute(comando, parametros))
            {
                lblMsg.Text = "Problemas na criação de usuário";
                banco.Closing();
                return;
            }
            else
            {
                Response.Redirect("~/user_sc.aspx");
            }

        }
    }
}