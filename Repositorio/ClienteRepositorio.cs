using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TccNovoGrupo.Models;

namespace TccNovoGrupo.Repositorio
{
    public class ClienteRepositorio
    {
        private SqlConnection _con;
        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexaoSalaoTcc"].ToString();
            _con = new SqlConnection(constr);
        }
        public List<Clientes> ObterClientes()
        {
            Connection();
            List<Clientes> clientesList = new List<Clientes>();

            using (SqlCommand command = new SqlCommand("ObterClientes", _con))
            {
                command.CommandType = CommandType.StoredProcedure;

                _con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Clientes clientes = new Clientes()
                    {
                        cod_cliente = Convert.ToInt32(reader["cod_cliente"]),
                        nome = Convert.ToString(reader["nome"]),
                        sobrenome = Convert.ToString(reader["sobrenome"]),
                        cpf = Convert.ToString(reader["cpf"]),
                        contato = Convert.ToString(reader["contato"]),
                        senha = Convert.ToString(reader["senha"]),
                        sexo = Convert.ToString(reader["sexo"]),
                        cod_nv = Convert.ToInt32(reader["cod_nv"])

                    };

                    clientesList.Add(clientes);
                }

                _con.Close();

                return clientesList;
            }
        }
    }
}