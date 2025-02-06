using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Retiro_Interfaces_2024.Models
{
    public class CursoRetiroModel
    {
        private string codigo;
        private string nombre;
        private string creditos;
        private string docente;

        public CursoRetiroModel(string codigo, string nombre, string creditos, string docente)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.creditos = creditos;
            this.docente = docente;
        }

        public string GetCodigo() => codigo;
        public string GetNombre() => nombre;
        public string GetCreditos() => creditos;
        public string GetDocente() => docente;
    }
}