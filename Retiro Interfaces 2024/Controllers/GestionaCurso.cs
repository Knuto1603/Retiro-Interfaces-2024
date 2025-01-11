using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Retiro_Interfaces_2024.Models;

namespace Retiro_Interfaces_2024.Controllers

public static class GestionaCurso
{
    private static SqlConnection con;

    public static List<CursoModel> ListarCursos()
    {
        List<CursoModel> lista = new List<CursoModel>();
        try
        {
            con = GestionaDatos.conectar();
            using (SqlCommand cmd = new SqlCommand("EXEC ListarCursosActivos", con))
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    CursoModel curso = new CursoModel(
                        dr["Codigo"].ToString(),
                        dr["Nombre"].ToString(),
                        dr["Tipo"].ToString(),
                        dr["Creditos"].ToString(),
                        dr["Estado"].ToString()
                    );
                    lista.Add(curso);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con?.Close();
        }
        return lista;
    }
}