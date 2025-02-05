using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Retiro_Interfaces_2024.Models
{
    public class InscripcionPorCursosModel
    {
        private AlumnoModel alumno;
        private DateTime dateTime;

        InscripcionPorCursosModel(AlumnoModel alumno, DateTime dateTime)
        {
            this.alumno = alumno;
            this.dateTime = dateTime;    
        }

        public AlumnoModel getAlumno() => alumno;
        public DateTime getDateTime() => dateTime;
    }
}