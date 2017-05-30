using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ClinicaUnit.Models
{
    public class ExameConvenioDAO : DBConect
    {
        public List<ExameConvenio> ListarMedico()
        {
            try
            {
                this.AbrirConexao();
                Int32 id_exame = 0;
                string query = @"SELECT * FROM [EXAMECONV],[CONVENIO]
                                          WHERE (Id_conveino = [CONVENIO].[id]) and
                                                (@exame is null or [id_exame] = @exame)";
                cmd = new SqlCommand(query, tran.Connection, tran);
                if (id_exame == 0)
                {
                    cmd.Parameters.AddWithValue("@exame", 0);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@exame", id_exame);
                }

                dr = cmd.ExecuteReader();
                List<ExameConvenio> List = new List<ExameConvenio>();
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