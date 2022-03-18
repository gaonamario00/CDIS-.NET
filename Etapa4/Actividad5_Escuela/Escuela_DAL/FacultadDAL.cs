using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class FacultadDAL
    {
        public DataTable cargarFacultades()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Server=MARIOGAONA\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarFacultades";
            command.Connection = con;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtFacultades = new DataTable();

            con.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtFacultades);

            con.Close();

            return dtFacultades;
        }

        public void agregarFacultad(string codigo, string nombre, DateTime fechaCreacion, int universidad, int ciudad)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Server=MARIOGAONA\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_agregarFacultad";
            command.Connection = con;

            //command.Parameters.AddWithValue("pID", int.Parse(TextID.Text));
            command.Parameters.AddWithValue("pCodigo", codigo);
            command.Parameters.AddWithValue("pNombre", nombre);
            command.Parameters.AddWithValue("pFechaCreacion",fechaCreacion);
            command.Parameters.AddWithValue("pUniversidad", universidad);
            command.Parameters.AddWithValue("pCiudad", ciudad);

            con.Open();

            command.ExecuteNonQuery();

            con.Close();
        }
        
        public DataTable cargarFacultadByID(int id)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Server=MARIOGAONA\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarFacultadByID";
            command.Connection = con;

            command.Parameters.AddWithValue("pID_Facultad", id);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtFacultad = new DataTable();

            con.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtFacultad);

            con.Close();

            return dtFacultad;
        }

        public void updateFacultad(int ID_Facultad, string codigo, string nombre, DateTime fechaCreacion, int universidad, int ciudad)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Server=MARIOGAONA\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_modificarFacultad";
            command.Connection = con;

            command.Parameters.AddWithValue("pID_Facultad", ID_Facultad);
            command.Parameters.AddWithValue("pCodigo", codigo);
            command.Parameters.AddWithValue("pNombre", nombre);
            command.Parameters.AddWithValue("pFechaCreacion", fechaCreacion);
            command.Parameters.AddWithValue("pUniversidad", universidad);
            command.Parameters.AddWithValue("pCiudad", ciudad);

            con.Open();

            command.ExecuteNonQuery();

            con.Close();
        }

        public void deleteFacultad(int ID_Facultad)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Server=MARIOGAONA\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_eliminarFacultad";
            command.Connection = con;

            command.Parameters.AddWithValue("pID_Facultad", ID_Facultad);

            con.Open();

            command.ExecuteNonQuery();

            con.Close();
        }

        public DataTable cargarFacultadByCodigo(string codigo)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Server=MARIOGAONA\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarFacultadByCodigo";
            command.Connection = con;

            command.Parameters.AddWithValue("pCodigo", codigo);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtFacultad = new DataTable();

            con.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtFacultad);

            con.Close();

            return dtFacultad;
        }

        public DataTable cargarFacultadByCodigoExceptID(int ID_Facultad)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Server=MARIOGAONA\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarFacultadByCodigoExceptID";
            command.Connection = con;

            command.Parameters.AddWithValue("pID_Facultad", ID_Facultad);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtFacultad = new DataTable();

            con.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtFacultad);

            con.Close();

            return dtFacultad;
        }

    }
}
