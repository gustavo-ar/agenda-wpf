using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    class ConnectionFactory
    {
        public static SqlConnection GetConnection()
        {
            String stringDeConexao = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=dbagenda;Data Source=DESKTOP-QN093G9";

            SqlConnection conn = new SqlConnection(stringDeConexao);

            return conn;
        }
    }
}
