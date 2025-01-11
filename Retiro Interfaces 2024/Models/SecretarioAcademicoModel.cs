using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Retiro_Interfaces_2024.Models
{
    public class SecretarioAcademicoModel
    {
        private DateTime fechaIngreso;
        private string correoInstitucional;
        private PersonaModel persona;

        SecretarioAcademicoModel(
            DateTime fechaIngreso,
            string correoInstitucional,
            PersonaModel persona)
        {
            this.fechaIngreso = fechaIngreso;
            this.correoInstitucional = correoInstitucional;
            this.persona = persona;
        }

        public DateTime getFechaIngreso() => fechaIngreso;
        public string getCorreoInstitucional() => correoInstitucional;
        public PersonaModel getPersona() => persona;
    }
}
}