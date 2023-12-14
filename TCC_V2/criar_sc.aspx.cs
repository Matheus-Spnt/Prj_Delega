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
    public partial class criar_sc : System.Web.UI.Page
    {
        int usuario1;
        string holder;
        cls_dado_banco_31682.cls_dado_banco_31682 banco = null;
        MySqlDataReader dados = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "text/html; charset=utf-8";

            usuario1 = Convert.ToInt32(Session["adm"]);
            
            banco = new cls_dado_banco_31682.cls_dado_banco_31682();
            banco.linhaConexao = cls_con_banco_31682.cls_con_banco_31682.Local();
            //MySqlDataReader dados = null;

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

        protected void btn_upload_Click(object sender, EventArgs e)
        {

            #region Teste
            if (txt_titulo.Text == "") { lblMsg.Text = "Nome da função é Obrigatório!"; return; }
            if (txt_desc.Text == "") { lblMsg.Text = "Descrição é Obrigatório!"; return; }
            if (txt_func.Text == "") { lblMsg.Text = "Nome do funcionário é Obrigatório!"; return; }
            if (txt_cargo.Text == "") { lblMsg.Text = "Cargo é Obrigatório!"; return; }

            #endregion

            string nomeQuery = "SELECT id_funcionario FROM funcionario WHERE nome_funcionario = @UsuarioNM;";
            List<MySqlParameter> nomeParametros = new List<MySqlParameter>
            {
                new MySqlParameter("@UsuarioNM", txt_func.Text)
            };

            if (!banco.ConsultaPar(nomeQuery, nomeParametros, ref dados))
            {
                lbl_user1.Text = "Erro";
            }

            if (dados.Read())
            {
                holder = dados["id_funcionario"].ToString();
            }




            string comando = "INSERT INTO funcoes (nome_funcoes, desc_funcoes, ex_funcoes , administrador_id_adm, cargos_id_cargos, funcionario_id_funcionario) " +
            " VALUES (@NomeFun, @DescFun, @ExFun, @IDAdm, @IDCargo, @IDFun);";

            List<MySqlParameter> parametros = new List<MySqlParameter>
            {
                new MySqlParameter("@NomeFun", txt_titulo.Text),
                new MySqlParameter("@DescFun", txt_desc.Text),
                new MySqlParameter("@ExFun", "1"),
                new MySqlParameter("@IDAdm", lbl_user1.Text),
                new MySqlParameter("@IDCargo", txt_cargo.Text),
                new MySqlParameter("@IDFun", holder)
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