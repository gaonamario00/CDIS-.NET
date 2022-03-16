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

        public void agregarFacultad(string codigo, string nombre, DateTime fechaCreacion, int universidad)
        {
            FacultadDAL facultad = new FacultadDAL();
            facultad.agregarFacultad(codigo, nombre, fechaCreacion, universidad);
        }

        public DataTable cargarFacultadByID(int id)
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultadByID(id);
        }

        public void updateFacultad(int ID_Facultad, string codigo, string nombre, DateTime fechaCreacion, int universidad)
        {
            FacultadDAL facultad = new FacultadDAL();
            facultad.updateFacultad(ID_Facultad, codigo, nombre, fechaCreacion, universidad);
        }

        public void deleteFacultad(int ID_Facultad)
        {
            FacultadDAL facultad = new FacultadDAL();
            facultad.deleteFacultad(ID_Facultad);
        }

    }
}
