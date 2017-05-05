using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ClinicaUnit.Models
{
    public class DBConect
    {
        protected SqlConnection con;
        protected SqlCommand cmd;
        public string StringConexao;
        protected SqlDataReader dr;
        protected SqlTransaction tran;
        protected void AbrirConexao()
        {
            try
            {
                this.StringConexao = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;

                con = new SqlConnection(StringConexao);
                con.Open();
                tran = con.BeginTransaction();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao conectar: " + ex.Message);
            }
        }

        protected void FecharConexao()
        {
            try
            {
                con.Close();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao desconectar: " + ex.Message);
            }
        }
    }
}