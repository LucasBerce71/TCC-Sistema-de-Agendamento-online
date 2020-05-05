using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TccNovoGrupo.Models;

namespace TccNovoGrupo.Repositorio
{
    public class ConsultarHorariosRepositorio
    {
        private SqlConnection _con;

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexaoSalaoTcc"].ToString();
            _con = new SqlConnection(constr);
        }

        public List<ConsultarHorarios> ObterHorarios()
        {
            Connection();
            List<ConsultarHorarios> horaList = new List<ConsultarHorarios>();

            using (SqlCommand command = new SqlCommand("ObterHorario", _con))
            {
                command.CommandType = CommandType.StoredProcedure;

                _con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ConsultarHorarios hora = new ConsultarHorarios()
                    {
                        HorarioId = Convert.ToInt32(reader["HorarioId"]),
                        Inicio = Convert.ToString(reader["Inicio"]),
                        Fim = Convert.ToString(reader["Fim"])

                    };

                    horaList.Add(hora);
                }

                _con.Close();

                return horaList;
            }
        }
    }
}