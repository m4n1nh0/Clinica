using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ClinicaUnit.Models
{
    public class ExameDAO : DBConect
    {
        #region Contrutor
        public ExameDAO()
        {
            Exame exame = new Exame();
        }
        #endregion
        #region Menbros da Interface IDataAccessObject<Exame>
        public Exame ObterExame(Int32 id_exame)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM [EXAME] WHERE [Id] = @exame", con);
                cmd.Parameters.AddWithValue("@exame", id_exame);
                Exame exame = null;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    exame = new Exame();
                    exame.Id1 = Convert.ToInt32(dr["Id"]);
                    exame.Nome1 = Convert.ToString(dr["Nome"]);
                    exame.Obs1 = Convert.ToString(dr["OBS"]);
                }
                return exame;
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

        public List<Exame> ListarExame(String nome)
        {
            try
            {
                this.AbrirConexao();
                string query = @"SELECT * FROM [EXAME]
                                          WHERE (@nome is null or [Nome] = @nomeconv)";
                cmd = new SqlCommand(query, tran.Connection, tran);
                if (String.IsNullOrEmpty(nome))
                {
                    cmd.Parameters.AddWithValue("@nomeconv", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@nomeconv", nome);
                }

                dr = cmd.ExecuteReader();
                List<Exame> List = new List<Exame>();
                while (dr.Read())
                {
                    Exame exame = new Exame();
                    exame.Id1 = Convert.ToInt32(dr["Id"]);
                    exame.Nome1 = Convert.ToString(dr["NOME"]);
                    exame.Obs1 = Convert.ToString(dr["OBS"]);
                }
                return List;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao listar Exame: " + e.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }
        public void Insert(Exame exame)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand(@"INSERT INTO [EXAME] 
                                                    ([ID], 
                                                     [NOME],
                                                     [OBS]) 
                                              VALUES (@id,
                                                      @nome,
                                                      @obs)", tran.Connection, tran);
                cmd.Parameters.AddWithValue("@id", exame.Id1);
                cmd.Parameters.AddWithValue("@nome", exame.Nome1);
                cmd.Parameters.AddWithValue("@obs", exame.Obs1);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();

            }
            catch (Exception e)
            {
                tran.Rollback();
                throw new Exception("Erro ao Inserir Exame: " + e.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }
        public void Delete(Exame exame)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand(@"DELETE FROM [EXAME] 
                                              WHERE [ID] = @id_exame", tran.Connection, tran);
                cmd.Parameters.AddWithValue("@id_exame", exame.Id1);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw new Exception("Erro ao Deletar Exame: " + e.Message);
            }
            finally
            {
                this.FecharConexao();
            }

        }

        public void UPDATE(Exame exame)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand(@"UPDATE [EXAME] 
                                              SET   [Nome] = @nome,
                                                    [OBS] = @obs
                                              WHERE [ID] = @id_exame", tran.Connection, tran);
                cmd.Parameters.AddWithValue("@id_exame", exame.Id1);
                cmd.Parameters.AddWithValue("@nome", exame.Nome1);
                cmd.Parameters.AddWithValue("@obs", exame.Obs1);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw new Exception("Erro ao Atualizar Exame: " + e.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }
        #endregion
    }
}