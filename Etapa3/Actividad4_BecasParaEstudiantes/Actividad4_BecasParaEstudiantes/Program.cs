using Actividad4_BecasParaEstudiantes.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad4_BecasParaEstudiantes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            bool nIsIncorrect = true;
            while (nIsIncorrect)
            {
                try
                {
                    Console.Write("Ingrese la cantidad de estudiantes: ");
                    n = int.Parse(Console.ReadLine());
                    nIsIncorrect = false;
                    if(n == 0)
                    {
                        Console.WriteLine("La cantidad de estudiantes debe ser mayor a cero");
                        nIsIncorrect = true;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Error:" + ex.Message);
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("Error:" + ex.Message);
                }
            }

            Estudiante[] estudiantes = new Estudiante[n];

            Console.Clear();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Estudiante #" + (i + 1) + ": ");
                Console.WriteLine();

                Console.Write("Nombre:");
                string nombre = Console.ReadLine();

                int matricula = 0;
                bool matriculaIsIncorrect = true;

                while (matriculaIsIncorrect)
                {
                    try
                    {
                        Console.Write("Matricula: ");
                        matricula = int.Parse(Console.ReadLine());
                        matriculaIsIncorrect = false;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Error:" + ex.Message);
                    }
                    catch (OverflowException ex)
                    {
                        Console.WriteLine("Error:" + ex.Message);
                    }
                }

                bool edadIsIncorrect = true;
                int edad = 0;

                while (edadIsIncorrect)
                {
                    try
                    {
                        Console.Write("Edad:");
                        edad = int.Parse(Console.ReadLine());
                        edadIsIncorrect = false;
                        if (edad < 15 || edad > 90)
                        {
                            edadIsIncorrect = true;
                            Console.WriteLine("La edad debe ser de 15 a 90!");
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Error:" + ex.Message);
                    }
                    catch (OverflowException ex)
                    {
                        Console.WriteLine("Error:" + ex.Message);
                    }

                }

                bool cuotaIsIncorrect = true;
                int cuota = 0;

                while (cuotaIsIncorrect)
                {
                    try
                    {
                        Console.Write("cantidad cuota escolar:");
                        cuota = int.Parse(Console.ReadLine());
                        cuotaIsIncorrect = false;
                        if (cuota < 0)
                        {
                            cuotaIsIncorrect = true;
                            Console.WriteLine("La cuota debe ser de mayor a cero!");
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Error:" + ex.Message);
                    }
                    catch (OverflowException ex)
                    {
                        Console.WriteLine("Error:" + ex.Message);
                    }
                }

                int nivel = 1;
                bool nivelIsIncorrect = true;

                while (nivelIsIncorrect)
                {
                    try
                    {
                        Console.WriteLine("\nSeleccione el nivel del estudiante\n1. Licenciatura\n2. Posgrado");
                        Console.Write("Nivel: ");
                        nivel = int.Parse(Console.ReadLine());
                        nivelIsIncorrect = false;

                        if (nivel != 1 && nivel != 2)
                        {
                            nivelIsIncorrect = true;
                            Console.WriteLine("elija una opcion valida!");
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Error:" + ex.Message);
                    }
                    catch (OverflowException ex)
                    {
                        Console.WriteLine("Error:" + ex.Message);
                    }
                }

                switch (nivel)
                {
                    case 1:

                        char c = 'S';
                        double beca = 0;
                        bool becaIsIncorrect = true;
                        while (becaIsIncorrect)
                        {
                            try
                            {
                                Console.Write("El alumno cuenta con beca? (S/N): ");
                                c = char.Parse(Console.ReadLine());
                                if (c == 'S' || c == 's')
                                {
                                    Console.Write("Ingrese el porcentaje de beca (0-100):");
                                    beca = double.Parse(Console.ReadLine());
                                    if (beca<0 || beca>100)
                                    {
                                        becaIsIncorrect = true;
                                        Console.Write("porcentaje de beca invalido");
                                    }
                                }
                                becaIsIncorrect = false;
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine("Error:" + ex.Message);
                            }
                            catch (OverflowException ex)
                            {
                                Console.WriteLine("Error:" + ex.Message);
                            }
                        }

                        


                        bool servicio;
                        Console.Write("Realizo su servicio social? (S/N):");
                        c = char.Parse(Console.ReadLine());

                        if (c == 's' || c == 'S') servicio = true;
                        else servicio = false;

                        EstudianteLicenciatura a = new EstudianteLicenciatura(matricula, nombre, edad, cuota, servicio);
                        estudiantes[i] = a;
                        estudiantes[i].asignarBeca(beca);

                        break;
                    case 2:
                        char c1 = 'S';
                        double beca1 = 0;
                        bool beca1IsIncorrect = true;
                        while (beca1IsIncorrect)
                        {
                            try
                            {
                                Console.Write("El alumno cuenta con beca? (S/N): ");
                                c1 = char.Parse(Console.ReadLine());
                                if (c1 == 'S' || c1 == 's')
                                {
                                    Console.Write("Ingrese el porcentaje de beca (0-100):");
                                    beca1 = double.Parse(Console.ReadLine());
                                    if (beca1 < 0 || beca1 > 100)
                                    {
                                        beca1IsIncorrect = true;
                                        Console.Write("porcentaje de beca invalido");
                                    }
                                }
                                beca1IsIncorrect = false;
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine("Error:" + ex.Message);
                            }
                            catch (OverflowException ex)
                            {
                                Console.WriteLine("Error:" + ex.Message);
                            }
                        }

                        int nivelSNI = 0;
                        bool SNIIsIncorrect = true;

                        while (SNIIsIncorrect)
                        {
                            try
                            {
                                Console.Write("Ingrese el nivelSNI:");
                                nivelSNI = int.Parse(Console.ReadLine());

                                if (nivelSNI < 1 || nivelSNI > 3)
                                {
                                    SNIIsIncorrect = true;
                                    Console.WriteLine("SNI debe ser 1, 2, 3");
                                }
                                SNIIsIncorrect = false;
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine("Error:" + ex.Message);
                            }
                            catch (OverflowException ex)
                            {
                                Console.WriteLine("Error:" + ex.Message);
                            }
                        }

                        EstudiantePosgrado b = new EstudiantePosgrado(matricula, nombre, edad, cuota, nivelSNI);
                        estudiantes[i] = b;
                        estudiantes[i].asignarBeca(beca1);
                        break;
                }

            }

            Console.Clear();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Estudiante #"+(i+1)+": ");
                estudiantes[i].mostrarDatos();
            }

                Console.ReadLine();
        }
    }
}
