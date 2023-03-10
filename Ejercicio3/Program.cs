using System;
using System.Data;
using System.Data.SqlClient;
using ConsoleTables;


namespace Ejercicio3
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

                var dataVivienda = new Vivienda();
                Vivienda vivienda = dataVivienda;

                var dataPersona = new Persona();
                Persona persona = dataPersona;

                int opcion = 0;
                do
                {
                    Console.Clear();
                    Console.WriteLine("------------------------------------BIENVENIDOS------------------------------------");
                    Console.WriteLine("Digite una opcion:");
                    Console.WriteLine("1) Agregar Viviendas");
                    Console.WriteLine("2) Agregar Personas");
                    Console.WriteLine("3) Listado Viviendas");
                    Console.WriteLine("4) Listado Personas");
                    Console.WriteLine("5) Salir");
                    Console.Write("Digite una opcion: ");
                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            SqlCommand comandoSQL = new SqlCommand("insertViviendas", SqlCon);
                            Console.WriteLine("AGREGAR VIVIENDA");
                            Console.Write("Codigo vivienda: ");
                            vivienda.CodigoCasa = Console.ReadLine();

                            Console.Write("Direccion: ");
                            vivienda.Direccion = Console.ReadLine();

                            Console.Write("Ciudad: ");
                            vivienda.Ciudad = Console.ReadLine();

                            Console.Write("Pais: ");
                            vivienda.Pais = Console.ReadLine();

                            Console.Write("Tipo Vivienda: ");
                            vivienda.Tipo = Convert.ToInt32(Console.ReadLine());

                            vivienda.FechaIngreso = DateTime.Now;

                            comandoSQL.CommandType = CommandType.StoredProcedure;
                            comandoSQL.Parameters.AddWithValue("@CodigoCasa", vivienda.CodigoCasa);
                            comandoSQL.Parameters.AddWithValue("@Direccion", vivienda.Direccion);
                            comandoSQL.Parameters.AddWithValue("@Ciudad", vivienda.Ciudad);
                            comandoSQL.Parameters.AddWithValue("@Pais", vivienda.Pais);
                            comandoSQL.Parameters.AddWithValue("@Tipo", vivienda.Tipo);
                            comandoSQL.Parameters.AddWithValue("@FechaIngreso", vivienda.FechaIngreso);

                            SqlCon.Open();
                            comandoSQL.ExecuteNonQuery();
                            SqlCon.Close();
                            break;
                        case 2:
                            SqlCommand comandoSQL2 = new SqlCommand("insertPersonas", SqlCon);
                            Console.WriteLine("AGREGAR PERSONAS");
                            Console.Write("Nombre: ");
                            persona.Nombres = Console.ReadLine();

                            Console.Write("Apellido: ");
                            persona.Apellidos = Console.ReadLine();

                            Console.Write("Sexo: ");
                            persona.Sexo = Console.ReadLine();

                            Console.Write("Edad: ");
                            persona.Edad = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Codigo Casa: ");
                            persona.CodigoCasa = Console.ReadLine();

                            persona.FechaIngreso = DateTime.Now;

                            comandoSQL2.CommandType = CommandType.StoredProcedure;
                            comandoSQL2.Parameters.AddWithValue("@Nombres", persona.Nombres);
                            comandoSQL2.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
                            comandoSQL2.Parameters.AddWithValue("@Sexo", persona.Sexo);
                            comandoSQL2.Parameters.AddWithValue("@Edad", persona.Edad);
                            comandoSQL2.Parameters.AddWithValue("@Estado", persona.Edad);
                            comandoSQL2.Parameters.AddWithValue("@CodigoCasa", persona.CodigoCasa);
                            comandoSQL2.Parameters.AddWithValue("@FechaIngreso", persona.FechaIngreso);

                            SqlCon.Open();
                            comandoSQL2.ExecuteNonQuery();
                            /*using (SqlDataReader reader = comandoSQL2.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine(reader[0].ToString());
                                }
                            }*/
                            SqlCon.Close();
                            break;

                        case 3:
                            string query = "Select * from tblViviendas";
                            Console.WriteLine("------------------------------------LISTA DE VIVIENDAS------------------------------------");

                            var table = new ConsoleTable("Codigo Casa", "Direccion", "Ciudad",
                            "Pais", "Tipo Vivienda", "Cantidad", "Fecha Ingreso");
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
                                        reader[4], reader[5], reader[6], reader[7]);
                                    }
                                }
                            }
                            table.Write();
                            SqlCon.Close();
                            break;

                        case 4:
                        string query2 = "Select * from tblPersonas";
                            Console.WriteLine("------------------------------------LISTA DE PERSONAS------------------------------------");
                            var table2 = new ConsoleTable("Nombres", "Apellidos", "Sexo",
                            "Edad", "Estado", "Codigo Casa", "Fecha Ingreso");
                            //table.AddRow(1, 2, 3, 4, 5, 6, 7, 8);


                            using (SqlCommand command = new SqlCommand(query2, SqlCon))
                            {
                                SqlCon.Open();
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    // Imprimir las filas de la tabla en la consola
                                    while (reader.Read())
                                    {
                                        table2.AddRow(reader[1], reader[2], reader[3],
                                        reader[4], reader[5], reader[6], reader[7]);
                                    }
                                }
                            }
                            table2.Write();
                            SqlCon.Close();
                            break;
                        case 5:
                            Console.WriteLine("Saliendo de la aplicacion");
                            break;

                        default:
                            Console.WriteLine("Elige una opcion entre 1 y 3");
                            break;
                    }
                    Console.ReadKey();
                } while (opcion != 5);

            }
            catch (Exception ex)
            {
                Console.Write("Error debido a: " + ex);
            }
        }
    }
}
