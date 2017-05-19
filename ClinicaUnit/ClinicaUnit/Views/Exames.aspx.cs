using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaUnit.Views
{
    public partial class Exames : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id_paciente"] == null)
                {
                    Cadastro.ChangeMode(FormViewMode.Insert);
                }else
                {
                    RadioButtonList situacao = (RadioButtonList)Cadastro.FindControl("SITUACAO");
                    if (situacao.SelectedValue.Equals("P"))
                    {
                        
                        DropDownList convenio = (DropDownList)Cadastro.FindControl("CONVENIO");
                        TextBox valor = (TextBox)Cadastro.FindControl("VAL");
                        convenio.Enabled = false;
                        valor.Enabled = true;                       
                    }
                    else
                    {
                        DropDownList convenio = (DropDownList)Cadastro.FindControl("CONVENIO");
                        TextBox valor = (TextBox)Cadastro.FindControl("VAL");
                        convenio.Enabled = true;
                        valor.Enabled = false;
                    }
                }
            }
            else
            {
             RadioButtonList situacao = (RadioButtonList)Cadastro.FindControl("SITUACAO");
                if (situacao.SelectedValue.Equals("P"))
                {
                
                    DropDownList convenio = (DropDownList)Cadastro.FindControl("CONVENIO");
                    TextBox valor = (TextBox)Cadastro.FindControl("VAL");
                    //TextBox Data = (TextBox)Cadastro.FindControl("DATA");
                    convenio.Enabled = false;
                    valor.Enabled = true;
                    if (Cadastro.CurrentMode.Equals(FormViewMode.Edit)) {
                        valor.Text = valor.Text.Replace(",", ".");
                        //Data.Text = Data.Text.Replace("/", "-");
                        //Data.Text = Data.Text.Replace("00:00:00", "");
                    }
                }
                else
                {
                    DropDownList convenio = (DropDownList)Cadastro.FindControl("CONVENIO");
                    TextBox valor = (TextBox)Cadastro.FindControl("VAL");
                    //TextBox Data = (TextBox)Cadastro.FindControl("DATA");
                    convenio.Enabled = true;
                    valor.Enabled = false;
                    valor.Text = "0,00";
                    if (Cadastro.CurrentMode.Equals(FormViewMode.Edit)) {
                        valor.Text = valor.Text.Replace(",", ".");
                        //Data.Text = Data.Text.Replace("/", "-");
                        //Data.Text = Data.Text.Replace("00:00:00", "");
                        //DateTime dt = DateTime.ParseExact(Data, "dd-MM-yyyy HH:mm:ss", null);

                    }
                }
                 
                if (Request.QueryString["id_paciente"] == null)
                {
                    Response.AddHeader("REFRESH", "1;URL=ListReqExames.aspx");
                }
                else
                {
                    Response.AddHeader("REFRESH", "1;URL=ListReqExames.aspx");
                }
            }
        }

        protected void SITUACAO_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList situacao = (RadioButtonList)Cadastro.FindControl("SITUACAO");
            if (situacao.SelectedValue.Equals("P"))
            {

                DropDownList convenio = (DropDownList)Cadastro.FindControl("CONVENIO");
                TextBox valor = (TextBox)Cadastro.FindControl("VAL");
                convenio.Enabled = false;
                valor.Enabled = true;
                
            }
            else
            {
                DropDownList convenio = (DropDownList)Cadastro.FindControl("CONVENIO");
                TextBox valor = (TextBox)Cadastro.FindControl("VAL");
                convenio.Enabled = true;
                valor.Enabled = false;
                valor.Text = "0,00";
            }
        }
    }
}