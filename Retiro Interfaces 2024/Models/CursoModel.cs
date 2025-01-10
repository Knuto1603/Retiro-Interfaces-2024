using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Retiro_Interfaces_2024.Models
{
    public class CursoModel
    {
        private string codigo;
        private string nombre;
        private string tipo;
        private string creditos;
        private string estado;

        CursoModel(string codigo, string nombre, string tipo, string creditos, string estado)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.tipo = tipo;
            this.creditos = creditos;
            this.estado = estado;
        }

        public string getCodigo() => codigo;
        public string getNombre() => nombre;
        public string getTipo() => tipo;
        public string getCreditos() => creditos;
        public string getEstado() => estado
    }
}