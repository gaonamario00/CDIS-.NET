using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad2_CajasDeBanco
{
    internal class Program
    {

        static void Main(string[] args)
        {

            int cantRetiros=0;
            int[] retiros;
            int opcion;
            int [,] billetesYMonedas = new int[10,2];
            bool opcion1first = false;
            do
            {
                do
                {
                Console.Clear();
                Console.WriteLine("------------------ Banco CDIS ------------------");
                Console.WriteLine("1. Ingresar la cantidad de retiros hechos por le usuarios.");
                Console.WriteLine("2. Revisar la cantidad entregada de billetes y monedas.");
                Console.Write("Ingresa la opcion: ");
                opcion = int.Parse(Console.ReadLine());
                }while (opcion!=1 && opcion!=2);
                
                switch (opcion)
                {
                    case 1:
                        opcion1first = true;
                        do
                        {
                            Console.Clear();
                            Console.Write("Cuantos retiros se hicieron (maximo 10): ");
                            cantRetiros = int.Parse(Console.ReadLine());
                        }while(cantRetiros<0 || cantRetiros>10);
                        retiros = new int[cantRetiros];

                        for (int i=0;i<cantRetiros; i++)
                        {
                            Console.WriteLine();
                            bool isCorrectCantidad = false;
                            do
                            {
                                Console.Write("Ingrese la cantidad del retiro #"+(i+1)+": ");
                                retiros[i] = int.Parse(Console.ReadLine());
                                if(retiros[i]<0 || retiros[i] > 50000)
                                {
                                    Console.WriteLine("La cantidad del retiro debe estar entre 0 y 50,000!");
                                }else isCorrectCantidad = true;
                            }while(!isCorrectCantidad);
                        }
                        //////////////////////////////////////////////////////////////////
                         int billetes=0, monedas=0;

                        for(int i = 0; i < retiros.Length; i++)
                        {

                            int aux = retiros[i];

                            billetes=0;
                            monedas=0;

                            while (aux>=500)
                            {
                                aux = aux - 500;
                                billetes++;
                            }
                            while (aux>=200)
                            {
                                aux = aux - 200;
                            billetes++;
                            }
                            while (aux>=100)
                            {
                                aux = aux - 100;
                                billetes++;
                            }
                            while (aux>=50)
                            {
                                aux = aux - 50;
                                billetes++;
                            }
                            while (aux>=20)
                            {
                                aux = aux - 20;
                                billetes++;
                            }
                            while (aux>=10)
                            {
                                aux = aux - 10;
                                monedas++;
                            }
                            while (aux>=5)
                            {
                                aux = aux - 5;
                                monedas++;
                            }
                            while (aux>=1)
                            {
                                aux = aux - 1;
                                monedas++;
                            }

                            billetesYMonedas[i,0] = billetes;
                            billetesYMonedas[i,1] = monedas;

                        }
                        //////////////////////////////////////////////////////////////////
                        
                        Console.WriteLine("\nPresione 'enter' para continuar");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        if (!opcion1first)
                        {
                            Console.WriteLine("Primero debe ingresar a la opcion 1!");
                            break;
                        }

                        Console.WriteLine("Cantidad de retiros: "+cantRetiros);
                        for(int i = 0; i < cantRetiros; i++)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Retiro #" +(i+1)+": ");
                            Console.WriteLine("Cantidad de billetes usados: " + billetesYMonedas[i,0]);
                            Console.WriteLine("Cantidad de monedas usadas: "+billetesYMonedas[i,1]);
                        }
                        
                        Console.WriteLine("\nPresione 'enter' para continuar");
                        Console.ReadLine();
                        break;
                }
            Console.ReadLine();
            }while (true);

        }

    }
}
