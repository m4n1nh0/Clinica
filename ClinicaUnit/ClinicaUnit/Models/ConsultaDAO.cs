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
                this.AbrirConexao();
                string query = @"SELECT [DTCONSULTA], [id_paciente],[paciente.nome], [id_convenio], [convenio.nome], [id_medico], [medico.nome], [TURNO], [MEDICAMENTOS] 
                                          FROM [CONSULTA], [PACIENTE], [CONVENIO], [MEDICO] 
                                          WHERE ([id_paciente] = [paciente.id]) and 
                                                ([id_convenio] = [convenio.id]) and 
                                                ([id_medico]   = [medico.id]) and 
                                                (@data is null or [DTCONSULTA]  = @data) and
                                                (@nomepaci is null or [paciente.nome] = @nomepaci) and
                                                (@nomeconv is null or [convenio.nome] = @nomeconv) and
                                                (@nomemed is null or [medico.nome] = @nomemed)";
                cmd = new SqlCommand(query, tran.Connection, tran);
                if (Data == null)
                {
                    cmd.Parameters.AddWithValue("@data", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@data", Data);
                }

                if (String.IsNullOrEmpty(nomePaci))
                {
                    cmd.Parameters.AddWithValue("@nomepaci", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@nomepaci", nomePaci);
                }

                if (String.IsNullOrEmpty(nomeConv))
                {
                    cmd.Parameters.AddWithValue("@nomeconv", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@nomeconv", nomeConv);
                }

                if (String.IsNullOrEmpty(nomeMed))
                {
                    cmd.Parameters.AddWithValue("@nomemed", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@nomemed", nomeMed);
                }
                dr = cmd.ExecuteReader();
                List<Consulta> List = new List<Consulta>();
                while (dr.Read())
                {
                    Consulta consulta = new Consulta();
                    //  [DTCONSULTA], [id_paciente],[paciente.nome], [id_convenio], [convenio.nome], [id_medico], [medico.nome], [TURNO], [MEDICAMENTOS]
                    consulta.dtconsulta = Convert.ToDateTime(dr["DTCONSULTA"]);
                    consulta.id_paciente = Convert.ToInt32(dr["id_paciente"]);
                    consulta.nomePaci = Convert.ToString(dr["paciente.nome"]);
                    consulta.id_convenio = Convert.ToInt32(dr["id_convenio"]);
                    consulta.nomeConv = Convert.ToString(dr["convenio.nome"]);
                    consulta.id_medico = Convert.ToInt32(dr["id_medico"]);
                    consulta.nomeMed = Convert.ToString(dr["medico.nome"]);
                    consulta.turno = Convert.ToChar(dr["TURNO"]);
                    consulta.medicamentos = Convert.ToString(dr["MEDICAMENTOS"]);           
                }
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
        public void Insert(Consulta consulta)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand(@"INSERT INTO [CONSULTA] 
                                                    ([ID_PACIENTE], 
                                                     [ID_CONVENIO],
                                                     [ID_MEDICO],
                                                     [DTCONSULTA],
                                                     [TURNO],
                                                     [SITUACAO],
                                                     [MEDICAMENTOS],
                                                                 ) 
                                              VALUES (@id_paciente,
                                                      @id_convenio,
                                                      @id_medico,
                                                      @dtconsulta,
                                                      @turno,
                                                      @situacao,
                                                      @medicamentos)", tran.Connection, tran);
                cmd.Parameters.AddWithValue("@id_paciente", consulta.id_paciente);
                cmd.Parameters.AddWithValue("@id_convenio", consulta.id_convenio);
                cmd.Parameters.AddWithValue("@id_medico", consulta.id_medico);
                cmd.Parameters.AddWithValue("@dtconsulta", consulta.dtconsulta);
                cmd.Parameters.AddWithValue("@turno", consulta.turno);
                cmd.Parameters.AddWithValue("@situacao", consulta.situacao);
                cmd.Parameters.AddWithValue("@medicamentos", consulta.medicamentos);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();

            }
            catch (Exception e)
            {
                tran.Rollback();
                throw new Exception("Erro ao Inserir Consulta: " + e.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }
        public void Delete(Consulta consulta)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand(@"DELETE FROM [CONSULTA] 
                                              WHERE [ID_PACIENTE] = @id_paciente
                                                    [ID_CONVENIO] = @id_convenio
                                                    [ID_MEDICO] = @id_medico
                                                    [DTCONSULTA] = @dtconsulta", tran.Connection, tran);
                cmd.Parameters.AddWithValue("@id_paciente", consulta.id_paciente);
                cmd.Parameters.AddWithValue("@id_convenio", consulta.id_convenio);
                cmd.Parameters.AddWithValue("@id_medico", consulta.id_medico);
                cmd.Parameters.AddWithValue("@dtconsulta", consulta.dtconsulta);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw new Exception("Erro ao Deletar Consulta: " + e.Message);
            }
            finally
            {
                this.FecharConexao();
            }

        }

        public void UPDATE(Consulta consulta)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand(@"UPDATE [CONSULTA] 
                                              SET   [TURNO] = @turno,
                                                    [SITUACAO] = @situacao,
                                                    [MEDICAMENTOS] = @medicamentos
                                              WHERE [ID_PACIENTE] = @id_paciente
                                                    [ID_CONVENIO] = @id_convenio
                                                    [ID_MEDICO] = @id_medico
                                                    [DTCONSULTA] = @dtconsulta", tran.Connection, tran);
                cmd.Parameters.AddWithValue("@id_paciente", consulta.id_paciente);
                cmd.Parameters.AddWithValue("@id_convenio", consulta.id_convenio);
                cmd.Parameters.AddWithValue("@id_medico", consulta.id_medico);
                cmd.Parameters.AddWithValue("@dtconsulta", consulta.dtconsulta);
                cmd.Parameters.AddWithValue("@turno", consulta.turno);
                cmd.Parameters.AddWithValue("@situacao", consulta.situacao);
                cmd.Parameters.AddWithValue("@medicamentos", consulta.medicamentos);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw new Exception("Erro ao Atualizar Consulta: " + e.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }
        #endregion

    }
}