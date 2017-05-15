using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaUnit.Views
{
    public partial class CadMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null && !IsPostBack)
            {
                Cadastro.ChangeMode(FormViewMode.Insert);
            }
        }
    }
}