using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;


namespace Ejercicio7
{
    [RunInstaller(true)]
    public partial class Service1 : ServiceBase
    {
        int tiempo = Settings1.Default.Tiempo;
        public Thread worker = null;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                ThreadStart start = new ThreadStart(Working);
                worker = new Thread(start);
                worker.Start();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Working()
        {
            SqlConnection SqlCon;
            string stringSQL = @"Data Source =.;Initial Catalog=Desarrollo3;Integrated Security=True";
            SqlCon = new SqlConnection(stringSQL);
            int i = 0;
            StreamWriter sw = new StreamWriter("C:\\Test.txt");
            string query = "Select * from tblIncidentes";
            while (true)
            {
                using (SqlCommand command = new SqlCommand(query, SqlCon))
                {
                    SqlCon.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Imprimir las filas de la tabla en la consola
                        while (reader.Read())
                        {
                            sw.Write(reader[1].ToString());
                            sw.Write(reader[2].ToString());
                            sw.Write(reader[3].ToString());
                            sw.WriteLine();
                            sw.Flush();

                            /*table.AddRow(reader[1], reader[2], reader[3],
                            reader[4], reader[5], reader[6], reader[7], reader[8], reader[9],
                            reader[10], reader[11], reader[12], reader[13]);*/

                        }
                        i++;
                        sw.Close();
                        Thread.Sleep(tiempo * 60 * 1000);
                    }
                }
               
            }
        }

        protected override void OnStop()
        {
            try
            {
                if(worker != null && worker.IsAlive)
                {
                    worker.Abort();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
