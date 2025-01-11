using Retiro_Interfaces_2024.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using System.Configuration;

namespace Retiro_Interfaces_2024.Controllers
{
    public static class GestionaSolicitud
    {
        private static GestionaConexion conexion = new GestionaConexion();

        public static SolicitudModel CrearSolicitud()
        {
            return new SolicitudModel();
        }

        public static bool InsertarSolicitud(SolicitudModel solicitud)
        {
            bool insertado = false;
            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@codigo", solicitud.getCodigoSolicitud() },
                    { "@idAlumno", solicitud.getAlumno() },
                    { "@idCurso", solicitud.getIdCurso() },
                    { "@fechaHora", solicitud.getFechaHora() },
                    { "@codigoVoucher", solicitud.getVoucher() },
                    { "@motivo", solicitud.getMotivo() },
                    { "@evidencia", solicitud.getEvidencia() },
                    { "@estado", solicitud.getEstado() }
                };

                insertado = conexion.EjecutarProcedimiento("InsertarSolicitud", parametros) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar la solicitud: {ex.Message}");
            }
            return insertado;
        }

        public static List<SolicitudModel> ListarSolicitudes()
        {
            List<SolicitudModel> lista = new List<SolicitudModel>();
            try
            {
                using (SqlDataReader dr = conexion.ConsultarProcedimiento("ListarSolicitudes"))
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
                Console.WriteLine($"Error al listar las solicitudes: {ex.Message}");
            }
            return lista;
        }
    }
}