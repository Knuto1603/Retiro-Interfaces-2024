using Retiro_Interfaces_2024.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Retiro_Interfaces_2024.Controllers
{
    public class GestionaFacultad
    {
        private static GestionaConexion conn = new GestionaConexion();

        public static FacultadModel ObtenerFacultadDeBD(string codigoUniversitario)
        {
            using (SqlConnection conn1 = conn.CrearConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerFacultad", conn1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodigoUniversitario", codigoUniversitario);

                conn1.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new FacultadModel(
                            reader["codigoFacultad"].ToString(),
                            reader["nombre"].ToString(),
                            Convert.ToDateTime(reader["fechaCreacion"])
                        );
                    }
                }
            }
            throw new Exception("No se encontró la facultad.");
        }

    }
}