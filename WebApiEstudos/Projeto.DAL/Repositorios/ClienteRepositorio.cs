using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entidades;
using System.Data.SqlClient;

namespace Projeto.DAL.Repositorios
{
    public class ClienteRepositorio : Conexao
    {
        public void Inserir(Cliente c)
        {
            AbrirConexao();

            string query = "Insert into Cliente (Nome, Email, DataCadastro) values (@Nome, @Email, GETDATE()) ";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("Nome", c.Nome);
            cmd.Parameters.AddWithValue("Email", c.Email);
            cmd.ExecuteNonQuery();

            FecharConexao();
        }

        public void Alterar(Cliente c)
        {
            AbrirConexao();

            string query = "update Cliente set Nome = @Nome, Email = @Email where IdCliente = @Id";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("Nome", c.Nome);
            cmd.Parameters.AddWithValue("Email", c.Email);
            cmd.Parameters.AddWithValue("Id", c.IdCliente);
            cmd.ExecuteNonQuery();

            FecharConexao();
        }

        public List<Cliente> Buscar()
        {
            AbrirConexao();

            string query = "select * from Cliente";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Cliente> lista = new List<Cliente>();
   
                while (dr.Read())
                {
                    var c = new Cliente();

                    c.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                    c.Nome = Convert.ToString(dr["Nome"]);
                    c.Email = Convert.ToString(dr["Email"]);
                    c.DataCadastro = Convert.ToDateTime(dr["DataCadastro"]);

                    lista.Add(c);
                }  
   
            FecharConexao();

            return lista;
        }

        public Cliente BuscarPorId(int id)
        {
            AbrirConexao();

            string query = "select * from Cliente where IdCliente = @Id";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("Id", id);
            dr = cmd.ExecuteReader();

            Cliente c = null;

            if (dr.Read())
            {
                c = new Cliente();

                c.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                c.Nome = Convert.ToString(dr["Nome"]);
                c.Email = Convert.ToString(dr["Email"]);
                c.DataCadastro = Convert.ToDateTime(dr["DataCadastro"]);
            }

            FecharConexao();

            return c; //Retornando o Cliente

        }

        public void Deletar(int id)
        {
            AbrirConexao();

            string query = "delete from Cliente where IdCliente = @IdCliente";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("IdCliente", id);
            cmd.ExecuteNonQuery();

            FecharConexao();
        }

    }
}
