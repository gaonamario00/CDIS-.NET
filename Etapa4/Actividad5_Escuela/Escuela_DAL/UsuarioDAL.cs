using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Escuela_DAL
{
    public class UsuarioDAL
    {

        public DataTable consultarUsuario(string nombre, string contrasena)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Server=MARIOGAONA\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_consultarUsuario";
            command.Connection = con;

            command.Parameters.AddWithValue("pNombre", nombre);
            command.Parameters.AddWithValue("pContrasena", contrasena);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtUsuario = new DataTable();

            con.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtUsuario);

            con.Close();

            return dtUsuario;
        }

    }
}
