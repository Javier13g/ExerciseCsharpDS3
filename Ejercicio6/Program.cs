using System;
using System.Data;
using System.Data.SqlClient;
using ConsoleTables;

namespace Ejercicio6
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int opcion = 0;
                do
                {
                    Console.Clear();
                    Console.WriteLine("------------------------------------BIENVENIDOS------------------------------------");
                    Console.WriteLine("Digite una opcion:");
                    Console.WriteLine("1) Agregar Incidente");
                    Console.WriteLine("2) Agregar Accion");
                    Console.WriteLine("3) Listado Incidentes");
                    Console.WriteLine("4) Salir");
                    Console.Write("Digite una opcion: ");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                        insertarIncidente insertar = new insertarIncidente();
                        insertar.insertarIncidentes();
                            break;
                        
                        case 2:
                        insertarAcciones insertar2 = new insertarAcciones();
                        insertar2.insertarAccion();
                        break;
                        default:
                            break;
                    }
                    Console.ReadKey();
                } while (opcion != 4);
            }
            catch (Exception ex)
            {
                new log("ERROR: " + ex.Message, true);
            }
        }
    }
}

