using System;
using System.Collections.Generic;


namespace Retiro_Interfaces_2024.Models
{
    public class SolicitudModel
    {
        private string codigoSolicitud;
        private DetalleInscripcionModel detalleInscripcion;
        private DateTime fechaHora;
        private string estado;
        private VoucherModel voucher;
        private MotivoModel motivo;
        private string detalleMotivo;
        private List<EvidenciaModel> evidencia;

        public SolicitudModel(
            string codigoSolicitud,
            DetalleInscripcionModel detalleInscripcion,
            DateTime fechaHora,
            string estado,
            VoucherModel voucher,
            MotivoModel motivo,
            string detalleMotivo,
            List<EvidenciaModel> evidencia)
        {
            this.codigoSolicitud = codigoSolicitud;
            this.detalleInscripcion = detalleInscripcion;
            this.fechaHora = fechaHora;
            this.estado = estado;
            this.voucher = voucher;
            this.motivo = motivo;
            this.detalleMotivo = detalleMotivo;
            this.evidencia = evidencia;
        }
        public string getCodigoSolicitud() => codigoSolicitud;
        public DetalleInscripcionModel getDetalleInscripcion() => detalleInscripcion;
        public DateTime getFechaHora() => fechaHora;
        public string getEstado() => estado;
        public VoucherModel getVoucher() => voucher;
        public MotivoModel getMotivo() => motivo;
        public string getDetalleMotivo() => detalleMotivo;
        public List<EvidenciaModel> getEvidencia() => evidencia;

    }
}