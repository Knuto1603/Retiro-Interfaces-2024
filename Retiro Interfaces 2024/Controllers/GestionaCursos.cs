using Retiro_Interfaces_2024.Models;
using Retiro_Interfaces_2024.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Retiro_Interfaces_2024.Controllers
{
    public class GestionaCursos
    {
        private static GestionaConexion conn = new GestionaConexion();
        static AlumnoModel miAlumno = WebForm2.alumno;
        public static List<CursoModel> ObtenerListaCursos()
        {
            List<CursoModel> listaCursos = new List<CursoModel>();

            using (SqlConnection conn1 = conn.CrearConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_CargarDatosPorCod", conn1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodUniversitario", miAlumno.getCodigoUniversitario());

                try
                {
                    conn1.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        CursoModel curso = new CursoModel(
                            dr.GetString(0),  // Código
                            dr.GetString(1),  // Nombre
                            dr.GetString(2),  // Tipo
                            dr.GetString(3),  // Créditos
                            dr.GetString(4)   // Estado
                        );
                        listaCursos.Add(curso);
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    throw new Exception("Error al obtener la lista de cursos", ex);
                }
            }
            return listaCursos;
        }
    }

}