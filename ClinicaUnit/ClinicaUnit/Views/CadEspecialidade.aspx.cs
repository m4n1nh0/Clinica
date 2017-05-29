using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaUnit.Views
{
    public partial class CadEspecialidade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    Cadastro.ChangeMode(FormViewMode.Insert);
                }
            }
            else
            {
                if (Request.QueryString["id"] == null)
                {
                    Response.AddHeader("REFRESH", "1;URL=ListEspecialidade.aspx");
                }
                else
                {
                    Response.AddHeader("REFRESH", "1;URL=ListEspecialidade.aspx");
                }

            }
        }
    }
}