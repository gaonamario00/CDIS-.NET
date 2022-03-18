using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Escuela_DAL;

namespace Escuela_BLL
{
    public class CiudadBLL
    {
        public DataTable cargarCiudades()
        {
            CiudadDAL ciudadDAL = new CiudadDAL();
            return ciudadDAL.cargarCiudades();
        }

        public DataTable cargarCiudadesPorEstado(int estado)
        {
            CiudadDAL ciudadDAL = new CiudadDAL();
            return ciudadDAL.cargarCiudadesPorEstado(estado);
        }
    }
}
