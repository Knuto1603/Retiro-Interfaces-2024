using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Retiro_Interfaces_2024.Controllers
{
    public class GestionaConexion
    {
        private string ConnectionString { get; set; }

        // Constructor: obtiene la cadena de conexión desde Web.config
        public GestionaConexion()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        }

        // Método para crear una conexión
        public SqlConnection CrearConexion()
        {
            return new SqlConnection(ConnectionString);
        }

        // Método para probar la conexión
        public bool ProbarConexion()
        {
            using (SqlConnection connection = CrearConexion())
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexión exitosa a la base de datos.");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al conectar: {ex.Message}");
                    return false;
                }
            }
        }


        // Método para ejecutar consultas (SELECT)
        public SqlDataReader EjecutarConsulta(string query)
        {
            using (SqlConnection connection = CrearConexion())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    return command.ExecuteReader(); // Devuelve un lector de datos
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al ejecutar consulta: {ex.Message}");
                    throw;
                }
            }
        }


        // Método para ejecutar comandos (INSERT, UPDATE, DELETE)
        public int EjecutarComando(string query)
        {
            using (SqlConnection connection = CrearConexion())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    return command.ExecuteNonQuery(); // Devuelve el número de filas afectadas
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al ejecutar comando: {ex.Message}");
                    throw;
                }
            }
        }

    }
}