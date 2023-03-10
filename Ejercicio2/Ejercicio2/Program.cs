using System;
using System.Data.SqlClient;

namespace Ejercicio2
{
    public class temblorData
    {
        public decimal Intensidad { get; set; }
        public string Localidad { get; set; }
        public DateTime FechaEvento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public int CantidadMuerto { get; set; }
        public int CantidadHeridos { get; set; }
        public decimal PerdidasFinancieras { get; set; }
        public string Tsunami { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection;
            string sql = @"Data Source =.;Initial Catalog=Desarrollo3;Integrated Security=True";
            try
            {
                connection = new SqlConnection(sql);
                connection.Open();
                Console.WriteLine("Conexion Exitosa");

                var data = new temblorData();
                temblorData td = data;

                Console.Write("Intensidad del terremoto: ");
                data.Intensidad = decimal.Parse(Console.ReadLine());

                Console.Write("Localidad del evento: ");
                data.Localidad = Console.ReadLine();

                Console.Write("Fecha del terremoto: ");
                data.FechaEvento = DateTime.Parse(Console.ReadLine());

                data.FechaRegistro = DateTime.Now;

                Console.Write("Pais afectado: ");
                data.Pais = Console.ReadLine();

                Console.Write("Ciudad Afectada: ");
                data.Ciudad = Console.ReadLine();

                Console.Write("Cantidad muertes: ");
                data.CantidadMuerto = int.Parse(Console.ReadLine());

                Console.Write("Cantidad Heridos: ");
                data.CantidadHeridos = int.Parse(Console.ReadLine());

                Console.Write("Total perdidas financieras: ");
                data.PerdidasFinancieras = decimal.Parse(Console.ReadLine());

                Console.Write("Hubo Tsunami: ");
                data.Tsunami = Console.ReadLine();

                string query = "INSERT INTO TEMBLOR(Intensidad, Localidad, FechaEvento, FechaRegistro, Pais, Ciudad," +
                    "CantidadMuerto, CantidadHeridos, PerdidasFinancieras, Tsunami) VALUES(" + data.Intensidad + " , '" + data.Localidad + "', '" + data.FechaEvento.ToShortDateString() +"', '"+ data.FechaRegistro +"', '"+ data.Pais +"' ," +
                    "'"+ data.Ciudad +"' , "+ data.CantidadMuerto +" , "+ data.CantidadHeridos +", "+ data.PerdidasFinancieras +" , '"+ data.Tsunami +"')";

                SqlCommand insert = new SqlCommand(query, connection);
                insert.ExecuteNonQuery();

                Console.WriteLine("Dato añadido con exito");

            }
            catch (Exception e)
            {
                Console.WriteLine("El error es debido a: " + e.Message);
            }
        }
    }
}