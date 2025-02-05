using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Retiro_Interfaces_2024.Models
{
    public class ProgramacionAcademicaModel
    {
        private String semestre;

        public ProgramacionAcademicaModel(String semestre) { 
            this.semestre = semestre;
        }

        public String getSemestre() => semestre;
    }
}