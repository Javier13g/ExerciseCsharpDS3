using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.UI;

namespace WebServiceFeminicidios
{
    /// <summary>
    /// Summary description for Feminicidios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Feminicidios : System.Web.Services.WebService
    {
        private string connectionString = "Data Source=(local);Initial Catalog=Desarrollo3;Integrated Security=True";
        [WebMethod]
        public void RegistrarFeminicidio(int tipoDocumento, string documento, string nombres, string apellidos,
            DateTime fechaNacimiento, DateTime fechaEvento, DateTime fechaRegistro, int cantidadHijos,
            string nacionalidad, string lugarHecho, string digitadoPor)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("RegistrarFeminicidio", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@tipoDocumento", tipoDocumento);
                command.Parameters.AddWithValue("@documento", documento);
                command.Parameters.AddWithValue("@nombres", nombres);
                command.Parameters.AddWithValue("@apellidos", apellidos);
                command.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
                command.Parameters.AddWithValue("@fechaEvento", fechaEvento);
                command.Parameters.AddWithValue("@fechaRegistro", fechaRegistro);
                command.Parameters.AddWithValue("@cantidadHijos", cantidadHijos);
                command.Parameters.AddWithValue("@nacionalidad", nacionalidad);
                command.Parameters.AddWithValue("@lugarHecho", lugarHecho);
                command.Parameters.AddWithValue("@digitadoPor", digitadoPor);

                connection.Open();
                command.ExecuteNonQuery();

            }
        }
    }
}
