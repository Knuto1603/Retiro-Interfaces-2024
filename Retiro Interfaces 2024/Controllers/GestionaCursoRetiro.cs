using Retiro_Interfaces_2024.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Retiro_Interfaces_2024.Controllers
{
    public class GestionaCursoRetiro
    {
        private static GestionaConexion conn = new GestionaConexion();
        public static CursoRetiroModel ObtenerCursoDeBD(string codigoCurso)
        {
            using (SqlConnection conn1 = conn.CrearConexion())
            {
                // Crear el comando para llamar al procedimiento almacenado
                SqlCommand cmd = new SqlCommand("ObtenerDetallesCurso", conn1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodigoCurso", codigoCurso);

                // Abrir la conexión
                conn1.Open();

                // Ejecutar el procedimiento y leer los resultados
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Crear el objeto CursoRetiroModel con los datos obtenidos
                        return new CursoRetiroModel(
                            reader["CodigoCurso"].ToString(),
                            reader["NombreCurso"].ToString(),
                            reader["Creditos"].ToString(),
                            reader["Docente"].ToString()
                        );
                    }
                }
            }

            // Si no se encuentra el curso, lanzar una excepción
            throw new Exception("No se encontró el curso con el código especificado.");
        }
    }
}