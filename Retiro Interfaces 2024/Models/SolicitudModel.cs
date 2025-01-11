using System;
using System.Collections.Generic;


namespace Retiro_Interfaces_2024.Models
{
    public class SolicitudModel
    {
        private string codigoSolicitud;
        private AlumnoModel alumno;
        private string idCurso;
        private DateTime fechaHora;
        private VoucherModel voucher;
        private string motivo;
        private List<EvidenciaModel> evidencia;

        public SolicitudModel() { }

        public string getCodigoSolicitud() => codigoSolicitud;
        public AlumnoModel getAlumno() => alumno;
        public string getIdCurso() => idCurso;
        public DateTime getFechaHora() => fechaHora;
        public VoucherModel getVoucher() => voucher;
        public string getMotivo() => motivo;
        public List<EvidenciaModel> getEvidencia() => evidencia;


        public class Builder
        {
            // Campos privados en el Builder
            public string _codigoSolicitud;
            private AlumnoModel _alumno;
            private string _idCurso;
            private DateTime _fechaHora;
            private VoucherModel _voucher;
            private string _motivo;
            private List<EvidenciaModel> _evidencia;

            // Constructor predeterminado para inicializar la lista de evidencia (opcional)
            public Builder()
            {
                _evidencia = new List<EvidenciaModel>();  // Inicializamos la lista de evidencias vacía por defecto
            }

            // Métodos para configurar los valores de los campos
            public Builder SetCodigoSolicitud(string codigo)
            {
                _codigoSolicitud = codigo;
                return this;
            }

            public Builder SetAlumno(AlumnoModel alumno)
            {
                _alumno = alumno;
                return this;
            }

            public Builder SetIdCurso(string idCurso)
            {
                _idCurso = idCurso;
                return this;
            }

            public Builder SetFechaHora(DateTime fechaHora)
            {
                _fechaHora = fechaHora;
                return this;
            }

            public Builder SetVoucher(VoucherModel voucher)
            {
                _voucher = voucher;
                return this;
            }

            public Builder SetMotivo(string motivo)
            {
                _motivo = motivo;
                return this;
            }

            public Builder SetEvidencia(List<EvidenciaModel> evidencia)
            {
                _evidencia = evidencia ?? new List<EvidenciaModel>();  // Si no se pasa una lista, se usa una lista vacía
                return this;
            }

            // Método para construir la instancia final de SolicitudModel
            public SolicitudModel Build()
            {
                return new SolicitudModel
                {
                    codigoSolicitud = _codigoSolicitud,
                    alumno = _alumno,
                    idCurso = _idCurso,
                    fechaHora = _fechaHora,
                    voucher = _voucher,
                    motivo = _motivo,
                    evidencia = _evidencia
                };
            }
        }
    }
}