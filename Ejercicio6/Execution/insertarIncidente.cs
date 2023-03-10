using System.Data;
using System.Data.SqlClient;
using Ejercicio6;

public class insertarIncidente
{
    public void insertarIncidentes()
    {
        SqlConnection SqlCon;
        string stringSQL = @"Data Source =.;Initial Catalog=Desarrollo3;Integrated Security=True";
        SqlCon = new SqlConnection(stringSQL);

        var dataIncidente = new Incidentes();
        Incidentes incidentes = dataIncidente;

        SqlCommand comandoSQL = new SqlCommand("[dbo].[insertIncidentes]", SqlCon);
        Console.WriteLine("AGREGAR INCIDENTE");

        Console.Write("Descripcion del incidente: ");
        incidentes.Descripcion = Console.ReadLine();

        Console.Write("Localidad del incidente: ");
        incidentes.Localidad = Console.ReadLine();

        Console.Write("Sector del incidente: ");
        incidentes.Sector = Console.ReadLine();

        Console.Write("Ciudad del incidente: ");
        incidentes.Ciudad = Console.ReadLine();

        Console.Write("Direccion del incidente: ");
        incidentes.Direccion = Console.ReadLine();

        Console.Write("# Telefono: ");
        incidentes.Telefono = Console.ReadLine();

        Console.Write("Tipo incidente: ");
        incidentes.TipoIncidente = Convert.ToInt32(Console.ReadLine());

        Console.Write("Estado incidente: ");
        incidentes.EstadoIncidente = Convert.ToBoolean(Console.ReadLine());

        incidentes.FechaIngreso = DateTime.Now;

        comandoSQL.CommandType = CommandType.StoredProcedure;
        comandoSQL.Parameters.AddWithValue("@Descripcion", incidentes.Descripcion);
        comandoSQL.Parameters.AddWithValue("@Localidad", incidentes.Localidad);
        comandoSQL.Parameters.AddWithValue("@Sector", incidentes.Sector);
        comandoSQL.Parameters.AddWithValue("@Ciudad", incidentes.Ciudad);
        comandoSQL.Parameters.AddWithValue("@Direccion", incidentes.Direccion);
        comandoSQL.Parameters.AddWithValue("@Telefono", incidentes.Telefono);
        comandoSQL.Parameters.AddWithValue("@TipoIncidente", incidentes.TipoIncidente);
        comandoSQL.Parameters.AddWithValue("@EstadoIncidente", incidentes.EstadoIncidente);
        comandoSQL.Parameters.AddWithValue("@FechaIngreso", incidentes.FechaIngreso);

        SqlCon.Open();
        comandoSQL.ExecuteNonQuery();
        new log($"USUARIO AÑADIO UN INCIDENTE \n{incidentes.Descripcion} \n{incidentes.Localidad} \n{incidentes.Sector} \n{incidentes.Ciudad} \n{incidentes.Direccion} \n{incidentes.Telefono} \n{incidentes.TipoIncidente} \n{incidentes.EstadoIncidente} \n{incidentes.FechaIngreso}", true);
        SqlCon.Close();
    }

}
