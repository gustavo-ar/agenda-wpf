using System;
using System.Collections.Generic;
using System.Data;
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

            SqlParameter param = ParamID(id);

            command.Parameters.Add(param);

            reader = command.ExecuteReader();

            Contato contato = new Contato();

            // Exibindo os registros
            while (reader.Read())
            {
                contato.Nome = reader.GetString(0);
                contato.Endereco = reader.GetString(1);
                contato.Numero = reader.GetInt32(2);
                contato.Bairro = reader.GetString(3);
                contato.Cidade = reader.GetString(4);
                contato.Cep = reader.GetString(5);
                contato.Telefone = reader.GetString(6);
                contato.Celular = reader.GetString(7);
                contato.Email = reader.GetString(8);
                contato.Id = reader.GetInt32(9);
            }

            connection.Close();

            return contato;
        }

        public void DeletarContato(int id)
        {
            SqlConnection connection = ConnectionFactory.GetConnection();
            connection.Open();

            string query = "DELETE FROM tbcontato WHERE ID =  @ID";

            command = new SqlCommand(query, connection);

            SqlParameter param = ParamID(id);
            command.Parameters.Add(param);

            command.ExecuteNonQuery();

            connection.Close();
        }

        private static SqlParameter ParamID(int id)
        {
            SqlParameter param = new SqlParameter
            {
                ParameterName = "@ID",
                Value = id
            };
            return param;
        }

        public void AlterarContato(Contato contato)
        {
            SqlConnection connection = ConnectionFactory.GetConnection();
            connection.Open();

            string query = "UPDATE " + TABLE + " SET " +
               "nome = @NOME ," +
               "endereco = @ENDERECO  ," +
               "numero = @NUMERO ," +
               "bairro = @BAIRRO  ," +
               "cidade = @CIDADE  ," +
               "cep = @CEP ," +
               "telefone = @TEL," +
               "celular = @CEL ," +
               "email = @EMAIL " +
               "WHERE ID = @ID";

            command = new SqlCommand(query, connection);

            SqlParameter param = ParamID(contato.Id);
            List<SqlParameter> prm = GetListOfParams(contato);
            prm.Add(param);

            command.Parameters.AddRange(prm.ToArray());

            command.ExecuteNonQuery();

            connection.Close();
        }

        private static List<SqlParameter> GetListOfParams(Contato contato)
        {
            return new List<SqlParameter>()
             {
                new SqlParameter("@NOME", SqlDbType.VarChar) {Value = contato.Nome},
                new SqlParameter("@ENDERECO", SqlDbType.VarChar) {Value = contato.Endereco},
                new SqlParameter("@NUMERO", SqlDbType.Int) {Value = contato.Numero},
                new SqlParameter("@BAIRRO", SqlDbType.VarChar) {Value = contato.Bairro},
                new SqlParameter("@CIDADE", SqlDbType.VarChar) {Value = contato.Cidade},
                new SqlParameter("@CEP", SqlDbType.VarChar) {Value = contato.Cep},
                new SqlParameter("@TEL", SqlDbType.VarChar) {Value = contato.Telefone},
                new SqlParameter("@CEL", SqlDbType.VarChar) {Value = contato.Celular},
                new SqlParameter("@EMAIL", SqlDbType.VarChar) {Value = contato.Email}
             };
        }

        public void InserirContato(Contato contato)
        {
            SqlConnection connection = ConnectionFactory.GetConnection();
            connection.Open();

            string query = "INSERT INTO " + TABLE +
                "(nome ,endereco ,numero ,bairro ,cidade ,cep ,telefone ,celular ,email)    " +
                " VALUES ( @NOME , @ENDERECO , @NUMERO , @BAIRRO , @CIDADE " +
                " , @CEP , @TEL , @CEL , @EMAIL );";

            command = new SqlCommand(query, connection);

            SqlParameter param = new SqlParameter();

            List<SqlParameter> prm = GetListOfParams(contato);

            command.Parameters.AddRange(prm.ToArray());

            command.ExecuteNonQuery();

            connection.Close();

        }
    }
}
