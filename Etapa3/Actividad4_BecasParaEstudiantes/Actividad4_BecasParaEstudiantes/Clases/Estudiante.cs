using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad4_BecasParaEstudiantes.Clases
{
    internal class Estudiante
    {
        protected int matricula;
        protected string nombre;
        protected int edad = -1;
        protected string password = "";
        protected double CuotaEscolar = 0;
        public Estudiante() {
            matricula = 1899495;
            nombre = "Mario Gaona";
            edad = 20;
            asignarPassword();
            CuotaEscolar = 200.00;
        }

        public Estudiante(int matricula, string nombre, int edad, double CuotaEscolar)
        {
            this.matricula = matricula;
            this.nombre = nombre;
            asignarEdad(edad);
            asignarPassword();
            this.CuotaEscolar = CuotaEscolar;
        }

        public void asignarEdad(int edad)
        {
            if (edad >= 15 && edad <= 90)
            {
                this.edad = edad;
            }
        }

        public void asignarPassword()
        {
            Random rand = new Random();
            string cadena = "";

            for (int i = 0; i < 4; i++)
            {
                int b = rand.Next(97, 123);
                char c = Convert.ToChar(b);
                string s = c.ToString();

                cadena = cadena + s;

                int a = rand.Next(10);
                cadena = cadena + a;
            }
            this.password = cadena;
        }

        public virtual void mostrarDatos()
        {
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("Matricula: " + matricula);
            Console.WriteLine("Edad: " + edad);
            Console.WriteLine("contraseña: " + password);
            Console.WriteLine("Cuota de escolar: " + CuotaEscolar);
        }

        public virtual void asignarBeca(double porcBeca)
        {
            porcBeca = porcBeca/100;
            CuotaEscolar = CuotaEscolar - CuotaEscolar * porcBeca;
        }

    }
}
