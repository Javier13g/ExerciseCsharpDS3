// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using ConsoleTables;


namespace Ejercicio4
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection SqlCon;
            string stringSQL = @"Data Source =.;Initial Catalog=Desarrollo3;Integrated Security=True";

            try
            {
                SqlCon = new SqlConnection(stringSQL);
                
                var dataPersona = new Personas();
                Personas p = dataPersona;

                var dataMomentos = new Momentos();
                Momentos m = dataMomentos;

                int opcion = 0;

                do
                {
                    Console.Clear();
                    Console.WriteLine("------------------------------------BIENVENIDOS------------------------------------");
                    Console.WriteLine("Digite una opcion:");
                    Console.WriteLine("1) Agregar Personas");
                    Console.WriteLine("2) Agregar Momentos");
                    Console.WriteLine("3) Listado Personas");
                    Console.WriteLine("4) Salir");
                    Console.Write("Digite una opcion: ");
                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            SqlCommand comandoSQL = new SqlCommand("insertarRegistroPersonass", SqlCon);
                            Console.WriteLine("AGREGAR PERSONA");
                            
                            Console.Write("Tipo Documento: ");
                            p.TipoDocumento = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Documento: ");
                            p.Documento = Console.ReadLine();

                            Console.Write("Nombres: ");
                            p.Nombres = Console.ReadLine();

                            Console.Write("Apellidos: ");
                            p.Apellidos = Console.ReadLine();

                            Console.Write("FechaNacimiento: ");
                            p.FechaNacimiento = Console.ReadLine();

                            p.FechaIngreso = DateTime.Now;

                            Console.Write("Sexo: ");
                            p.Sexo = Console.ReadLine();

                            comandoSQL.CommandType = CommandType.StoredProcedure;
                            comandoSQL.Parameters.AddWithValue("@TipoDocumento", p.TipoDocumento);
                            comandoSQL.Parameters.AddWithValue("@Documento", p.Documento);
                            comandoSQL.Parameters.AddWithValue("@Nombres", p.Nombres);
                            comandoSQL.Parameters.AddWithValue("@Apellidos", p.Apellidos);
                            comandoSQL.Parameters.AddWithValue("@FechaNacimiento", p.FechaNacimiento);
                            comandoSQL.Parameters.AddWithValue("@FechaIngreso", p.FechaIngreso);
                            comandoSQL.Parameters.AddWithValue("@Sexo", p.Sexo);

                            SqlCon.Open();
                            comandoSQL.ExecuteNonQuery();
                            SqlCon.Close();
                            break;
                        case 2:
                           SqlCommand comandoSQL2 = new SqlCommand("insertarMomentos", SqlCon);
                            Console.WriteLine("AGREGAR MOMENtOS");
                            Console.Write("Tipo Evento: ");
                            m.TipoEvento = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Descripcion: ");
                            m.Descripcion = Console.ReadLine();

                            Console.Write("Tiempo: ");
                            m.TiempoFelicidad = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Tipo Documento: ");
                            m.TipoDocumento = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Documento: ");
                            m.Documento = Console.ReadLine();

                            m.FechaIngreso = DateTime.Now;

                            comandoSQL2.CommandType = CommandType.StoredProcedure;
                            comandoSQL2.Parameters.AddWithValue("@TipoEvento", m.TipoEvento);
                            comandoSQL2.Parameters.AddWithValue("@Descripcion", m.Descripcion);
                            comandoSQL2.Parameters.AddWithValue("@TiempoFelicidad", m.TiempoFelicidad);
                            comandoSQL2.Parameters.AddWithValue("@TipoDocumento", m.TipoDocumento);
                            comandoSQL2.Parameters.AddWithValue("@Documento", m.Documento);
                            comandoSQL2.Parameters.AddWithValue("@FechaIngreso", m.FechaIngreso);

                            SqlCon.Open();
                            comandoSQL2.ExecuteNonQuery();
                            SqlCon.Close();
                            break;

                        case 3:
                            string query = "Select * from tblRegistroPersonas";
                            Console.WriteLine("------------------------------------LISTA DE PERSONAS------------------------------------");

                            var table = new ConsoleTable("Tipo Documento", "Documento", "Nombres", "Apellidos",
                            "Fecha Nacimiento", "Fecha Ingreso", "Sexo", "Tiempo Felicidad");
                            //table.AddRow(1, 2, 3, 4, 5, 6, 7, 8);

                            
                            using (SqlCommand command = new SqlCommand(query, SqlCon))
                            {
                                SqlCon.Open();
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    // Imprimir las filas de la tabla en la consola
                                    while (reader.Read())
                                    {
                                        table.AddRow(reader[1], reader[2], reader[3], 
                                        reader[4], reader[5], reader[6], reader[7], reader[8]);
                                    }
                                }
                            }
                            table.Write();
                            SqlCon.Close();
                            break;
                        case 4:
                            Console.WriteLine("Saliendo de la aplicacion");
                            break;

                        default:
                            Console.WriteLine("Elige una opcion entre 1 y 3");
                            break;
                    }
                    Console.ReadKey();
                } while (opcion != 4);
            }
            catch (System.Exception)
            {
                
                throw;
            }

        }
    }
}
