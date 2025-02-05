using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Retiro_Interfaces_2024.Models
{
    public class DetalleProgramacionModel
    {
        private ProgramacionAcademicaModel programacionAcademica;
        private CursoModel curso;
        private string clave;
        private string grupo;
        private string seccion;
        private DocenteModel docente;
        private string aula;
        private string capacidad;

        public DetalleProgramacionModel(
            ProgramacionAcademicaModel programacionAcademica,
            CursoModel curso,
            string clave,
            string grupo,
            string seccion,
            DocenteModel docente,
            string aula,
            string capacidad)
        {
            this.programacionAcademica = programacionAcademica;
            this.curso = curso;
            this.clave = clave;
            this.grupo = grupo;
            this.seccion = seccion;
            this.docente = docente;
            this.aula = aula;
            this.capacidad = capacidad;
        }

        public ProgramacionAcademicaModel getProgramacionAcademica() => programacionAcademica;
        public CursoModel getCurso() => curso;
        public string getClave() => clave;
        public string getGrupo() => grupo;
        public string getSeccion() => seccion;
        public DocenteModel getDocente() => docente;
        public string getAula() => aula;
        public string getCapacidad() => capacidad;

    }
}
