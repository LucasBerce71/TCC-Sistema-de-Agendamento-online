using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TccNovoGrupo.Models;

namespace TccNovoGrupo.Repositorio
{
    public class ServicoRepositorio
    {
        private SqlConnection _con;

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexaoSalaoTcc"].ToString();
            _con = new SqlConnection(constr);
        }

        public bool AdicionarServico(Servicos servicoObj)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("IncluirServico", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Servico", servicoObj.Servico);
                command.Parameters.AddWithValue("@Preco", servicoObj.Preco);
                command.Parameters.AddWithValue("@Tempo", servicoObj.Tempo);
                command.Parameters.AddWithValue("@Descricao", servicoObj.Descricao);
                command.Parameters.AddWithValue("@Tipo", servicoObj.Tipo);


                _con.Open();

                i = command.ExecuteNonQuery();
            }

            _con.Close();

            return i >= 1;
        }

        public List<Servicos> ObterServicos()
        {
            Connection();
            List<Servicos> servicosList = new List<Servicos>();

            using (SqlCommand command = new SqlCommand("ObterServicos", _con))
            {
                command.CommandType = CommandType.StoredProcedure;

                _con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Servicos servico = new Servicos()
                    {
                        ServicoId = Convert.ToInt32(reader["ServicoId"]),
                        Servico = Convert.ToString(reader["Servico"]),
                        Preco = Convert.ToDecimal(reader["Preco"]),
                        Tempo = Convert.ToString(reader["Tempo"]),
                        Descricao = Convert.ToString(reader["Descricao"]),
                        Tipo = Convert.ToString(reader["Tipo"])

                    };

                    servicosList.Add(servico);
                }

                _con.Close();

                return servicosList;
            }
        }

        public bool AtualizarServico(Servicos servicoObj)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("AtualizarServico", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ServicoId", servicoObj.ServicoId);
                command.Parameters.AddWithValue("@Servico", servicoObj.Servico);
                command.Parameters.AddWithValue("@Preco", servicoObj.Preco);
                command.Parameters.AddWithValue("@Tempo", servicoObj.Tempo);
                command.Parameters.AddWithValue("@Descricao", servicoObj.Descricao);
                command.Parameters.AddWithValue("@Tipo", servicoObj.Tipo);
                command.Parameters.AddWithValue("@Status", "ATiVO");


                _con.Open();

                i = command.ExecuteNonQuery();
            }

            _con.Close();

            return i >= 1;
        }

        public bool ExcluirServico(int id)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("ExcluirServicoPorId", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ServicoId", id);

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