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



        public AlumnoModel crearAlumno(string cod)
        {
            DateTime soloFechaEspecifica = new DateTime(2023, 12, 25);
            FacultadModel fac = new FacultadModel("Hola","Industrial", soloFechaEspecifica);
            EscuelaModel esc = new EscuelaModel("051", "informarica", soloFechaEspecifica, fac);
            AlumnoModel alumno = new AlumnoModel.Builder().
                SetCodigoUniversitario(cod).
                SetEscuela(esc).
                Build();


            return alumno;
        }

    }
}
