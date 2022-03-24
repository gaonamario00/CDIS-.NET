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

        public void eliminarMaterias(int ID_Facultad)
        {
            var materias = (from mMaterias in modelo.MateriaFacultad
                            where mMaterias.Facultad == ID_Facultad
                            select mMaterias).ToList();

            foreach (var materia in materias)
            {
                modelo.MateriaFacultad.Remove(materia);
                modelo.SaveChanges();
            }
        }

    }
}
