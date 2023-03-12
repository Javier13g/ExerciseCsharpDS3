using System.Data;
using System.Data.SqlClient;
using Ejercicio6;

public class insertarAcciones
{
    public void insertarAccion()
    {
        SqlConnection SqlCon;
        string stringSQL = @"Data Source =.;Initial Catalog=Desarrollo3;Integrated Security=True";
        SqlCon = new SqlConnection(stringSQL);

        var dataAccion = new Acciones();
        Acciones acciones = dataAccion;

        SqlCommand comandoSQL = new SqlCommand("[dbo].[insertAcciones]", SqlCon);
        Console.WriteLine("AGREGAR ACCIONES");

        Console.Write("Codigo Incidente: ");
        acciones.CodigoIncidente = Convert.ToInt32(Console.ReadLine());

        Console.Write("Descripcion de la accion: ");
        acciones.Descripcion = Console.ReadLine();

        Console.Write("Tipo Accion: 1) Apagar, 2)Rescate: ");
        acciones.TipoAccion = Convert.ToInt32(Console.ReadLine());

        acciones.FechaIngreso = DateTime.Now;

        Console.Write("Nombre: ");
        acciones.Nombres = Console.ReadLine();

        Console.Write("Apellidos: ");
        acciones.Apellidos = Console.ReadLine();

        Console.Write("Estado Accion: true) Completado, false) No Completado: ");
        acciones.EstadoAccion = Convert.ToBoolean(Console.ReadLine());

        comandoSQL.CommandType = CommandType.StoredProcedure;
        comandoSQL.Parameters.AddWithValue("@CodigoIncidente", acciones.CodigoIncidente);
        comandoSQL.Parameters.AddWithValue("@Descripcion", acciones.Descripcion);
        comandoSQL.Parameters.AddWithValue("@TipoAccion", acciones.TipoAccion);
        comandoSQL.Parameters.AddWithValue("@FechaIngreso", acciones.FechaIngreso);
        comandoSQL.Parameters.AddWithValue("@Nombres", acciones.Nombres);
        comandoSQL.Parameters.AddWithValue("@Apellidos", acciones.Apellidos);
        comandoSQL.Parameters.AddWithValue("@EstadoAccion", acciones.EstadoAccion);

        SqlCon.Open();
        comandoSQL.ExecuteNonQuery();
        new log($"USUARIO AÑADIO UNA ACCION \n{acciones.CodigoIncidente} \n{acciones.Descripcion} \n{acciones.TipoAccion} \n{acciones.FechaIngreso} \n{acciones.Nombres} \n{acciones.Apellidos} \n{acciones.EstadoAccion}", true);
        SqlCon.Close();
    }

}