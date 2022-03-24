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

        EscuelaEntities modelo;

        public UniversidadDAL()
        {
            modelo = new EscuelaEntities();
        }

        public List<Universidad> cargarUniversidades()
        {

            var universidad = from mUni in modelo.Universidad
                              select mUni;
            return universidad.ToList();
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = @"Server=MARIOGAONA\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            //SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "sp_cargarUniversidades";
            //command.Connection = con;

            //SqlDataAdapter adapter = new SqlDataAdapter();
            //DataTable dtUniversidades = new DataTable();

            //con.Open();

            //adapter.SelectCommand = command;
            //adapter.Fill(dtUniversidades);

            //con.Close();

            //return dtUniversidades;
        }

    }
}
