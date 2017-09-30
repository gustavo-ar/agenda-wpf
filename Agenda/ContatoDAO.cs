using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    class ContatoDAO
    {
        const string TABLE = "TBCONTATO";
        SqlCommand command = null;
        SqlDataReader reader = null;

        public Contato BuscarContatoPorID(int id)
        {
            SqlConnection connection = ConnectionFactory.GetConnection();
            connection.Open();

            string query = "SELECT * FROM " + TABLE + " WHERE ID = @ID ";

            command = new SqlCommand(query, connection);

            SqlParameter param = new SqlParameter();

            param.ParameterName = "@ID";
            param.Value = id;
            command.Parameters.Add(param);

            reader = command.ExecuteReader();

            Contato contato = new Contato();

            // Exibindo os registros
            while (reader.Read())
            {
                contato.Nome = reader.GetString(0);

            }

            Console.WriteLine(contato.Nome);

            return contato;
        }
    }
}
