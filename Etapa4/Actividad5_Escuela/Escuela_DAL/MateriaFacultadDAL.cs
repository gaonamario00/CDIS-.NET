using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class MateriaFacultadDAL
    {

        EscuelaEntities modelo;

        public MateriaFacultadDAL()
        {
            modelo = new EscuelaEntities();
        }

        public void agregarMateriaFacultad(MateriaFacultad materia)
        {
            modelo.MateriaFacultad.Add(materia);
            modelo.SaveChanges();
        }

    }
}
