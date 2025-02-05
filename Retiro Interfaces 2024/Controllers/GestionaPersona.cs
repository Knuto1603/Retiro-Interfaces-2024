using Retiro_Interfaces_2024.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Retiro_Interfaces_2024.Controllers
{
    public class GestionaPersona
    {
        private static GestionaConexion conn = new GestionaConexion();
        public static PersonaModel ObtenerPersonaDeBD(string cod)
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
    }
}