using Retiro_Interfaces_2024.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Retiro_Interfaces_2024.Controllers
public static class GestionaSolicitud
{
    private static SqlConnection con;

    public static SolicitudModel CrearSolicitud()
    {
        return new SolicitudModel();
    }

    public static SolicitudModel ObtenerSolicitudConDatos(SolicitudModel solicitudDesdeVista)
    {
        return solicitudDesdeVista;
    }

    public static bool InsertarSolicitud(SolicitudModel solicitud)
    {
        bool insertado = false;
        try
        {
            con = GestionaDatos.conectar();
            using (SqlCommand cmd = new SqlCommand("EXEC InsertarSolicitud @codigo, @idAlumno, @idCurso, @fechaHora, @codigoVoucher, @motivo, @estado", con))
            {
                cmd.Parameters.AddWithValue("@codigo", solicitud.CodigoSolicitud);
                cmd.Parameters.AddWithValue("@idAlumno", solicitud.IDAlumno);
                cmd.Parameters.AddWithValue("@idCurso", solicitud.IDCurso);
                cmd.Parameters.AddWithValue("@fechaHora", solicitud.FechaHora);
                cmd.Parameters.AddWithValue("@codigoVoucher", solicitud.CodigoVoucher);
                cmd.Parameters.AddWithValue("@motivo", solicitud.Motivo);
                cmd.Parameters.AddWithValue("@estado", solicitud.Estado);

                insertado = cmd.ExecuteNonQuery() > 0;
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
        return insertado;
    }

    public static List<SolicitudModel> ListarSolicitudes()
    {
        List<SolicitudModel> lista = new List<SolicitudModel>();
        try
        {
            con = GestionaDatos.conectar();
            using (SqlCommand cmd = new SqlCommand("EXEC ListarSolicitudes", con))
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    SolicitudModel solicitud = new SolicitudModel
                    {
                        CodigoSolicitud = dr["CodigoSolicitud"].ToString(),
                        IDAlumno = dr["IDAlumno"].ToString(),
                        IDCurso = dr["IDCurso"].ToString(),
                        FechaHora = DateTime.Parse(dr["FechaHora"].ToString()),
                        CodigoVoucher = dr["CodigoVoucher"].ToString(),
                        Motivo = dr["Motivo"].ToString(),
                        Estado = dr["Estado"].ToString()
                    };
                    lista.Add(solicitud);
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