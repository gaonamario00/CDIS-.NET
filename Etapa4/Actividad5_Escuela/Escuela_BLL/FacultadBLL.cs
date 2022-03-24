using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;

namespace Escuela_BLL
{
    public class FacultadBLL
    {
        public DataTable cargarFacultades()
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultades();
        }

        public void agregarFacultad(string codigo, string nombre, DateTime fechaCreacion, int universidad, int ciudad)
        {
            FacultadDAL facultad = new FacultadDAL();
            DataTable dtFacultad = cargarFacultadByCodigo(codigo);

            if(dtFacultad.Rows.Count > 0)
            {
                throw new Exception("El código de la facultad ya existe, introduce un código diferente");
            }
            else
            {
                int tiempo = DateTime.Now.Year - fechaCreacion.Year;

                if(tiempo > 122)
                {
                    throw new Exception("Fecha no permitida, introduce una fecha mayor a 1900");
                }
                else
                {
                    if (tiempo < 12)
                    {
                        throw new Exception("Fecha no permitida, introduce una fecha menor a 2010");
                    }
                    else
                    {
                        facultad.agregarFacultad(codigo, nombre, fechaCreacion, universidad, ciudad);
                    }
                }
            }

        }

        public DataTable cargarFacultadByID(int id)
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultadByID(id);
        }

        public void updateFacultad(int ID_Facultad, string codigo, string nombre, DateTime fechaCreacion, int universidad, int ciudad)
        {
            FacultadDAL facultad = new FacultadDAL();
            DataTable dtFacultad = cargarFacultadByCodigoExceptID(ID_Facultad);

            if (dtFacultad.Rows.Count > 0)
            {
                for (int i=0; i< dtFacultad.Rows.Count; i++)
                {
                    if (dtFacultad.Rows[i]["codigo"].ToString().Equals(codigo))
                    {
                        throw new Exception("El codigo de la facultad ya existe, introduce un código diferente");
                    }
                }
            }
  
                int tiempo = DateTime.Now.Year - fechaCreacion.Year;

                if (tiempo > 122)
                {
                    throw new Exception("Fecha no permitida, introduce una fecha mayor a 1900");
                }
                else
                {
                    if (tiempo < 12)
                    {
                        throw new Exception("Fecha no permitida, introduce una fecha menor a 2010");
                    }
                    else
                    {
                        facultad.updateFacultad(ID_Facultad, codigo, nombre, fechaCreacion, universidad, ciudad);
                    }
                }
            
        }

        public void deleteFacultad(int ID_Facultad)
        {
            FacultadDAL facultad = new FacultadDAL();
            facultad.deleteFacultad(ID_Facultad);
        }
        public DataTable cargarFacultadByCodigo(string codigo)
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultadByCodigo(codigo);
        }
        public DataTable cargarFacultadByCodigoExceptID(int ID_Facultad)
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultadByCodigoExceptID(ID_Facultad);
        }

    }
}
