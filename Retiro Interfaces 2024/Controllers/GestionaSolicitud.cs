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

    public static bool InsertarSolicitud(SolicitudModel solicitud)
    {
        bool insertado = false;
        try
        {
            con = GestionaDatos.conectar();
            using (SqlCommand cmd = new SqlCommand("EXEC InsertarSolicitud @codigo, @idAlumno, @idCurso, @fechaHora, @codigoVoucher, @motivo, @estado", con))
            {
                cmd.Parameters.AddWithValue("@codigo", solicitud.getCodigoSolicitud());
                cmd.Parameters.AddWithValue("@idAlumno", solicitud.getAlumno());
                cmd.Parameters.AddWithValue("@idCurso", solicitud.getIdCurso());
                cmd.Parameters.AddWithValue("@fechaHora", solicitud.getFechaHora());
                cmd.Parameters.AddWithValue("@codigoVoucher", solicitud.getVoucher());
                cmd.Parameters.AddWithValue("@motivo", solicitud.getMotivo());
                cmd.Parameters.AddWithValue("@evidencia", solicitud.getEvidencia());

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
                    /* SolicitudModel solicitud = new SolicitudModel
                     {
                         CodigoSolicitud = dr["CodigoSolicitud"].ToString(),
                         IDAlumno = dr["IDAlumno"].ToString(),
                         IDCurso = dr["IDCurso"].ToString(),
                         FechaHora = DateTime.Parse(dr["FechaHora"].ToString()),
                         CodigoVoucher = dr["CodigoVoucher"].ToString(),
                         Motivo = dr["Motivo"].ToString(),
                         Estado = dr["Estado"].ToString()  
                     };*/
                    SolicitudModel solicitud = new SolicitudModel.Builder().
                        SetCodigoSolicitud(dr["CodigoSolicitud"].ToString()).
                        SetIdCurso(dr["IDCurso"].ToString()).
                        SetMotivo(dr["Motivo"].ToString()).
                        SetAlumno(dr["IDAlumno"].ToString()).
                        SetFechaHora(DateTime.Parse(dr["FechaHora"].ToString())).
                        SetVoucher(dr["CodigoVoucher"].ToString()).
                        SetMotivo().
                        SetEvidencia().
                        build();
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