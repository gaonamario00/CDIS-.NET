using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class UniversidadDAL
    {

        public DataTable cargarUniversidades()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Server=MARIOGAONA\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarUniversidades";
            command.Connection = con;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtUniversidades = new DataTable();

            con.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtUniversidades);

            con.Close();

            return dtUniversidades;
        }

    }
}
