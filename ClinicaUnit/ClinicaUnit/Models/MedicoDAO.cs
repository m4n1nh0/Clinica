using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ClinicaUnit.Models
{
    public class MedicoDAO : DBConect
    {
        #region Contrutor
        public MedicoDAO()
        {
            Medico medico = new Medico();
        }
        #endregion
        #region Menbros da Interface IDataAccessObject<Medico>
        public Medico ObterMedico(Int32 id_medico)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM [MEDICO] WHERE [Id] = @medico", con);
                cmd.Parameters.AddWithValue("@medico", id_medico);
                Medico medico = null;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    medico = new Medico();
                    medico.id = Convert.ToInt32(dr["Id"]);
                    medico.nome = Convert.ToString(dr["Nome"]);
                    medico.telefone = Convert.ToString(dr["Telefone"]);
                    medico.cidade = Convert.ToString(dr["Cidade"]);
                    medico.cpf = Convert.ToString(dr["CPF"]);
                    medico.crm = Convert.ToChar(dr["CRM"]);
                    medico.endereco = Convert.ToString(dr["Endereco"]);
                    medico.turno = Convert.ToChar(dr["Turno"]);
                    medico.uf = Convert.ToChar(dr["UF"]);
                }
                return medico;
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

        public List<Medico> ListarMedico(String nome, String cidade, String endereco, String uf)
        {
            try
            {
                this.AbrirConexao();
                string query = @"SELECT * FROM [MEDICO]
                                          WHERE (@nome is null or [Nome] = @nome
                                                 @cidade is null or [CIDADE] = @cidade
                                                 @endereco is null or [ENDERECO] = @endereco   
                                                 @uf is null or [UF] = @uf
                                                )";
                cmd = new SqlCommand(query, tran.Connection, tran);
                if (String.IsNullOrEmpty(nome))
                {
                    cmd.Parameters.AddWithValue("@nome", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                }
                if (String.IsNullOrEmpty(cidade))
                {
                    cmd.Parameters.AddWithValue("@cidade", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@cidade", cidade);
                }
                if (String.IsNullOrEmpty(endereco))
                {
                    cmd.Parameters.AddWithValue("@endereco", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@endereco", endereco);
                }
                if (String.IsNullOrEmpty(uf))
                {
                    cmd.Parameters.AddWithValue("@uf", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@uf", uf);
                }

                dr = cmd.ExecuteReader();
                List<Medico> List = new List<Medico>();
                while (dr.Read())
                {
                    Medico medico = new Medico();
                    medico.id = Convert.ToInt32(dr["Id"]);
                    medico.nome = Convert.ToString(dr["Nome"]);
                    medico.telefone = Convert.ToString(dr["Telefone"]);
                    medico.cidade = Convert.ToString(dr["Cidade"]);
                    medico.cpf = Convert.ToString(dr["CPF"]);
                    medico.crm = Convert.ToChar(dr["CRM"]);
                    medico.endereco = Convert.ToString(dr["Endereco"]);
                    medico.turno = Convert.ToChar(dr["Turno"]);
                    medico.uf = Convert.ToChar(dr["UF"]);
                }
                return List;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao listar Medico: " + e.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }
        public void Insert(Medico medico)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand(@"INSERT INTO [MEDICO] 
                                                    ([NOME],
                                                     [TELEFONE],
                                                     [CIDADE],
                                                     [CPF],
                                                     [CRM],
                                                     [ENDERECO],
                                                     [TURNO],
                                                     [UF]) 
                                              VALUES (@nome,
                                                      @telefone,
                                                      @cidade,
                                                      @cpf,
                                                      @crm,
                                                      @endereco,
                                                      @turno,
                                                      @uf)", tran.Connection, tran);
                cmd.Parameters.AddWithValue("@nome", medico.nome);
                cmd.Parameters.AddWithValue("@telefone", medico.telefone);
                cmd.Parameters.AddWithValue("@cidade", medico.cidade);
                cmd.Parameters.AddWithValue("@cpf", medico.cpf);
                cmd.Parameters.AddWithValue("@crm", medico.crm);
                cmd.Parameters.AddWithValue("@endereco", medico.endereco);
                cmd.Parameters.AddWithValue("@turno", medico.turno);
                cmd.Parameters.AddWithValue("@uf", medico.uf);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();

            }
            catch (Exception e)
            {
                tran.Rollback();
                throw new Exception("Erro ao Inserir Medico: " + e.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }
        public void Delete(Medico medico)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand(@"DELETE FROM [MEDICO] 
                                              WHERE [ID] = @id_medico", tran.Connection, tran);
                cmd.Parameters.AddWithValue("@id_medico", medico.id);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw new Exception("Erro ao Deletar Medico: " + e.Message);
            }
            finally
            {
                this.FecharConexao();
            }

        }

        public void UPDATE(Medico medico)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand(@"UPDATE [MEDICO] 
                                              SET   [telefone] = @telefone,
                                                    [Cidade] = @cidade,
                                                    [ENDERECO] = @endereco,
                                                    [TURNO] = @turno,
                                                    [UF] = @uf
                                              WHERE [ID] = @id_medico", tran.Connection, tran);

                cmd.Parameters.AddWithValue("@id_medico", medico.id);
                cmd.Parameters.AddWithValue("@telefone", medico.telefone);
                cmd.Parameters.AddWithValue("@cidade", medico.cidade);
                cmd.Parameters.AddWithValue("@endereco", medico.endereco);
                cmd.Parameters.AddWithValue("@turno", medico.turno);
                cmd.Parameters.AddWithValue("@uf", medico.uf);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw new Exception("Erro ao Atualizar Medico: " + e.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }
        #endregion
    }
}