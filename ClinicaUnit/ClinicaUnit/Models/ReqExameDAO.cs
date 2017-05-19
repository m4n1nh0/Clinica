using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
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
                cmd = new SqlCommand("SELECT * FROM [REQ_EXAME] WHERE [id_paciente] = @paciente and [id_exame] = @exame and [DTEXAME] = @data", tran.Connection, tran);
                cmd.Parameters.AddWithValue("@paciente", id_paciente);
                cmd.Parameters.AddWithValue("@exame", id_exame);
                DateTime dt = DateTime.ParseExact("01-01-0001 00:00:00", "dd-MM-yyyy HH:mm:ss", null);
                if (dtconsulta == dt)
                {
                    dtconsulta = DateTime.ParseExact("01-01-1800 00:00:00", "dd-MM-yyyy HH:mm:ss", null);
                }
                cmd.Parameters.AddWithValue("@data", dtconsulta);
                Req_exame ReqExame = null;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    ReqExame = new Req_exame();
                    ReqExame.id_paciente = Convert.ToInt32(dr["id_paciente"]);
                    ReqExame.id_exame = Convert.ToInt32(dr["id_exame"]);
                    ReqExame.dtexame = Convert.ToDateTime(dr["DTEXAME"]);
                    ReqExame.dtexameup = ReqExame.dtexame.ToString();
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
                string query;
                DateTime dt = DateTime.ParseExact("01-01-0001 00:00:00", "dd-MM-yyyy HH:mm:ss", null);
                if (Data == dt)
                {
                    query = @"SELECT * FROM REQ_EXAME R JOIN EXAME E ON R.id_exame = E.Id 
						                                   JOIN PACIENTE P ON R.id_paciente = P.Id
						                                   FULL OUTER JOIN CONVENIO C ON R.CONVENIO = C.Id
                                          WHERE (R.id_paciente is not null) and
                                                (R.DTEXAME >= @data) and
                                                (@nomepaci is null or P.NOME = @nomepaci) and
                                                (@nomeconv is null or E.NOME = @nomeconv)
                                          ORDER BY 3 desc;";
                    cmd = new SqlCommand(query, tran.Connection, tran);
                }
                else
                {
                    query = @"SELECT * FROM REQ_EXAME R JOIN EXAME E ON R.id_exame = E.Id 
						                                   JOIN PACIENTE P ON R.id_paciente = P.Id
						                                   FULL OUTER JOIN CONVENIO C ON R.CONVENIO = C.Id
                                          WHERE (R.id_paciente is not null) and
                                                (R.DTEXAME = @data) and
                                                (@nomepaci is null or P.NOME = @nomepaci) and
                                                (@nomeconv is null or E.NOME = @nomeconv)
                                          ORDER BY 3 desc;";
                    cmd = new SqlCommand(query, tran.Connection, tran);
                }

                if (Data == dt)
                {
                    DateTime dtvalid = DateTime.ParseExact("01-01-1800 00:00:00", "dd-MM-yyyy HH:mm:ss", null);
                    cmd.Parameters.AddWithValue("@data", dtvalid);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@data", Data);
                }

                //if (String.IsNullOrEmpty(Data))
                //{
                //    Data = "01-01-1800 00:00:00";
                //    DateTime dt = DateTime.ParseExact(Data, "dd-MM-yyyy HH:mm:ss", null);
                //    cmd.Parameters.AddWithValue("@data", dt);
                //}
                //else
                //{
                //    Data = Data.Replace("/", "-");
                //    Data = Data + " 00:00:00";
                //    DateTime dt = DateTime.ParseExact(Data, "dd-MM-yyyy HH:mm:ss", null);
                //    cmd.Parameters.AddWithValue("@data", dt);
                //}

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
                    ReqExame.id_paciente = Convert.ToInt32((dr.GetValue(0)) == DBNull.Value ? 0 : (dr.GetValue(0)));
                    ReqExame.nomePaci = Convert.ToString((dr.GetValue(10)));
                    ReqExame.dtexame = Convert.ToDateTime((dr.GetValue(2)));
                    ReqExame.id_exame = Convert.ToInt32((dr.GetValue(1)));
                    ReqExame.nomeExame = Convert.ToString((dr.GetValue(7)));
                    ReqExame.id_convenio = Convert.ToInt32((dr.GetValue(5)).ToString() == "-1" ? 0 : (dr.GetValue(5)));
                    ReqExame.nomeConv = Convert.ToString((dr.GetValue(20)));
                    ReqExame.tipo = Convert.ToChar((dr.GetValue(4)));
                    ReqExame.valor = Convert.ToDecimal((dr.GetValue(3)) == DBNull.Value ? 0.00 : (dr.GetValue(3)));
                    List.Add(ReqExame);                    
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
                                                     [CONVENIO]) 
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
                                              WHERE [ID_PACIENTE] = @id_paciente and
                                                    [ID_EXAME] = @id_exame and
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
                reqExame.dtexameup = reqExame.dtexameup.Replace("/", "-");
                DateTime dt = DateTime.ParseExact(reqExame.dtexameup, "dd-MM-yyyy HH:mm:ss", null);
                reqExame.dtexame = dt;
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