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

        public bool VerificarAlumno(string codigo)
        {
            bool esValido = false;
            using (SqlConnection conn1 = conn.CrearConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_VerificarAlumno", conn1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo_Universitario", codigo);

                try
                {
                    conn1.Open();
                    int count = (int)cmd.ExecuteScalar();
                    esValido = count > 0;
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                }
            }
            return esValido;
        }

        public bool VerificarContraseña(string codigoUniversitario, string contraseña)
        {
            bool esCorrecta = false;
            using (SqlConnection conn1 = conn.CrearConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_VerificarContraseña", conn1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo_Universitario", codigoUniversitario);
                cmd.Parameters.AddWithValue("@Contraseña", contraseña);

                try
                {
                    conn1.Open();
                    int count = (int)cmd.ExecuteScalar();
                    esCorrecta = count > 0;
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                }
            }
            return esCorrecta;
        }

        public AlumnoModel crearAlumno(string cod)
        {
            PersonaModel persona = ObtenerPersonaDeBD(cod);
            FacultadModel facultad = ObtenerFacultadDeBD(cod);
            EscuelaModel escuela = ObtenerEscuelaDeBD(cod, facultad);
            var datosAlumno = ObtenerDatosAlumnoDeBD(cod);

            return new AlumnoModel.Builder()
                .SetCodigoUniversitario(cod)
                .SetCorreoInstitucional(datosAlumno["correoInstitucional"])
                .SetContrasena(datosAlumno["contraseña"])
                .SetEstado(datosAlumno["estado"])
                .SetEscuela(escuela)
                .SetPersona(persona)
                .Build();
        }

        private PersonaModel ObtenerPersonaDeBD(string cod)
        {
            using (SqlConnection conn1 = conn.CrearConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerPersona", conn1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodigoUniversitario", cod);

                conn1.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new PersonaModel.Builder()
                            .addNombre(reader["Nombre"].ToString())
                            .addApellido(reader["Apellido"].ToString())
                            .addDireccion(reader["Direccion"].ToString())
                            .addLugarNacimiento(reader["Lugar_Nacimiento"].ToString())
                            .addFechaNacimiento(Convert.ToDateTime(reader["Fecha_Nacimiento"]))
                            .addTipoDocIdent(reader["Tipo_Documento_Identidad"].ToString())
                            .addNumeroDoc(reader["Numero_Documento"].ToString())
                            .builder();
                    }
                }
            }
            throw new Exception("No se encontró la persona.");
        }

        private FacultadModel ObtenerFacultadDeBD(string cod)
        {
            using (SqlConnection conn1 = conn.CrearConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerFacultad", conn1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodigoUniversitario", cod);

                conn1.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new FacultadModel(
                            reader["Codigo_Facultad"].ToString(),
                            reader["Nombre"].ToString(),
                            Convert.ToDateTime(reader["Fecha_Creacion"])
                        );
                    }
                }
            }
            throw new Exception("No se encontró la facultad.");
        }

        private EscuelaModel ObtenerEscuelaDeBD(string cod, FacultadModel facultad)
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

        private Dictionary<string, string> ObtenerDatosAlumnoDeBD(string cod)
        {
            using (SqlConnection conn1 = conn.CrearConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerDatosAlumno", conn1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodigoUniversitario", cod);

                conn1.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Dictionary<string, string>
                        {
                            { "correoInstitucional", reader["Correo_Institucional"].ToString() },
                            { "contraseña", reader["Contraseña"].ToString() },
                            { "estado", reader["Estado"].ToString() }
                        };
                    }
                }
            }
            throw new Exception("No se encontraron los datos del alumno.");
        }
    }
}