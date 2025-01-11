using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Retiro_Interfaces_2024.Models;

namespace Retiro_Interfaces_2024.Controllers
{
    public static class GestionaAlumno
    {
        private static GestionaConexion conn;

        public static bool VerificarAlumno(string codigo, string contrasena)
        {
            bool esValido = false;
            try
            {
                conn = new GestionaConexion();
                using (SqlCommand cmd = new SqlCommand("EXEC VerificarAlumno @codigo, @contrasena", con))
                {
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);

                    esValido = (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn?.Close();
            }
            return esValido;
        }

    }
}
