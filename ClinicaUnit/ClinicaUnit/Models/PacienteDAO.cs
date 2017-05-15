using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ClinicaUnit.Models
{
    public class PacienteDAO : DBConect
    {
        #region Contrutor
        public PacienteDAO()
        {
            Paciente paciente = new Paciente();
        }
        #endregion
        #region Menbros da Interface IDataAccessObject<Paciente>
        public Paciente ObterPaciente(Int32 id_paciente)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM [PACIENTE] WHERE [Id] = @paciente", tran.Connection, tran);
                cmd.Parameters.AddWithValue("@paciente", id_paciente);
                Paciente paciente = null;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    paciente = new Paciente();
                    paciente.id = Convert.ToInt32(dr["Id"]);
                    paciente.nome = Convert.ToString(dr["Nome"]);
                    paciente.telefone = Convert.ToString(dr["Telefone"]);
                    paciente.cidade = Convert.ToString(dr["Cidade"]);
                    paciente.cpf = Convert.ToString(dr["CPF"]);
                    paciente.sexo = Convert.ToString(dr["SEXO"]);
                    paciente.endereco = Convert.ToString(dr["Endereco"]);
                    paciente.plano = Convert.ToString(dr["Plano"]);
                    paciente.uf = Convert.ToString(dr["UF"]);
                    paciente.dtnaci = Convert.ToDateTime(dr["DTNACI"]);
                }
                return paciente;
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

        public List<Paciente> ListarPaciente(String nome, String cidade, String endereco, String uf)
        {
            try
            {
                this.AbrirConexao();
                string query = @"SELECT * FROM [PACIENTE]
                                          WHERE (@nome is null or [Nome] = @nome) and
                                                (@cidade is null or [CIDADE] = @cidade) and
                                                (@endereco is null or [ENDERECO] = @endereco) and   
                                                (@uf is null or [UF] = @uf)";
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
                List<Paciente> List = new List<Paciente>();
                while (dr.Read())
                {
                    Paciente paciente = new Paciente();
                    paciente.id = Convert.ToInt32(dr["Id"]);
                    paciente.nome = Convert.ToString(dr["Nome"]);
                    paciente.telefone = Convert.ToString(dr["Telefone"]);
                    paciente.cidade = Convert.ToString(dr["Cidade"]);
                    paciente.cpf = Convert.ToString(dr["CPF"]);
                    paciente.sexo = Convert.ToString(dr["Sexo"]);
                    paciente.endereco = Convert.ToString(dr["Endereco"]);
                    paciente.plano = Convert.ToString(dr["Plano"]);
                    paciente.uf = Convert.ToString(dr["UF"]);
                    paciente.dtnaci = Convert.ToDateTime(dr["DTNACI"]);
                    List.Add(paciente);
                }
                return List;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao listar Paciente: " + e.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }
        public void Insert(Paciente paciente)
        {
            try
            {
                this.AbrirConexao();
                Int32 _id = this.ObterCodigo();
                paciente.id = _id;
                cmd = new SqlCommand(@"SET IDENTITY_INSERT [PACIENTE] ON;
                                       INSERT INTO [PACIENTE] 
                                                    ([ID],
                                                     [NOME],
                                                     [TELEFONE],
                                                     [CIDADE],
                                                     [CPF],
                                                     [ENDERECO],
                                                     [UF],
                                                     [PLANO],
                                                     [SEXO],
                                                     [DTNACI]) 
                                              VALUES (@id,
                                                      @nome,
                                                      @telefone,
                                                      @cidade,
                                                      @cpf,
                                                      @endereco,
                                                      @uf,
                                                      @plano,
                                                      @sexo,
                                                      @dtnaci);
                                        SET IDENTITY_INSERT [PACIENTE] OFF;", tran.Connection, tran);
                cmd.Parameters.AddWithValue("@id", paciente.id);
                cmd.Parameters.AddWithValue("@nome", paciente.nome);
                cmd.Parameters.AddWithValue("@telefone", paciente.telefone);
                cmd.Parameters.AddWithValue("@cidade", paciente.cidade);
                cmd.Parameters.AddWithValue("@cpf", paciente.cpf);
                cmd.Parameters.AddWithValue("@endereco", paciente.endereco);
                cmd.Parameters.AddWithValue("@uf", paciente.uf);
                cmd.Parameters.AddWithValue("@plano", paciente.plano);
                cmd.Parameters.AddWithValue("@sexo", paciente.sexo);
                cmd.Parameters.AddWithValue("@dtnaci", paciente.dtnaci);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();

            }
            catch (Exception e)
            {
                tran.Rollback();
                throw new Exception("Erro ao Inserir Paciente: " + e.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }
        public void Delete(Paciente paciente)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand(@"DELETE FROM [PACIENTE] 
                                              WHERE [ID] = @id_paciente", tran.Connection, tran);
                cmd.Parameters.AddWithValue("@id_paciente", paciente.id);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw new Exception("Erro ao Deletar Paciente: " + e.Message);
            }
            finally
            {
                this.FecharConexao();
            }

        }

        public void UPDATE(Paciente paciente)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand(@"UPDATE [PACIENTE] 
                                              SET   [telefone] = @telefone,
                                                    [Cidade] = @cidade,
                                                    [ENDERECO] = @endereco,
                                                    [Plano] = @plano,
                                                    [UF] = @uf
                                              WHERE [ID] = @id_paciente", tran.Connection, tran);

                cmd.Parameters.AddWithValue("@id_paciente", paciente.id);
                cmd.Parameters.AddWithValue("@telefone", paciente.telefone);
                cmd.Parameters.AddWithValue("@cidade", paciente.cidade);
                cmd.Parameters.AddWithValue("@endereco", paciente.endereco);
                cmd.Parameters.AddWithValue("@plano", paciente.plano);
                cmd.Parameters.AddWithValue("@uf", paciente.uf);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw new Exception("Erro ao Atualizar Paciente: " + e.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }

        public int ObterCodigo()
        {
            try
            {
                //this.AbrirConexao();
                String query = "SELECT MAX([ID]) FROM [PACIENTE]";
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
        #endregion
    }
}