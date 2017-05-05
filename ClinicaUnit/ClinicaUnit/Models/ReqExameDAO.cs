using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ClinicaUnit.Models
{
    public class ReqExameDAO : DBConect
    {
        #region Contrutor
        public ReqExameDAO()
        {
            Req_exame ReqExame = new Req_exame();
        }
        #endregion

        #region Menbros da Interface IDataAccessObject<Consulta>
        public Req_exame ObterReqExame(Int32 id_paciente, Int32 id_exame, DateTime dtconsulta)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM [EXAME] WHERE [id_paciente] = @paciente and [id_exame] = @exame and [DTCONSULTA] = @data", con);
                cmd.Parameters.AddWithValue("@paciente", id_paciente);
                cmd.Parameters.AddWithValue("@exame", id_exame);
                cmd.Parameters.AddWithValue("@data", dtconsulta);
                Req_exame ReqExame = null;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    ReqExame = new Req_exame();
                    ReqExame.id_paciente = Convert.ToInt32(dr["id_paciente"]);
                    ReqExame.id_exame = Convert.ToInt32(dr["id_exame"]);
                    ReqExame.dtexame = Convert.ToDateTime(dr["DTEXAME"]);
                    ReqExame.valor = Convert.ToDecimal(dr["VALOR"]);
                    ReqExame.tipo = Convert.ToChar(dr["TIPO"]);
                    ReqExame.convenio = Convert.ToString(dr["CONVENIO"]);
                }
                return ReqExame;
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
        public List<Req_exame> ListarReqExame(DateTime Data, String nomePaci, String nomeConv)
        {
            try
            {
                this.AbrirConexao();
                string query = @"SELECT [DTEXAME], [id_paciente],[paciente.nome], [id_convenio], [convenio.nome], [id_medico], [medico.nome], [TURNO], [MEDICAMENTOS] 
                                          FROM [EXAME], [PACIENTE], [CONVENIO]
                                          WHERE ([id_paciente] = [paciente.id]) and 
                                                ([id_convenio] = [convenio.id]) and 
                                                (@data is null or [DTCONSULTA]  = @data) and
                                                (@nomepaci is null or [paciente.nome] = @nomepaci) and
                                                (@nomeconv is null or [convenio.nome] = @nomeconv) ";
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

                dr = cmd.ExecuteReader();
                List<Req_exame> List = new List<Req_exame>();
                while (dr.Read())
                {
                    Req_exame ReqExame = new Req_exame();
                    ReqExame.id_paciente = Convert.ToInt32(dr["ID_PACIENTE"]);
                    ReqExame.id_exame = Convert.ToInt32(dr["ID_EXAME"]);
                    ReqExame.dtexame = Convert.ToDateTime(dr["DTEXAME"]);
                    ReqExame.valor = Convert.ToInt32(dr["VALOR"]);
                    ReqExame.convenio = Convert.ToString(dr["CONVENIO"]);
                    ReqExame.tipo = Convert.ToChar(dr["TIPO"]);
                }
                return List;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao listar as Requsições dos Exames: " + e.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }
        public void Insert(Req_exame reqExame)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand(@"INSERT INTO [REQ_EXAME] 
                                                    ([ID_PACIENTE], 
                                                     [ID_EXAME],
                                                     [DTEXAME],
                                                     [VALOR],
                                                     [TIPO],
                                                     [CONVENIO],
                                                                 ) 
                                              VALUES (@id_paciente,
                                                      @id_exame,
                                                      @dtexame,
                                                      @valor,
                                                      @tipo,
                                                      @convenio)", tran.Connection, tran);
                cmd.Parameters.AddWithValue("@id_paciente", reqExame.id_paciente);
                cmd.Parameters.AddWithValue("@id_exame", reqExame.id_exame);
                cmd.Parameters.AddWithValue("@dtexame", reqExame.dtexame);
                cmd.Parameters.AddWithValue("@valor", reqExame.valor);
                cmd.Parameters.AddWithValue("@tipo", reqExame.tipo);
                cmd.Parameters.AddWithValue("@convenio", reqExame.convenio);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();

            }
            catch (Exception e)
            {
                tran.Rollback();
                throw new Exception("Erro ao Inserir Requisição do Exame: " + e.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }
        public void Delete(Req_exame reqExame)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand(@"DELETE FROM [REQ_EXAME] 
                                              WHERE [ID_PACIENTE] = @id_paciente,
                                                    [ID_EXAME] = @id_exame,
                                                    [DTEXAME] = @dtexame", tran.Connection, tran);
                cmd.Parameters.AddWithValue("@id_paciente", reqExame.id_paciente);
                cmd.Parameters.AddWithValue("@id_exame", reqExame.id_exame);
                cmd.Parameters.AddWithValue("@dtexame", reqExame.dtexame);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw new Exception("Erro ao Deletar Requisição do Exame: " + e.Message);
            }
            finally
            {
                this.FecharConexao();
            }

        }

        public void UPDATE(Req_exame reqExame)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand(@"UPDATE [REQ_EXAME] 
                                              SET   [VALOR] = @valor,
                                                    [TIPO] = @tipo,
                                                    [CONVENIO] = @convenio
                                              WHERE [ID_PACIENTE] = @id_paciente and
                                                    [ID_EXAME] = @id_exame and
                                                    [DTEXAME] = @dtexame", tran.Connection, tran);
                cmd.Parameters.AddWithValue("@id_paciente", reqExame.id_paciente);
                cmd.Parameters.AddWithValue("@id_exame", reqExame.id_exame);
                cmd.Parameters.AddWithValue("@dtexame", reqExame.dtexame);
                cmd.Parameters.AddWithValue("@valor", reqExame.valor);
                cmd.Parameters.AddWithValue("@tipo", reqExame.tipo);
                cmd.Parameters.AddWithValue("@convenio", reqExame.convenio);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw new Exception("Erro ao Atualizar Requisição do Exame: " + e.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }
        #endregion

    }
}