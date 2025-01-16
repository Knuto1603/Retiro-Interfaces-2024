using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.WebSockets;
using Retiro_Interfaces_2024.Models;

namespace Retiro_Interfaces_2024.Controllers
{
    public class GestionaAlumno
    {


        private static GestionaConexion conn = new GestionaConexion();

        public bool VerificarAlumno(string codigo)
        {
            bool esValido = false;
            string query = "SELECT COUNT(*) FROM Alumno WHERE Codigo_Universitario = @Codigo_Universitario" ;

            using (SqlConnection conn1 = conn.CrearConexion())
            {
                SqlCommand cmd = new SqlCommand(query, conn1);
                cmd.Parameters.AddWithValue("@Codigo_Universitario", codigo);

                try
                {
                    conn1.Open();
                    int count = (int)cmd.ExecuteScalar(); // Devuelve el número de coincidencias
                    esValido = count > 0;
                }
                catch (Exception ex)
                {
                    //lblMensaje.Text = "Error en la conexión a la base de datos: " + ex.Message;
                }
            }
            return esValido;
        }

        public bool VerificarContraseña(string codigoUniversitario, string contraseña)
        {
            bool esCorrecta = false;
            string query = "SELECT COUNT(*) FROM Alumno WHERE Codigo_Universitario = @Codigo_Universitario AND Contraseña = @Contraseña";

            using (SqlConnection conn1 = conn.CrearConexion())
            {
                SqlCommand cmd = new SqlCommand(query, conn1);
                cmd.Parameters.AddWithValue("@Codigo_Universitario", codigoUniversitario);
                cmd.Parameters.AddWithValue("@Contraseña", contraseña);

                try
                {
                    conn1.Open();
                    int count = (int)cmd.ExecuteScalar(); // Devuelve el número de coincidencias
                    esCorrecta = count > 0;
                }
                catch (Exception ex)
                {
                    //lblMensaje.Text = "Error en la conexión a la base de datos: " + ex.Message;
                }
            }

            return esCorrecta;
        }



        /*public AlumnoModel crearAlumno(string cod)
        {
            //USAR CODIGO PARA EL PA
            DateTime soloFechaEspecifica = new DateTime(2023, 12, 25);
            FacultadModel fac = new FacultadModel("Hola","Industrial", soloFechaEspecifica);
            EscuelaModel esc = new EscuelaModel("051", "informarica", soloFechaEspecifica, fac);
            AlumnoModel alumno = new AlumnoModel.Builder().
                SetCodigoUniversitario(cod).
                SetEscuela(esc).
                Build();


            return alumno;
        }*/

        public AlumnoModel crearAlumno(string cod)
        {
            // Crear los objetos a partir de la base de datos.
            PersonaModel persona = ObtenerPersonaDeBD(cod);
            FacultadModel facultad = ObtenerFacultadDeBD(cod);
            EscuelaModel escuela = ObtenerEscuelaDeBD(cod, facultad);
            var datosAlumno = ObtenerDatosAlumnoDeBD(cod);

            // Crear el objeto AlumnoModel utilizando el patrón Builder.
            AlumnoModel alumno = new AlumnoModel.Builder()
                .SetCodigoUniversitario(cod)
                .SetCorreoInstitucional(datosAlumno["correoInstitucional"])
                .SetContrasena(datosAlumno["contraseña"])
                .SetEstado(datosAlumno["estado"])
                .SetEscuela(escuela)
                .SetPersona(persona)
                .Build();

            return alumno;
        }

        private PersonaModel ObtenerPersonaDeBD(string cod)
        {
            string query = @"
            SELECT p.Nombre, p.Apellido, p.Direccion, p.Lugar_Nacimiento, p.Fecha_Nacimiento, 
                   p.Tipo_Documento_Identidad, p.Numero_Documento
            FROM Persona p
            INNER JOIN Alumno a ON p.ID_Persona = a.ID_Persona
            WHERE a.Codigo_Universitario = @CodigoUniversitario";

            using (SqlConnection conn1 = conn.CrearConexion())
            {
                SqlCommand cmd = new SqlCommand(query, conn1);
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
            string query = @"
            SELECT f.Codigo_Facultad, f.Nombre, f.Fecha_Creacion
            FROM Facultad f
            INNER JOIN Escuela e ON f.ID_Facultad = e.ID_Facultad
            INNER JOIN Alumno a ON e.ID_Escuela = a.ID_Escuela
            WHERE a.Codigo_Universitario = @CodigoUniversitario";

            using (SqlConnection conn1 = conn.CrearConexion())
            {
                SqlCommand cmd = new SqlCommand(query, conn1);
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
            string query = @"
            SELECT e.Codigo_Escuela, e.Nombre, e.Fecha_Creacion
            FROM Escuela e
            INNER JOIN Alumno a ON e.ID_Escuela = a.ID_Escuela
            WHERE a.Codigo_Universitario = @CodigoUniversitario";

            using (SqlConnection conn1 = conn.CrearConexion())
            {
                SqlCommand cmd = new SqlCommand(query, conn1);
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
            string query = @"
            SELECT a.Correo_Institucional, a.Contraseña, a.Estado
            FROM Alumno a
            WHERE a.Codigo_Universitario = @CodigoUniversitario";

            using (SqlConnection conn1 = conn.CrearConexion())
            {
                SqlCommand cmd = new SqlCommand(query, conn1);
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
