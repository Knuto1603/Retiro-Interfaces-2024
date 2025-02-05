using Retiro_Interfaces_2024.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Retiro_Interfaces_2024.Controllers
{
    public class GestionaEscuela
    {
        private static GestionaConexion conn = new GestionaConexion();
        public static EscuelaModel ObtenerEscuelaDeBD(string cod, FacultadModel facultad)
        {
            using (SqlConnection conn1 = conn.CrearConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerEscuela", conn1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodigoUniversitario", cod);

                conn1.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new EscuelaModel(
                            reader["Codigo_Escuela"].ToString(),
                            reader["Nombre"].ToString(),
                            Convert.ToDateTime(reader["Fecha_Creacion"]),
                            facultad
                        );
                    }
                }
            }
            throw new Exception("No se encontró la escuela.");
        }
    }
}