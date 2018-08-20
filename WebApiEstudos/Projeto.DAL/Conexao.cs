using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //importando
using System.Configuration;//Conrction string

namespace Projeto.DAL
{
    public class Conexao
    {
        protected SqlConnection con;
        protected SqlCommand cmd;
        protected SqlDataReader dr;
        protected SqlTransaction tr;

        protected void AbrirConexao()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Banco"].ConnectionString);
            con.Open();
        }

        protected void FecharConexao()
        {
            con.Close();
        }
    }
}
