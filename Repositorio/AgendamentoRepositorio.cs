using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TccNovoGrupo.Models;

namespace TccNovoGrupo.Repositorio
{
    public class AgendamentoRepositorio
    {
        private SqlConnection _con;

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexaoSalaoTcc"].ToString();
            _con = new SqlConnection(constr);
        }

        public bool AdicionarAgendamento(Agenda agendaObj)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("IncluirAgendamento", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@data", agendaObj.data);
                command.Parameters.AddWithValue("@ClienteId", agendaObj.ClienteId);
                command.Parameters.AddWithValue("@cod_profissional", agendaObj.cod_profissional);
                command.Parameters.AddWithValue("@cod_servico", agendaObj.cod_servico);
                command.Parameters.AddWithValue("@cod_inicio", agendaObj.cod_inicio);
                _con.Open();

                i = command.ExecuteNonQuery();
            }

            _con.Close();

            return i >= 1;
        }

        public List<Agenda> ObterAgendamentos()
        {
            Connection();
            List<Agenda> agendamentosList = new List<Agenda>();

            using (SqlCommand command = new SqlCommand("obterAgendamento", _con))
            {
                command.CommandType = CommandType.StoredProcedure;

                _con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Agenda agendamentos = new Agenda()
                    {                        
                        cod_agendamento = Convert.ToInt32(reader["cod_agendamento"]),
                        data = Convert.ToString(reader["data"]),
                        nome = Convert.ToString(reader["nome"]),
                        Profissional = Convert.ToString(reader["Profissional"]),
                        Servico = Convert.ToString(reader["Servico"]),
                        Inicio = Convert.ToString(reader["Inicio"]),


                        ClienteId = Convert.ToInt32(reader["ClienteId"]),
                        cod_profissional = Convert.ToInt32(reader["cod_profissional"]),
                        cod_servico = Convert.ToInt32(reader["cod_servico"]),

                        cod_inicio = Convert.ToInt32(reader["cod_inicio"])
                    };

                    agendamentosList.Add(agendamentos);
                }

                _con.Close();

                return agendamentosList;
            }
        }

        public bool AtualizarAgendamento(Agenda agendaObj)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("AtualizarAgendamento", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cod_agendamento", agendaObj.cod_agendamento);
                command.Parameters.AddWithValue("@data", agendaObj.data);
                command.Parameters.AddWithValue("@ClienteId", agendaObj.ClienteId);
                command.Parameters.AddWithValue("@cod_profissional", agendaObj.cod_profissional);
                command.Parameters.AddWithValue("@cod_servico", agendaObj.cod_servico);
                command.Parameters.AddWithValue("@cod_inicio", agendaObj.cod_inicio);
                command.Parameters.AddWithValue("@status", "ATIVO");
                _con.Open();

                i = command.ExecuteNonQuery();
            }

            _con.Close();

            return i >= 1;
        }

        public bool ExcluirAgendamento(int id)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("ExcluirAgendamentoPorId", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cod_agendamento", id);

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