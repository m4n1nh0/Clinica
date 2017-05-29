using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ClinicaUnit.Models
{
    public class ExameConvenioDAO : DBConect
    {
        public List<Medico> ListarMedico(String nome, String cidade, String endereco, String uf)
        {
            try
            {
                this.AbrirConexao();
                string query = @"SELECT * FROM [EXAMECONV],[CONVENIO]
                                          WHERE (Id_conveino = [CONVENIO].[id]) and
                                                (@nome is null or [Nome] = @nome) and
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
                List<Medico> List = new List<Medico>();
                while (dr.Read())
                {
                    Medico medico = new Medico();
                    medico.id = Convert.ToInt32((dr.GetValue(0)));
                    medico.nome = Convert.ToString((dr.GetValue(1)));
                    medico.telefone = Convert.ToString(dr["Telefone"]);
                    medico.cidade = Convert.ToString(dr["Cidade"]);
                    medico.cpf = Convert.ToString(dr["CPF"]);
                    medico.crm = Convert.ToString(dr["CRM"]);
                    medico.endereco = Convert.ToString(dr["Endereco"]);
                    medico.turno = Convert.ToString(dr["Turno"]);
                    medico.uf = Convert.ToString(dr["UF"]);
                    medico.nomeEspeci = Convert.ToString((dr.GetValue(12)));
                    List.Add(medico);
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

    }
}