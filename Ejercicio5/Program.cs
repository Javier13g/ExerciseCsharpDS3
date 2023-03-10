using System;
using System.Data;
using System.Data.SqlClient;
using ConsoleTables;

namespace Ejercicio5
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

                var dataFeligreses = new Feligreses();
                Feligreses F = dataFeligreses;

                var dataActividad = new Actividad();
                Actividad V = dataActividad;

                int opcion = 0;

                do
                {
                    Console.Clear();
                    Console.WriteLine("------------------------------------BIENVENIDOS------------------------------------");
                    Console.WriteLine("Digite una opcion:");
                    Console.WriteLine("1) Agregar Feligreses");
                    Console.WriteLine("2) Agregar Actividad");
                    Console.WriteLine("3) Listado Feligreses");
                    Console.WriteLine("4) Salir");
                    Console.Write("Digite una opcion: ");
                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            SqlCommand comandoSQL = new SqlCommand("[dbo].[insertFeligreses]", SqlCon);
                            Console.WriteLine("AGREGAR FELIGRESES");

                            Console.Write("Nombre: ");
                            F.Nombre = Console.ReadLine();

                            Console.Write("Apellido: ");
                            F.Apellido = Console.ReadLine();

                            Console.Write("Tipo Documento: 1) Cedula  2) Pasaporte  3) Visa");
                            F.TipoDocumento = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Documento: ");
                            F.Documento = Console.ReadLine();

                            Console.Write("Fecha Nacimiento: ");
                            F.FechaNacimiento = Console.ReadLine();

                            F.FechaIngreso = DateTime.Now;

                            Console.Write("Sexo(M o F): ");
                            F.Sexo = Console.ReadLine();

                            Console.Write("Bautizado(true o false): ");
                            F.Bautizado = Convert.ToBoolean(Console.ReadLine());

                            Console.Write("Estado Civil: ");
                            F.EstadoCivil = Console.ReadLine();

                            Console.Write("Confirmacion");
                            F.Confirmacion = Convert.ToBoolean(Console.ReadLine());

                            comandoSQL.CommandType = CommandType.StoredProcedure;
                            comandoSQL.Parameters.AddWithValue("@Nombre", F.Nombre);
                            comandoSQL.Parameters.AddWithValue("@Apellido", F.Apellido);
                            comandoSQL.Parameters.AddWithValue("@TipoDocumento", F.TipoDocumento);
                            comandoSQL.Parameters.AddWithValue("@Documento", F.Documento);
                            comandoSQL.Parameters.AddWithValue("@FechaNacimiento", F.FechaNacimiento);
                            comandoSQL.Parameters.AddWithValue("@FechaIngreso", F.FechaIngreso);
                            comandoSQL.Parameters.AddWithValue("@Sexo", F.Sexo);
                            comandoSQL.Parameters.AddWithValue("@Bautizado", F.Bautizado);
                            comandoSQL.Parameters.AddWithValue("@EstadoCivil", F.EstadoCivil);
                            comandoSQL.Parameters.AddWithValue("@Confirmacion", F.Confirmacion);

                            SqlCon.Open();
                            comandoSQL.ExecuteNonQuery();
                            new log($"USUARIO AÑADIO UN FELIGRES \n{F.Nombre} \n{F.Apellido} \n{F.TipoDocumento} \n{F.Documento} \n{F.FechaNacimiento} \n{F.FechaIngreso} \n{F.Sexo} \n{F.Bautizado} \n{F.EstadoCivil} \n{F.Confirmacion}", true);
                            SqlCon.Close();

                            break;
                        case 2:
                            SqlCommand comandoSQL2 = new SqlCommand("insertActividad", SqlCon);
                            Console.WriteLine("AGREGAR ACTIVIDADES");

                            Console.Write("Tipo Documento: 1) Cedula  2) Pasaporte  3) Visa");
                            V.TipoDocumento = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Documento: ");
                            V.Documento = Console.ReadLine();

                            Console.Write("Tipo Evento: 1) Comunion  2) Ceniza  3) Asistencia");
                            V.TipoEvento = Convert.ToInt32(Console.ReadLine());

                            V.FechaIngreso = DateTime.Now;

                            Console.Write("Digitado: ");
                            V.Digitado = Console.ReadLine();

                            Console.Write("Localidad: ");
                            V.Localidad = Console.ReadLine();

                            Console.Write("Nota: ");
                            V.Nota = Console.ReadLine();

                            comandoSQL2.CommandType = CommandType.StoredProcedure;
                            comandoSQL2.Parameters.AddWithValue("@TipoDocumento", V.TipoDocumento);
                            comandoSQL2.Parameters.AddWithValue("@Documento", V.Documento);
                            comandoSQL2.Parameters.AddWithValue("@TipoEvento", V.TipoEvento);
                            comandoSQL2.Parameters.AddWithValue("@FechaIngreso", V.FechaIngreso);
                            comandoSQL2.Parameters.AddWithValue("@Digitado", V.Digitado);
                            comandoSQL2.Parameters.AddWithValue("@Localidad", V.Localidad);
                            comandoSQL2.Parameters.AddWithValue("@Nota", V.Nota);
                            SqlCon.Open();
                            comandoSQL2.ExecuteNonQuery();
                            new log($"USUARIO AÑADIO UNA ACTIVIDAD \n{V.TipoDocumento}, \n{V.Documento} \n{V.TipoDocumento} \n{V.TipoEvento} \n{V.FechaIngreso} \n{V.Digitado} \n{V.Localidad} \n{V.Nota}", true);
                            SqlCon.Close();

                            break;
                        case 3:
                            Console.WriteLine("LISTA DE FELIGRESES");
                            string query = "Select * from tblFeligreses";
                            Console.WriteLine("------------------------------------LISTA DE FELIGRESES------------------------------------");

                            var table = new ConsoleTable("Nombre", "Apellido", "TipoDocumento", "Documento", "Fecha Nacimiento",
                            "Fecha Ingreso", "Sexo", "Bautizado", "Estado Civil", "Confirmacion", "Cantidad Comunion", "Cantidad Ceniza",
                            "Cantidad Asistencia");
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
                                        reader[4], reader[5], reader[6], reader[7], reader[8], reader[9],
                                        reader[10], reader[11], reader[12], reader[13]);
                                    }
                                }
                            }
                            table.Write();
                            Console.WriteLine("");
                            new log("USUARIO VERIFICO LOS FELIGRESES", true);
                            SqlCon.Close();
                            break;

                        case 4:
                            Console.Write("Saliendo..................");
                            new log("USUARIO HA SALIDO DE LA APLICACION", true);
                            break;
                        default:
                            Console.WriteLine("Elige una opcion entre 1 y 4");
                            new log("USUARIO SELECCIONO UNA OPCION FUERA DE LAS DISPONIBLES", true);
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