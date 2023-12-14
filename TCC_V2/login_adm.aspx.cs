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
    public partial class login_adm : System.Web.UI.Page
    {
        usuario user1 = new usuario();
        cls_dado_banco_31682.cls_dado_banco_31682 banco = null;
        int i;
        protected void Page_Load(object sender, EventArgs e)
        {
            banco = new cls_dado_banco_31682.cls_dado_banco_31682();
            banco.linhaConexao = cls_con_banco_31682.cls_con_banco_31682.Local();
        }

        protected void btn_log_Click(object sender, EventArgs e)
        {
            if (log_user.Text == "") { lblMsg.Text = "CPF do usuário é Obrigatório!"; return; }
            if (log_user_pass1.Text == "") { lblMsg.Text = "Senha é Obrigatório!"; return; }

            MySqlDataReader dados = null;


            string query = "select cpf_adm, id_adm, senha_adm from administrador where cpf_adm = @CpfAdm and senha_adm = @SenhaAdm;";
            List<MySqlParameter> parametros = new List<MySqlParameter>
            {
                new MySqlParameter("@CpfAdm", log_user.Text),
                new MySqlParameter("@SenhaAdm", log_user_pass1.Text)
            };

            if (!banco.ConsultaPar(query, parametros, ref dados))
            {
                lblMsg.Text = "Usuário não existe. Favor Cadstrar";
                banco.Closing();
                return;
            }

            if (dados.Read())
            {
                Session["adm"] = dados["id_adm"].ToString();
                Response.Redirect("~/user_sc.aspx");
            }


        }
    }
}