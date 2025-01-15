using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
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


        // Método para ejecutar un procedimiento almacenado sin retorno de datos
        public int EjecutarProcedimiento(string procedimiento, Dictionary<string, object> parametros = null)
        {
            using (SqlConnection connection = CrearConexion())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(procedimiento, connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    // Agregar parámetros si existen
                    if (parametros != null)
                    {
                        foreach (var parametro in parametros)
                        {
                            command.Parameters.AddWithValue(parametro.Key, parametro.Value ?? DBNull.Value);
                        }
                    }

                    // Ejecutar el procedimiento almacenado
                    return command.ExecuteNonQuery(); // Devuelve el número de filas afectadas
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al ejecutar el procedimiento: {ex.Message}");
                    throw;
                }
            }
        }

        // Método para consultar un procedimiento almacenado y obtener datos
        public SqlDataReader ConsultarProcedimiento(string procedimiento, Dictionary<string, object> parametros = null)
        {
            SqlConnection connection = CrearConexion();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(procedimiento, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Agregar parámetros si existen
                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        command.Parameters.AddWithValue(parametro.Key, parametro.Value ?? DBNull.Value);
                    }
                }

                // Ejecutar y devolver el lector de datos
                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al consultar el procedimiento: {ex.Message}");
                connection.Close();
                throw;
            }
        }

    }
}