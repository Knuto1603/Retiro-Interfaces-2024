using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Retiro_Interfaces_2024.Models
{
    public class DetalleInscripcionModel
    {
        private CursoModel curso;
        private DocenteModel docente;
        private string grupo;
        private string seccion;
        private string aula;
        private InscripcionPorCursosModel InscripcionPorCursos;

        DetalleInscripcionModel() { }

        public CursoModel getCursoModel() => curso;
        public DocenteModel getDocenteModel() => docente;
        public string getGrupo() => grupo;
        public string getSeccion() => seccion;
        public string getAula() => aula;
        public InscripcionPorCursosModel GetInscripcionPorCursosModel() => InscripcionPorCursos;

        public class Build
        {
            private CursoModel _curso;
            private DocenteModel _docente;
            private string _grupo;
            private string _seccion;
            private string _aula;
            private InscripcionPorCursosModel _inscripcionPorCursos;

            public Build SetCurso(CursoModel cursoB)
            {
                _curso = cursoB;
                return this;
            }

            public Build SetDocente(DocenteModel docenteB)
            {
                _docente = docenteB;
                return this;
            }

            public Build SetGrupo(string grupoB)
            {
                _grupo = grupoB;
                return this;
            }

            public Build SetSeccion(string seccionB)
            {
                _seccion = seccionB;
                return this;
            }

            public Build SetAula(string aulaB)
            {
                _aula = aulaB;
                return this;
            }

            public Build SetInscripcionPorCursos(InscripcionPorCursosModel inscripcionPorCursosB)
            {
                _inscripcionPorCursos = inscripcionPorCursosB;
                return this;
            }

            public DetalleInscripcionModel build()
            {
                return new DetalleInscripcionModel
                {
                    curso = _curso,
                    docente = _docente,
                    grupo = _grupo,
                    seccion = _seccion,
                    aula = _aula,
                    InscripcionPorCursos = _inscripcionPorCursos
                };
            }
        }

    }
}