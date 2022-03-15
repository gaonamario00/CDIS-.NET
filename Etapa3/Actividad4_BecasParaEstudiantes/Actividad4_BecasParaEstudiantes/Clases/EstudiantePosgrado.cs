using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad4_BecasParaEstudiantes.Clases
{
    internal class EstudiantePosgrado : Estudiante
    {
        int NivelSNI;

        public EstudiantePosgrado():base()
        {
            this.NivelSNI = 0;
        }

        public EstudiantePosgrado(int matricula, string nombre, int edad, double CuotaEscolar,int NivelSNI) : base(matricula, nombre, edad, CuotaEscolar)
        {
            this.NivelSNI= NivelSNI;
            comprobarNivelSNI();
        }

        public void comprobarNivelSNI()
        {
            if (NivelSNI!=1 && NivelSNI!=2 && NivelSNI!=3)
            {
                Console.WriteLine("SNI no valido");
                this.NivelSNI = 0;
            }
        }

        public override void asignarBeca(double porcBeca)
        {
            base.asignarBeca(porcBeca);

            if(NivelSNI == 1 || NivelSNI == 2)
            {
                this.CuotaEscolar = CuotaEscolar - CuotaEscolar * .15;
            }
            if (NivelSNI == 3)
            {
                this.CuotaEscolar = CuotaEscolar - CuotaEscolar * .3;
            }
        }

        public override void mostrarDatos()
        {
            base.mostrarDatos();
            Console.WriteLine("NivelSNI: "+this.NivelSNI);
        }

    }
}
