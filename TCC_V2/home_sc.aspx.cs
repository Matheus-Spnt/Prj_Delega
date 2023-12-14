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
    
    public partial class home_sc : System.Web.UI.Page
    {
        int usuario1;
        string holder, idfunc, idcargo, idfun, idadm, nome, desc;
        cls_dado_banco_31682.cls_dado_banco_31682 banco = null;
        MySqlDataReader dados = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            
            usuario1 = Convert.ToInt32(Session["user"]);

            banco = new cls_dado_banco_31682.cls_dado_banco_31682();
            banco.linhaConexao = cls_con_banco_31682.cls_con_banco_31682.Local();
            //MySqlDataReader dados = null;

            #region Nome

            string nomeQuery = "SELECT f.nome_funcionario, f.cargos_id_cargos FROM funcionario f join cargos c on(c.id_cargos = f.cargos_id_cargos) WHERE f.id_funcionario = @UsuarioID;";
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
                lbl_user1.Text = dados["nome_funcionario"].ToString();
                holder = dados["cargos_id_cargos"].ToString();
            }

            #endregion


            #region Fazer
            if (!banco.Consult("select fn.id_funcoes, fn.nome_funcoes, fn.desc_funcoes from funcoes fn join cargos c on(c.id_cargos = fn.cargos_id_cargos) join funcionario f on(f.id_funcionario = fn.funcionario_id_funcionario) where fn.funcionario_id_funcionario =" + usuario1 + " and ex_funcoes = 1 and fn.cargos_id_cargos=" + holder + " ; ", ref dados))
            {
                Panel caixa1 = new Panel();
                caixa1.CssClass = "box_resul_3";
                Panel caixa2 = new Panel();
                caixa2.CssClass = "campo_voto_fc_4";
                Panel caixa3 = new Panel();
                caixa3.CssClass = "cria_log_2";
                Panel img = new Panel();
                img.CssClass = "img_mid";
                Label lbl_ti1 = new Label();
                lbl_ti1.CssClass = "texto_mini";
                lbl_ti1.Text = "Problemas na consulta ao servidor";
                Label lbl_par1 = new Label();
                lbl_par1.CssClass = "par_mini";
                lbl_par1.Text = "Problemas na consulta ao servidor";
                Panel caixa4 = new Panel();
                caixa4.CssClass = "v_btn_4";
                caixa3.Controls.Add(img);
                caixa3.Controls.Add(lbl_ti1);
                caixa3.Controls.Add(lbl_par1);
                caixa2.Controls.Add(caixa3);
                caixa2.Controls.Add(caixa4);
                caixa1.Controls.Add(caixa2);
                Panel1.Controls.Add(caixa1);
                banco.Closing();
                return;
            }
            if (dados.HasRows)
            {
                int index = 0;
                while (dados.Read())
                {
                    if (index == 0)
                    {
                        Panel caixa1 = new Panel();
                        caixa1.CssClass = "box_resul_3";
                        Panel caixa2 = new Panel();
                        caixa2.CssClass = "campo_voto_fc_4";
                        Panel caixa3 = new Panel();
                        caixa3.CssClass = "cria_log_2";
                        Panel img = new Panel();
                        img.CssClass = "img_mid";
                        Label lbl_ti1 = new Label();
                        lbl_ti1.CssClass = "texto_mini";
                        lbl_ti1.Text = dados["nome_funcoes"].ToString();
                        Label lbl_par1 = new Label();
                        lbl_par1.CssClass = "par_mini";
                        lbl_par1.Text = dados["desc_funcoes"].ToString();
                        Panel caixa4 = new Panel();
                        caixa4.CssClass = "v_btn_6";
                        Button v_btn = new Button();
                        v_btn.CssClass = "v_btn_7";
                        v_btn.Text = "Votar";
                        v_btn.ID = dados["id_funcoes"].ToString();
                        v_btn.Click += new EventHandler(v_btn_Click);
                        caixa3.Controls.Add(img);
                        caixa3.Controls.Add(lbl_ti1);
                        caixa3.Controls.Add(lbl_par1);
                        caixa4.Controls.Add(v_btn);
                        caixa2.Controls.Add(caixa3);
                        caixa2.Controls.Add(caixa4);
                        caixa1.Controls.Add(caixa2);
                        Panel1.Controls.Add(caixa1);
                        index++;
                    }
                    else
                    {
                        Panel caixa1 = new Panel();
                        caixa1.CssClass = "box_resul_3";
                        Panel caixa2 = new Panel();
                        caixa2.CssClass = "campo_voto_fc_4";
                        Panel caixa3 = new Panel();
                        caixa3.CssClass = "cria_log_2";
                        Panel img = new Panel();
                        img.CssClass = "img_mid";
                        Label lbl_ti1 = new Label();
                        lbl_ti1.CssClass = "texto_mini";
                        lbl_ti1.Text = dados["nome_funcoes"].ToString();
                        Label lbl_par1 = new Label();
                        lbl_par1.CssClass = "par_mini";
                        lbl_par1.Text = dados["desc_funcoes"].ToString();
                        Panel caixa4 = new Panel();
                        caixa4.CssClass = "v_btn_4";
                        Button v_btn = new Button();
                        v_btn.CssClass = "v_btn_5";
                        v_btn.Text = "Votar";
                        v_btn.ID = dados["id_funcoes"].ToString();
                        v_btn.Click += new EventHandler(v_btn_Click);
                        caixa3.Controls.Add(img);
                        caixa3.Controls.Add(lbl_ti1);
                        caixa3.Controls.Add(lbl_par1);
                        caixa4.Controls.Add(v_btn);
                        caixa2.Controls.Add(caixa3);
                        caixa2.Controls.Add(caixa4);
                        caixa1.Controls.Add(caixa2);
                        Panel1.Controls.Add(caixa1);
                        index++;
                    }
                    
                }
                                
            }

            #endregion

            #region Finalizadas
            if (!banco.Consult("select fn.id_funcoes, fn.nome_funcoes, fn.desc_funcoes from funcoes fn join cargos c on(c.id_cargos = fn.cargos_id_cargos) join funcionario f on(f.id_funcionario = fn.funcionario_id_funcionario) where fn.funcionario_id_funcionario =" + usuario1 + " and ex_funcoes = 0 and fn.cargos_id_cargos=" + holder + " ;", ref dados))
            {
                Panel caixa5 = new Panel();
                caixa5.CssClass = "box_resul_3";
                Panel caixa6 = new Panel();
                caixa6.CssClass = "campo_voto_fc_4";
                Panel caixa7 = new Panel();
                caixa7.CssClass = "cria_log_2";
                Panel img2 = new Panel();
                img2.CssClass = "img_mid";
                Label lbl_ti2 = new Label();
                lbl_ti2.CssClass = "texto_mini";
                lbl_ti2.Text = "Problemas na consulta ao servidor";
                Label lbl_par2 = new Label();
                lbl_par2.CssClass = "par_mini";
                lbl_par2.Text = "Problemas na consulta ao servidor";
                Panel caixa8 = new Panel();
                caixa8.CssClass = "v_btn_4";
                caixa7.Controls.Add(img2);
                caixa7.Controls.Add(lbl_ti2);
                caixa7.Controls.Add(lbl_par2);
                caixa6.Controls.Add(caixa7);
                caixa6.Controls.Add(caixa8);
                caixa5.Controls.Add(caixa6);
                Panel2.Controls.Add(caixa5);
                banco.Closing();
                return;
            }
            if (dados.HasRows)
            {
                while (dados.Read())
                {
                    Panel caixa5 = new Panel();
                    caixa5.CssClass = "box_resul_3";
                    Panel caixa6 = new Panel();
                    caixa6.CssClass = "campo_voto_fc_4";
                    Panel caixa7 = new Panel();
                    caixa7.CssClass = "cria_log_2";
                    Panel img2 = new Panel();
                    img2.CssClass = "img_mid";
                    Label lbl_ti2 = new Label();
                    lbl_ti2.CssClass = "texto_mini";
                    lbl_ti2.Text = dados["nome_funcoes"].ToString();
                    Label lbl_par2 = new Label();
                    lbl_par2.CssClass = "par_mini";
                    lbl_par2.Text = dados["desc_funcoes"].ToString();
                    Label v_texto = new Label();
                    v_texto.CssClass = "v_texto_1";
                    v_texto.Text = "Finalizado";
                    Panel caixa8 = new Panel();
                    caixa8.CssClass = "v_btn_4";
                    //Button v_btn_2 = new Button();
                    //v_btn_2.CssClass = "v_btn_5";
                    //v_btn_2.Text = "Ver";
                    //v_btn_2.ID = dados["id_funcoes"].ToString();
                    //v_btn_2.Click += new EventHandler(v_btn_2Click);
                    caixa7.Controls.Add(img2);
                    caixa7.Controls.Add(lbl_ti2);
                    caixa7.Controls.Add(lbl_par2);
                    //caixa8.Controls.Add(v_btn_2);
                    caixa6.Controls.Add(caixa7);
                    caixa6.Controls.Add(v_texto);
                    caixa6.Controls.Add(caixa8);
                    caixa5.Controls.Add(caixa6);
                    Panel2.Controls.Add(caixa5);
                }
            }
            #endregion

        }


        protected void v_btn_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Session["funcoes"] = clickedButton.ID;
            if (!banco.Consult("select fn.id_funcoes, fn.nome_funcoes, fn.desc_funcoes from funcoes fn join cargos c on(c.id_cargos = fn.cargos_id_cargos) join funcionario f on(f.id_funcionario = fn.funcionario_id_funcionario) where fn.funcionario_id_funcionario =" + usuario1 + " and ex_funcoes = 0 and fn.cargos_id_cargos=" + holder + " and fn.id_funcoes = " + Convert.ToInt32(Session["funcoes"]) + " ;", ref dados))
            {
                banco.Closing();
                return;
            }
            if (dados.Read())
            {
                nome = dados["nome_funcoes"].ToString();
                desc = dados["desc_funcoes"].ToString();
            }

            string updateConfirmaVotoQuery = "UPDATE funcoes SET ex_funcoes = 0 WHERE id_funcoes = @FuncoesID;";
            List<MySqlParameter> updateConfirmaVotoParametros = new List<MySqlParameter>
                {
                    new MySqlParameter("@FuncoesID", Session["funcoes"])
                };

            if (!banco.Execute(updateConfirmaVotoQuery, updateConfirmaVotoParametros))
            {
                banco.Closing();
                return;
            }
            else
            {
                Response.Redirect("~/home_sc.aspx");
            }

        }

    }

}