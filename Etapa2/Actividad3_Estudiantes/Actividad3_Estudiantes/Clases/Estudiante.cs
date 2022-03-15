using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad3_Estudiantes.Clases
{
    internal class Estudiante
    {
        private int matricula;
        private string nombre;
        private int edad = -1;
        private string password = "";

        public Estudiante() { }

        public Estudiante(int matricula, string nombre, int edad)
        {
            this.matricula = matricula;
            this.nombre = nombre;
            asignarEdad(edad);
            asignarPassword();
        }

        public void asignarEdad(int edad)
        {
            if(edad >=15 && edad <= 90)
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
                int b = rand.Next(97,123);
                char c = Convert.ToChar(b);
                string s = c.ToString();

                cadena = cadena + s;

                int a = rand.Next(10);
                cadena = cadena + a;
            }
            this.password = cadena;
        }

        public void mostrarDatos()
        {
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("Matricula: " + matricula);
            Console.WriteLine("Edad: " + edad);
            Console.WriteLine("contraseña: " + password);
        }

    }
}
