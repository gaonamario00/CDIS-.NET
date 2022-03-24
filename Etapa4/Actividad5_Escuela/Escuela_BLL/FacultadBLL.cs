using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;
using System.Transactions;

namespace Escuela_BLL
{
    public class FacultadBLL
    {
        public List<Object> cargarFacultades()
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultades();
        }

        public void agregarFacultad(Facultad paramFacultad, List<MateriaFacultad> listMaterias
            //string codigo, string nombre, DateTime fechaCreacion, int universidad, int ciudad
            )
        {
            FacultadDAL facultad = new FacultadDAL();
            Facultad facu = new Facultad();
            MateriaFacultadBLL mateFacuBLL = new MateriaFacultadBLL();

            facu = cargarFacultadByCodigo(paramFacultad.codigo);

            if (facu != null)
            {
                throw new Exception("El código de la facultad ya existe, introduce un código diferente");
            }
            else
            {
                int tiempo = DateTime.Now.Year - paramFacultad.fechaCreacion.Year;

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
                        using (TransactionScope ts = new TransactionScope())
                        {
                            facultad.agregarFacultad(paramFacultad);

                            foreach (MateriaFacultad materia in listMaterias)
                            {
                                materia.Facultad = paramFacultad.ID_Facultad;
                                mateFacuBLL.agregarMateriaFacultad(materia);
                            }
                            ts.Complete();
                        }
                    }
                }
            }

        }

        public Facultad cargarFacultadByID(int id)
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultadByID(id);
        }

        public void updateFacultad(Facultad paramFacultad, List<MateriaFacultad> listMateriaFacu
            //int ID_Facultad, string codigo, string nombre, DateTime fechaCreacion, int universidad, int ciudad
            )
        {
            FacultadDAL facultad = new FacultadDAL();
            DataTable dtFacultad = cargarFacultadByCodigoExceptID(paramFacultad.ID_Facultad);
            MateriaFacultadBLL matFacuBLL = new MateriaFacultadBLL();

            using (TransactionScope ts = new TransactionScope())
            {
                facultad.updateFacultad(paramFacultad);

                matFacuBLL.eliminarMaterias(paramFacultad.ID_Facultad);

                foreach (MateriaFacultad materia in listMateriaFacu)
                {
                    matFacuBLL.agregarMateriaFacultad(materia);
                }
                ts.Complete();
            }

                if (dtFacultad.Rows.Count > 0)
                {
                    for (int i = 0; i < dtFacultad.Rows.Count; i++)
                    {
                        if (dtFacultad.Rows[i]["codigo"].ToString().Equals(paramFacultad.codigo))
                        {
                            throw new Exception("El codigo de la facultad ya existe, introduce un código diferente");
                        }
                    }
                }
  
                int tiempo = DateTime.Now.Year - paramFacultad.fechaCreacion.Year;

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
                        facultad.updateFacultad(paramFacultad
                            //ID_Facultad, codigo, nombre, fechaCreacion, universidad, ciudad
                            );
                    }
                }
            
        }

        public void deleteFacultad(int ID_Facultad)
        {
            FacultadDAL facultad = new FacultadDAL();
            MateriaFacultadBLL matFacuBLL = new MateriaFacultadBLL();

            using (TransactionScope ts = new TransactionScope())
            {
                matFacuBLL.eliminarMaterias(ID_Facultad);
                facultad.deleteFacultad(ID_Facultad);

                ts.Complete();
            }

                facultad.deleteFacultad(ID_Facultad);
        }
        public Facultad cargarFacultadByCodigo(string codigo)
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
