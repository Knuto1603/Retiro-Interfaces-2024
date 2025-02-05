using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Retiro_Interfaces_2024.Models
{
    public class DetalleInscripcionModel
    {

        private InscripcionPorCursosModel InscripcionPorCursos;
        private DetalleProgramacionModel detalleProgramacion;
        private string numInscripcion;
        private string observacion;
        private DateTime dateTime;

        public DetalleInscripcionModel(
            InscripcionPorCursosModel InscripcionPorCursos,
            DetalleProgramacionModel detalleProgramacion,
            string numInscripcion,
            string observacion,
            DateTime dateTime)
        {
            this.InscripcionPorCursos = InscripcionPorCursos;
            this.detalleProgramacion = detalleProgramacion;
            this.numInscripcion = numInscripcion;
            this.observacion = observacion;
            this.dateTime = dateTime;
        }

        public InscripcionPorCursosModel getInscripcionPorCursos() => InscripcionPorCursos;
        public DetalleProgramacionModel getDetalleProgramacion() => detalleProgramacion;
        public string getNumInscripcion() => numInscripcion;
        public string getObservacion() => observacion;
        public DateTime getDateTime() => dateTime;

    }
}