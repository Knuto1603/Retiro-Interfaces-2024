using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Retiro_Interfaces_2024.Models
{
    public class LoginF
    {
        public int Id { get; set; }
        public string LoginName { get; set; } = string.Empty;
        public string LoginPassword { get; set; } = string.Empty;

        string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

        public LoginF(string codUniversitario, string contraseña)
        {
            this.codUniversitario = codUniversitario;
            this.contraseña = contraseña;
        }

        public string codUniversitario { get; set; }
        public string contraseña { get; set; }

        public bool validar()
        {
            bool codValido = buscarUsuario(codUniversitario);
            bool passValido = VerificarContraseña(codUniversitario, contraseña);

            if (codValido && passValido)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool VerUsuario()
        {
            return buscarUsuario(codUniversitario);
        }

        private bool buscarUsuario(string codigoUniversitario)
        {
            bool existe = false;
            string query = "SELECT COUNT(*) FROM Alumno WHERE Codigo_Universitario = @Codigo_Universitario";
            SqlConnection conn = new SqlConnection(connectionString);

            using (conn)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Codigo_Universitario", codigoUniversitario);

                try
                {
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar(); // Devuelve el número de coincidencias
                    existe = count > 0;
                }
                catch (Exception ex)
                {
                    //lblMensaje.Text = "Error en la conexión a la base de datos: " + ex.Message;
                }
            }

            return existe;
        }

        // Método para verificar si la contraseña es correcta para el código universitario
        private bool VerificarContraseña(string codigoUniversitario, string contraseña)
        {
            bool esCorrecta = false;
            string query = "SELECT COUNT(*) FROM Alumno WHERE Codigo_Universitario = @Codigo_Universitario AND Contraseña = @Contraseña";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Codigo_Universitario", codigoUniversitario);
                cmd.Parameters.AddWithValue("@Contraseña", contraseña);

                try
                {
                    conn.Open();
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


    }
}