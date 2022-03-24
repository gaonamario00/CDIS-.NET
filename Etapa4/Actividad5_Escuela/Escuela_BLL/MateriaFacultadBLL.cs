using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Escuela_DAL;

namespace Escuela_BLL
{
    public class MateriaFacultadBLL
    {

        public void agregarMateriaFacultad(MateriaFacultad materia)
        {
            MateriaFacultadDAL materiaDAL = new MateriaFacultadDAL();
            materiaDAL.agregarMateriaFacultad(materia);
        }

        public void eliminarMaterias(int ID_Facultad)
        {
            MateriaFacultadDAL materiaDAL = new MateriaFacultadDAL();
            materiaDAL.eliminarMaterias(ID_Facultad);
        }

    }
}
