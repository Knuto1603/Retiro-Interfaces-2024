using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Retiro_Interfaces_2024.Models
{
    public class DocenteModel
    {
        private string correoInstitucional;
        private DateTime fechaIngreso;
        private PersonaModel persona;

        DocenteModel(string correoInstitucional, DateTime fechaIngreso, PersonaModel persona)
        {
            this.correoInstitucional = correoInstitucional;
            this.fechaIngreso = fechaIngreso;
            this.persona = persona;
        }

        public string getCorreoInstitucional() => correoInstitucional;
        public DateTime getFechaIngreso() => fechaIngreso;
        public PersonaModel getPersona() => persona;
    }
}