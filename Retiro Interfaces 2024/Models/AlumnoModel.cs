using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Retiro_Interfaces_2024.Models
{
    public class AlumnoModel
    {
        private string codigoUniversitario;
        private string correoInstitucional;
        private string contrasena;
        private string estado;
        private EscuelaModel escuela;
        private PersonaModel persona;

        AlumnoModel() { }

        public string getCodigoUniversitario() => codigoUniversitario;
        public string getCreoInstitucional() => correoInstitucional;
        public String getContrasena() => contrasena;
        public String getEstado() => estado;
        public EscuelaModel getEscuela() => escuela;
        public PersonaModel getPersona() => persona;


        public class Builder
        {
            private string _codigoUniversitario;
            private string _correoInstitucional;
            private string _contrasena;
            private string _estado;
            private EscuelaModel _escuela = null;
            private PersonaModel _persona = null;

            public Builder SetCodigoUniversitario(string codigo)
            {
                _codigoUniversitario = codigo;
                return this;
            }

            public Builder SetCorreoInstitucional(string correo)
            {
                _correoInstitucional = correo;
                return this;
            }

            public Builder SetContrasena(string contrasena)
            {
                _contrasena = contrasena;
                return this;
            }

            public Builder SetEstado(string estado)
            {
                _estado = estado;
                return this;
            }

            public Builder SetEscuela(EscuelaModel escuela)
            {
                _escuela = escuela;
                return this;
            }

            public Builder SetPersona(PersonaModel persona)
            {
                _persona = persona;
                return this;
            }

            public AlumnoModel Build()
            {
                return new AlumnoModel
                {
                    codigoUniversitario = _codigoUniversitario,
                    correoInstitucional = _correoInstitucional,
                    contrasena = _contrasena,
                    estado = _estado,
                    escuela = _escuela,
                    persona = _persona
                };
            }
        }
    }
}