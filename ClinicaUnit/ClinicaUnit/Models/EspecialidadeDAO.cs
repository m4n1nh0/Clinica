using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ClinicaUnit.Models
{
    public class EspecialidadeDAO : DBConect
    {
        #region Contrutor
        public EspecialidadeDAO()
        {
            Especialidade especialidade = new Especialidade();
        }
        #endregion

        #region Menbros da Interface IDataAccessObject<Especialidade>
        public Especialidade ObterEspeci(Int32 id_especi)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM [ESPECIALIDADE] WHERE [Id] = @especi", tran.Connection, tran);
                cmd.Parameters.AddWithValue("@especi", id_especi);
                Especialidade especialidade = null;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    especialidade = new Especialidade();
                    especialidade.id = Convert.ToInt32(dr["Id"]);
                    especialidade.nome = Convert.ToString(dr["Nome"]);
                    especialidade.descri = Convert.ToString(dr["DESCRICAO"]);
                }
                return especialidade;
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

        public List<Especialidade> ListarEspeci(String nome, String Descri)
        {
            try
            {
                this.AbrirConexao();
                string query = @"SELECT * FROM [ESPECIALIDADE]
                                          WHERE (@nome is null or [Nome] = @nome) and
                                                (@DESCRI is null or [DESCRICAO] = @DESCRI)";
                cmd = new SqlCommand(query, tran.Connection, tran);
                if (String.IsNullOrEmpty(nome))
                {
                    cmd.Parameters.AddWithValue("@nome", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                }

                if (String.IsNullOrEmpty(Descri))
                {
                    cmd.Parameters.AddWithValue("@DESCRI", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DESCRI", Descri);
                }
                dr = cmd.ExecuteReader();
                List<Especialidade> List = new List<Especialidade>();
                while (dr.Read())
                {
                    Especialidade especi = new Especialidade();
                    especi.id = Convert.ToInt32(dr["Id"]);
                    especi.nome = Convert.ToString(dr["NOME"]);
                    especi.descri = Convert.ToString(dr["SIGLA"]);
                    List.Add(especi);
                }
                return List;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao listar Convenio: " + e.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }
        public void Insert(Especialidade especi)
        {
            try
            {
                this.AbrirConexao();
                Int32 _id = this.ObterCodigo();
                especi.id = _id;
                cmd = new SqlCommand(@"SET IDENTITY_INSERT [ESPECIALIDADE] ON;
                                       INSERT INTO [ESPECIALIDADE] ([ID],[NOME], [DESCRICAO]) VALUES (@id_especi,@nome, @descri);
                                       SET IDENTITY_INSERT [ESPECIALIDADE] OFF;", tran.Connection, tran);
                cmd.Parameters.AddWithValue("@id_especi", especi.id);
                cmd.Parameters.AddWithValue("@nome", especi.nome);
                cmd.Parameters.AddWithValue("@descri", especi.descri);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();

            }
            catch (Exception e)
            {
                tran.Rollback();
                throw new Exception("Erro ao Inserir Especialidade: " + e.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }
        public void Delete(Especialidade especi)
        {
            try
            {
                this.AbrirConexao();
                if (!VerificaMed()) { 
                cmd = new SqlCommand(@"DELETE FROM [ESPECIALIDADE] 
                                              WHERE [ID] = @id_especi", tran.Connection, tran);
                cmd.Parameters.AddWithValue("@id_especi", especi.id);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                }
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw new Exception("Erro ao Deletar Especialidade: " + e.Message);
            }
            finally
            {
                this.FecharConexao();
            }

        }

        public void UPDATE(Especialidade especi)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand(@"UPDATE [ESPECIALIDADE] 
                                              SET   [Nome] = @nome,
                                                    [DESCRI] = @descri
                                              WHERE [ID] = @id_especi", tran.Connection, tran);
                cmd.Parameters.AddWithValue("@id_especi", especi.id);
                cmd.Parameters.AddWithValue("@nome", especi.nome);
                cmd.Parameters.AddWithValue("@descri", especi.descri);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw new Exception("Erro ao Atualizar ESPECIALIDADE: " + e.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }
        #endregion
        public Boolean VerificaMed()
        {
            try
            {
                //this.AbrirConexao();
                Boolean Teste = false;
                String query = @"SELECT* FROM[MEDICO],[ESPECIALIDADE]
                                          WHERE([Id_especi] = [ESPECIALIDADE].[id])";
                cmd = new SqlCommand(query, tran.Connection, tran);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Teste = true;
                }
                return Teste;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter Codigo" + ex.Message);
            }
        }

        public int ObterCodigo()
        {
            try
            {
                //this.AbrirConexao();
                String query = "SELECT MAX([ID]) FROM [ESPECIALIDADE]";
                cmd = new SqlCommand(query, tran.Connection, tran);
                int cod = 0;
                cod = Convert.ToInt32(cmd.ExecuteScalar() == DBNull.Value ? 0 : cmd.ExecuteScalar());
                cod++;
                return cod;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter Codigo" + ex.Message);
            }
        }

    }
}