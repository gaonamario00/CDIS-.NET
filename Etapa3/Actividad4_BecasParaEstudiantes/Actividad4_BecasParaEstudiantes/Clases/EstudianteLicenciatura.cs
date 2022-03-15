using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad4_BecasParaEstudiantes.Clases
{
    internal class EstudianteLicenciatura : Estudiante
    {
        private bool RealizarServicio;

        public EstudianteLicenciatura() : base()
        {
            RealizarServicio = false;
        }

        public EstudianteLicenciatura(int matricula, string nombre, int edad, double CuotaEscolar, bool RealizarServicio) : base(matricula, nombre, edad, CuotaEscolar)
        {
            this.RealizarServicio = RealizarServicio;
        }

        public override void asignarBeca(double porcBeca)
        {
            base.asignarBeca(porcBeca);

            if (RealizarServicio)
            {
               this.CuotaEscolar  = CuotaEscolar - CuotaEscolar*.15;
            }
        }

        public override void mostrarDatos()
        {
            base.mostrarDatos();
            Console.WriteLine("Servicio Realizado: "+this.RealizarServicio);
        }
    }
}
