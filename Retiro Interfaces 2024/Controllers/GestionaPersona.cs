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
        public static PersonaModel ObtenerPersonaDeBD(string codigoUniversitario)
        {
            using (SqlConnection conn1 = conn.CrearConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerPersona", conn1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodigoUniversitario", codigoUniversitario);

                conn1.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new PersonaModel.Builder()
                            .addNombre(reader["nombre"].ToString())
                            .addApellido(reader["apellido"].ToString())
                            .addDireccion(reader["direccion"].ToString())
                            .addLugarNacimiento(reader["lugarNacimiento"].ToString())
                            .addFechaNacimiento(Convert.ToDateTime(reader["fechaNacimiento"]))
                            .addTipoDocIdent(reader["tipoDocumento"].ToString())
                            .addNumeroDoc(reader["numeroDocumento"].ToString())
                            .builder();
                    }
                }
            }
            throw new Exception("No se encontró la persona.");
        }
    }
}