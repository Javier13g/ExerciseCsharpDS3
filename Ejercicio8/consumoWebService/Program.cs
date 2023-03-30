using System;
using WebServiceFeminicidios;
namespace consumoWebService
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear objeto de servicio web
            Feminicidios servicioWeb = new Feminicidios();

            // Llamar al método RegistrarFeminicidio del servicio web
            servicioWeb.RegistrarFeminicidio(2, "123456789", "Maria", "Perez", "1990-01-01".ti, 2022-03-29, DateTime.Now, 2, "Colombiana", "Bogotá", "Juan Perez");

            Console.WriteLine("Feminicidio registrado con éxito.");
            Console.ReadLine();
        }
    }
}