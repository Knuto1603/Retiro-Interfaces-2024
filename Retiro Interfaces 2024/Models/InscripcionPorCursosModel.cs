using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Retiro_Interfaces_2024.Models
{
    public class InscripcionPorCursosModel
    {
        private string semestre;
        private DateTime fecha;
        private AlumnoModel alumno;
        private string estado;

        InscripcionPorCursosModel(string semestre, DateTime fecha, AlumnoModel alumno, string estado)
        {
            this.semestre = semestre;
            this.fecha = fecha;
            this.alumno = alumno;
            this.estado = estado;
        }

        public string getSemestre() => semestre;
        public DateTime getFecha() => fecha;
        public AlumnoModel getAlumno() => alumno;
        public string getEstado() => estado;
    }
}