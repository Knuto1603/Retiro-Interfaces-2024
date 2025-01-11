using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Retiro_Interfaces_2024.Models
{
    public class RevisionSolicitudModel
    {
        private SolicitudModel solicitud;
        private SecretarioAcademicoModel secretarioAcademico;
        private DateTime fechaHora;
        private string estado;
        private string decision;
        private string observaciones;

        RevisionSolicitudModel() { }


        public SolicitudModel getSolitudModel() => solicitud;
        public SecretarioAcademicoModel GetSecretarioAcademico() => secretarioAcademico;
        public DateTime getFechaHora() => fechaHora;
        public string getEstado() => estado;
        public string getDecision() => decision;
        public string getObservaciones() => observaciones;

        public class Builder
        {
            private SolicitudModel _solicitud;
            private SecretarioAcademicoModel _secretarioAcademico;
            private DateTime _fechaHora;
            private string _estado;
            private string _decision;
            private string _observaciones;

            public Builder SetSolicitud(SolicitudModel solicitudB)
            {
                _solicitud = solicitudB;
                return this;
            }

            public Builder SetSecretarioAcademico(SecretarioAcademicoModel secretarioAcademicoB)
            {
                _secretarioAcademico = secretarioAcademicoB;
                return this;
            }

            public Builder SetFechaHora(DateTime fechaHoraB)
            {
                _fechaHora = fechaHoraB;
                return this;
            }

            public Builder SetEstado(string estadoB)
            {
                _estado = estadoB;
                return this;
            }

            public Builder SetDecision(string decisionB)
            {
                _decision = decisionB;
                return this;
            }

            public Builder SetObservaciones(string observacionesB)
            {
                _observaciones = observacionesB;
                return this;
            }


            public RevisionSolicitudModel builder()
            {
                return new RevisionSolicitudModel
                {
                    solicitud = _solicitud,
                    secretarioAcademico = _secretarioAcademico,
                    fechaHora = _fechaHora,
                    estado = _estado,
                    decision = _decision,
                    observaciones = _observaciones
                };
            }
        }


    }
}