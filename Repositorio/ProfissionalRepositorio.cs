using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TccNovoGrupo.Models;

namespace TccNovoGrupo.Repositorio
{
    public class ProfissionalRepositorio
    {
        private SqlConnection _con;

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexaoSalaoTcc"].ToString();
            _con = new SqlConnection(constr);
        }

        public bool AdicionarProfissional(Profissionals profissionalObj)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("IncluirProfissional", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Profissional", profissionalObj.Profissional);
                command.Parameters.AddWithValue("@CPF", profissionalObj.CPF);
                command.Parameters.AddWithValue("@DataAdmissao", profissionalObj.DataAdmissao);
                command.Parameters.AddWithValue("@DataNascimento", profissionalObj.DataNascimento);
                command.Parameters.AddWithValue("@Salario", profissionalObj.Salario);

                _con.Open();

                i = command.ExecuteNonQuery();
            }

            _con.Close();

            return i >= 1;
        }

        public List<Profissionals> ObterProfissional()
        {
            Connection();
            List<Profissionals> profissionalsList = new List<Profissionals>();

            using (SqlCommand command = new SqlCommand("ObterProfissional", _con))
            {
                command.CommandType = CommandType.StoredProcedure;

                _con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Profissionals profissional = new Profissionals()
                    {
                        ProfissionalId = Convert.ToInt32(reader["ProfissionalId"]),
                        Profissional = Convert.ToString(reader["Profissional"]),
                        CPF = Convert.ToString(reader["CPF"]),
                        DataAdmissao = Convert.ToString(reader["DataAdmissao"]),
                        DataNascimento = Convert.ToString(reader["DataNascimento"]),
                        Salario = Convert.ToString(reader["Salario"])

                    };

                    profissionalsList.Add(profissional);
                }

                _con.Close();

                return profissionalsList;
            }
        }

        public bool AtualizarProfissional(Profissionals profissionalObj)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("AtualizarProfissional", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProfissionalId", profissionalObj.ProfissionalId);
                command.Parameters.AddWithValue("@Profissional", profissionalObj.Profissional);
                command.Parameters.AddWithValue("@CPF", profissionalObj.CPF);
                command.Parameters.AddWithValue("@DataAdmissao", profissionalObj.DataAdmissao);
                command.Parameters.AddWithValue("@DataNascimento", profissionalObj.DataNascimento);
                command.Parameters.AddWithValue("@Salario", profissionalObj.Salario);
                command.Parameters.AddWithValue("@Status", "ATIVO");


                _con.Open();

                i = command.ExecuteNonQuery();
            }

            _con.Close();

            return i >= 1;
        }

        public bool ExcluirProfissional(int id)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("ExcluirProfissionalPorId", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProfissionalId", id);

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