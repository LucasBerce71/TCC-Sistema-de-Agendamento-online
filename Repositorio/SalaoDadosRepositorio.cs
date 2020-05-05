using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TccNovoGrupo.Models;

namespace TccNovoGrupo.Repositorio
{
    public class SalaoDadosRepositorio
    {
        private SqlConnection _con;

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexaoSalaoTcc"].ToString();
            _con = new SqlConnection(constr);
        }

        public bool AdicionarSalao(DadosSalao salaoObj)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("IncluirSalao", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Salao", salaoObj.Salao);
                command.Parameters.AddWithValue("@Endereco", salaoObj.Endereco);
                command.Parameters.AddWithValue("@CEP", salaoObj.CEP);
                command.Parameters.AddWithValue("@Estado", salaoObj.Estado);
                command.Parameters.AddWithValue("@Contato", salaoObj.Contato);
                command.Parameters.AddWithValue("@Proprietario", salaoObj.Proprietario);
                command.Parameters.AddWithValue("@Status", "Ativo");
                _con.Open();

                i = command.ExecuteNonQuery();
            }

            _con.Close();

            return i >= 1;
        }

        public List<DadosSalao> ObterSalao()
        {
            Connection();
            List<DadosSalao> dadosSalaoList = new List<DadosSalao>();

            using (SqlCommand command = new SqlCommand("ObterSalao", _con))
            {
                command.CommandType = CommandType.StoredProcedure;

                _con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DadosSalao salao = new DadosSalao()
                    {
                        SalaoId = Convert.ToInt32(reader["SalaoId"]),
                        Salao = Convert.ToString(reader["Salao"]),
                        Endereco = Convert.ToString(reader["Endereco"]),
                        CEP = Convert.ToString(reader["CEP"]),
                        Estado = Convert.ToString(reader["Estado"]),
                        Contato = Convert.ToString(reader["Contato"]),
                        Proprietario = Convert.ToString(reader["Proprietario"]),
                        Status = Convert.ToString(reader["Status"])
                    };

                    dadosSalaoList.Add(salao);
                }

                _con.Close();

                return dadosSalaoList;
            }
        }

        public bool AtualizarSalao(DadosSalao salaoObj)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("AtualizarSalao", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SalaoId", salaoObj.SalaoId);
                command.Parameters.AddWithValue("@Salao", salaoObj.Salao);
                command.Parameters.AddWithValue("@Endereco", salaoObj.Endereco);
                command.Parameters.AddWithValue("@CEP", salaoObj.CEP);
                command.Parameters.AddWithValue("@Estado", salaoObj.Estado);
                command.Parameters.AddWithValue("@Contato", salaoObj.Contato);
                command.Parameters.AddWithValue("@Proprietario", salaoObj.Proprietario);
                command.Parameters.AddWithValue("@Email", salaoObj.Email);
                command.Parameters.AddWithValue("@Status", "ATIVO");
                _con.Open();

                i = command.ExecuteNonQuery();
            }

            _con.Close();

            return i >= 1;
        }

        public bool ExcluirSalao(int id)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("ExcluirSalaoPorId", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SalaoId", id);

                _con.Open();

                i = command.ExecuteNonQuery();
            }

            _con.Close();

            if (i >= 1)
            {
                return true;
            }
            return false;
        }
    }
}