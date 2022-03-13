using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad1_Piramide
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool alturaEsCorrecta = false;
            int altura = 0;
            do
            {
                Console.Write("Ingrese la altura de la piramide: ");
                altura = int.Parse(Console.ReadLine());

                if (altura < 0 || altura > 25)
                {
                    Console.WriteLine("Ingrese una altura valida (0 - 25)");
                    alturaEsCorrecta = false;
                }
                else alturaEsCorrecta = true;

            } while (!alturaEsCorrecta);

            Console.WriteLine();

            for (int i = 1; i <= altura; i++)
            {
                //Console.Write("  ");
                for (int j = i; j < altura; j++)
                {
                    Console.Write(" ");
                }

                for (int j = 0; j < i; j++)
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Programa finalizado");
            Console.ReadLine();
        }
    }
}
