using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class EstadoDAL
    {

        public DataTable cargarEstados()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Server=MARIOGAONA\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarEstados";
            command.Connection = con;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtEstados = new DataTable();

            con.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtEstados);

            con.Close();

            return dtEstados;
        }
    }
}
