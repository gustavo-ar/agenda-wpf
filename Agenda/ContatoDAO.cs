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

            connection.Close();

            return contato;
        }

        public void InserirContato(Contato contato)
        {
            SqlConnection connection = ConnectionFactory.GetConnection();
            connection.Open();

            string query = "INSERT INTO tbcontato " +
                "(nome ,endereco ,numero ,bairro ,cidade ,uf ,cep ,telefone ,celular ,email)    " +
                " VALUES ( @NOME , @ENDERECO , @NUMERO , @BAIRRO , @CIDADE , @UF" +
                " , @CEP , @TEL , @CEL , @EMAIL );";

            command = new SqlCommand(query, connection);

            SqlParameter param = new SqlParameter();

            List<SqlParameter> prm = new List<SqlParameter>()
             {
                new SqlParameter("@NOME", SqlDbType.VarChar) {Value = contato.Nome},
                new SqlParameter("@ENDERECO", SqlDbType.VarChar) {Value = contato.Endereco},
                new SqlParameter("@NUMERO", SqlDbType.Int) {Value = contato.Numero},
                new SqlParameter("@BAIRRO", SqlDbType.VarChar) {Value = contato.Bairro},
                new SqlParameter("@CIDADE", SqlDbType.VarChar) {Value = contato.Cidade},
                new SqlParameter("@UF", SqlDbType.VarChar) {Value = contato.Uf},
                new SqlParameter("@CEP", SqlDbType.VarChar) {Value = contato.Cep},
                new SqlParameter("@TEL", SqlDbType.VarChar) {Value = contato.Telefone},
                new SqlParameter("@CEL", SqlDbType.VarChar) {Value = contato.Celular},
                new SqlParameter("@EMAIL", SqlDbType.VarChar) {Value = contato.Email}
             };

            command.Parameters.AddRange(prm.ToArray());

            command.ExecuteNonQuery();

            connection.Close();

        }
    }
}
