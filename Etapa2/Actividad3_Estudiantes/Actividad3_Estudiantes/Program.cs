using Actividad3_Estudiantes.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad3_Estudiantes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            Estudiante[] estudiantes;

            Console.Write("Ingrese la cantidad de estudiantes a capturar: ");
            n = int.Parse(Console.ReadLine());
            estudiantes = new Estudiante[n];

            for(int i = 0; i < n; i++)
            {
                Console.WriteLine();
                Console.Write("Nombre:");
                string nombre = Console.ReadLine();

                Console.Write("Matricula: ");
                int matricula = int.Parse(Console.ReadLine());

                bool edadIsCorrect = false;
                int edad;
                do
                {
                    Console.Write("Edad:");
                    edad = int.Parse(Console.ReadLine());

                    if(edad<15 || edad>90)
                    {
                        Console.WriteLine("La edad debe ser de 15 a 90!");
                    }else edadIsCorrect=true;

                } while (!edadIsCorrect);

                Estudiante estudiante = new Estudiante(matricula, nombre, edad);

                estudiantes[i] = estudiante;

            }

            Console.Clear();

            for(int i = 0; i < n; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Estudiante #" + (i + 1) + ": ");
                estudiantes[i].mostrarDatos();
            }

            Console.ReadLine();
        }
    }
}
