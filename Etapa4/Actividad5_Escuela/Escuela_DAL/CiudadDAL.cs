using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class CiudadDAL
    {

        public DataTable cargarCiudades()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Server=MARIOGAONA\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarCiudades";
            command.Connection = con;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtCiudades = new DataTable();

            con.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtCiudades);

            con.Close();

            return dtCiudades;
        }

        public DataTable cargarCiudadesPorEstado(int estado)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Server=MARIOGAONA\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarCiudadesPorEstado";
            command.Connection = con;

            command.Parameters.AddWithValue("pEstado", estado);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtCiudades = new DataTable();

            con.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtCiudades);

            con.Close();

            return dtCiudades;
        }

    }
}
