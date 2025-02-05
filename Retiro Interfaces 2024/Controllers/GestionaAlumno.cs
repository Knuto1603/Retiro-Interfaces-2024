using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Retiro_Interfaces_2024.Models;

namespace Retiro_Interfaces_2024.Controllers
{
    public class GestionaAlumno
    {
        private static GestionaConexion conn = new GestionaConexion();

        public bool VerificarAlumno(string codigoUniversitario)
        {
            using (SqlConnection conn1 = conn.CrearConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_VerificarAlumno", conn1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo_Universitario", codigoUniversitario);

                try
                {
                    conn1.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al verificar alumno: " + ex.Message);
                }
            }
        }

        public bool VerificarContrasena(string codigoUniversitario, string contrasena)
        {
            using (SqlConnection conn1 = conn.CrearConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_VerificarContraseña", conn1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo_Universitario", codigoUniversitario);
                cmd.Parameters.AddWithValue("@Contraseña", contrasena);

                try
                {
                    conn1.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al verificar contraseña: " + ex.Message);
                }
            }
        }

        public AlumnoModel CrearAlumno(string codigoUniversitario)
        {
            PersonaModel persona = GestionaPersona.ObtenerPersonaDeBD(codigoUniversitario);
            FacultadModel facultad = GestionaFacultad.ObtenerFacultadDeBD(codigoUniversitario);
            EscuelaModel escuela = GestionaEscuela.ObtenerEscuelaDeBD(codigoUniversitario, facultad);
            var datosAlumno = ObtenerDatosAlumnoDeBD(codigoUniversitario);

            return new AlumnoModel.Builder()
                .SetCodigoUniversitario(codigoUniversitario)
                .SetCorreoInstitucional(datosAlumno["correoInstitucional"])
                .SetContrasena(datosAlumno["contrasena"])
                .SetEstado(datosAlumno["estado"])
                .SetEscuela(escuela)
                .SetPersona(persona)
                .Build();
        }

        private Dictionary<string, string> ObtenerDatosAlumnoDeBD(string codigoUniversitario)
        {
            using (SqlConnection conn1 = conn.CrearConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerDatosAlumno", conn1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodigoUniversitario", codigoUniversitario);

                conn1.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Dictionary<string, string>
                        {
                            { "correoInstitucional", reader["correoInstitucional"].ToString() },
                            { "contrasena", reader["contraseña"].ToString() },
                            { "estado", reader["estado"].ToString() }
                        };
                    }
                }
            }
            throw new Exception("No se encontraron los datos del alumno.");
        }
        
    }
}