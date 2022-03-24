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

        EscuelaEntities modelo;

        public FacultadDAL()
        {
            modelo = new EscuelaEntities();
        }

        public List<Object> cargarFacultades()
        {
            var facultades = from mFacultades in modelo.Facultad
                             select new
                             {
                                 ID_Facultad = mFacultades.ID_Facultad,
                                 codigo = mFacultades.codigo,
                                 nombre = mFacultades.nombre,
                                 fechaCreacion = mFacultades.fechaCreacion,
                                 nombreUniversidad = mFacultades.Universidad1.nombre,
                                 nombreCiudad = mFacultades.Ciudad1.nombre
                             };
            return facultades.AsEnumerable<Object>().ToList();
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = @"Server=MARIOGAONA\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            //SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "sp_cargarFacultades";
            //command.Connection = con;

            //SqlDataAdapter adapter = new SqlDataAdapter();
            //DataTable dtFacultades = new DataTable();

            //con.Open();

            //adapter.SelectCommand = command;
            //adapter.Fill(dtFacultades);

            //con.Close();

            //return dtFacultades;
        }

        public void agregarFacultad(Facultad facultad
            //string codigo, string nombre, DateTime fechaCreacion, int universidad, int ciudad
            )
        {
            modelo.Facultad.Add(facultad);
            modelo.SaveChanges();
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = @"Server=MARIOGAONA\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            //SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "sp_agregarFacultad";
            //command.Connection = con;

            ////command.Parameters.AddWithValue("pID", int.Parse(TextID.Text));
            //command.Parameters.AddWithValue("pCodigo", codigo);
            //command.Parameters.AddWithValue("pNombre", nombre);
            //command.Parameters.AddWithValue("pFechaCreacion",fechaCreacion);
            //command.Parameters.AddWithValue("pUniversidad", universidad);
            //command.Parameters.AddWithValue("pCiudad", ciudad);

            //con.Open();

            //command.ExecuteNonQuery();

            //con.Close();

        }
        
        public Facultad cargarFacultadByID(int id)
        {
            var facultad = (from mfacultad in modelo.Facultad
                             where mfacultad.ID_Facultad == id
                             select mfacultad).FirstOrDefault();
            return facultad;
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = @"Server=MARIOGAONA\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            //SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "sp_cargarFacultadByID";
            //command.Connection = con;

            //command.Parameters.AddWithValue("pID_Facultad", id);

            //SqlDataAdapter adapter = new SqlDataAdapter();
            //DataTable dtFacultad = new DataTable();

            //con.Open();

            //adapter.SelectCommand = command;
            //adapter.Fill(dtFacultad);

            //con.Close();

            //return dtFacultad;
        }

        public void updateFacultad( Facultad pFacultad
            //int ID_Facultad, string codigo, string nombre, DateTime fechaCreacion, int universidad, int ciudad
            )

        {

            var facultad = (from mfacultad in modelo.Facultad
                            where mfacultad.ID_Facultad == pFacultad.ID_Facultad
                            select mfacultad).FirstOrDefault();

            facultad.nombre = pFacultad.nombre;
            facultad.codigo = pFacultad.codigo;
            facultad.fechaCreacion = pFacultad.fechaCreacion;
            facultad.universidad = pFacultad.universidad;
            facultad.ciudad = pFacultad.ciudad;

            modelo.SaveChanges();

            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = @"Server=MARIOGAONA\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            //SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "sp_modificarFacultad";
            //command.Connection = con;

            //command.Parameters.AddWithValue("pID_Facultad", ID_Facultad);
            //command.Parameters.AddWithValue("pCodigo", codigo);
            //command.Parameters.AddWithValue("pNombre", nombre);
            //command.Parameters.AddWithValue("pFechaCreacion", fechaCreacion);
            //command.Parameters.AddWithValue("pUniversidad", universidad);
            //command.Parameters.AddWithValue("pCiudad", ciudad);

            //con.Open();

            //command.ExecuteNonQuery();

            //con.Close();
        }

        public void deleteFacultad(int ID_Facultad)
        {

            var facultad = (from mfacultad in modelo.Facultad
                            where mfacultad.ID_Facultad == ID_Facultad
                            select mfacultad).FirstOrDefault();

            modelo.Facultad.Remove(facultad);
            modelo.SaveChanges();

            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = @"Server=MARIOGAONA\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            //SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "sp_eliminarFacultad";
            //command.Connection = con;

            //command.Parameters.AddWithValue("pID_Facultad", ID_Facultad);

            //con.Open();

            //command.ExecuteNonQuery();

            //con.Close();
        }

        public Facultad cargarFacultadByCodigo(string codigo)
        {

            var facultad = (from mfacultad in modelo.Facultad
                            where mfacultad.codigo.Equals(codigo)
                            select mfacultad).FirstOrDefault();
            return facultad;

            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = @"Server=MARIOGAONA\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            //SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "sp_cargarFacultadByCodigo";
            //command.Connection = con;

            //command.Parameters.AddWithValue("pCodigo", codigo);

            //SqlDataAdapter adapter = new SqlDataAdapter();
            //DataTable dtFacultad = new DataTable();

            //con.Open();

            //adapter.SelectCommand = command;
            //adapter.Fill(dtFacultad);

            //con.Close();

            //return dtFacultad;
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
