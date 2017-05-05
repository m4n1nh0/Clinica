using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ClinicaUnit.Models
{
    public class ConsultaDAO : DBConect
    {

        #region Contrutor
        public ConsultaDAO()
        {
            Consulta consulta = new Consulta();
        }
        #endregion

        #region Menbros da Interface IDataAccessObject<Consulta>
        public Consulta ObterConsulta(Int32 id_paciente, Int32 id_convenio, Int32 id_medico, DateTime dtconsulta)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM [CONSULTA] WHERE [id_paciente] = @paciente and [id_convenio] = @convenio and [id_medico] = @medico and [DTCONSULTA] = @data", con);
                cmd.Parameters.AddWithValue("@paciente", id_paciente);
                cmd.Parameters.AddWithValue("@convenio", id_convenio);
                cmd.Parameters.AddWithValue("@medico", id_medico);
                cmd.Parameters.AddWithValue("@data", dtconsulta);
                Consulta consulta = null;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    consulta = new Consulta();
                    consulta.id_paciente = Convert.ToInt32(dr["id_paciente"]);
                    consulta.id_convenio = Convert.ToInt32(dr["id_convenio"]);
                    consulta.id_medico = Convert.ToInt32(dr["id_medico"]);
                    consulta.dtconsulta = Convert.ToDateTime(dr["DTCONSULTA"]);
                    consulta.turno = Convert.ToChar(dr["TURNO"]);
                    consulta.situacao = Convert.ToChar(dr["SITUACAO"]);
                    consulta.medicamentos = Convert.ToString(dr["MEDICAMENTOS"]);               
                }
                return consulta;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao obter dados: " + e.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }
        public List<Consulta> ListarConsulta(DateTime Data, String nomePaci, String nomeConv, String nomeMed)
        {
            try
            {

                return List;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao listar Consultas: " + e.Message);
            }
            finally
            {
                this.FecharConexao();
            }            
        }
        #endregion

    }
}