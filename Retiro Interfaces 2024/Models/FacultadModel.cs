using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Retiro_Interfaces_2024.Models
{
    public class FacultadModel
    {
        private string facultad;
        private string nombre;
        private DateTime fechaCreacion;

        public FacultadModel(
            string facultad,
            string nombre,
            DateTime fechaCreacion)
        {
            this.facultad = facultad;
            this.nombre = nombre;
            this.fechaCreacion = fechaCreacion;
        }
        public string getFacultad() => facultad;
        public String getNombre() => nombre;
        public DateTime getFechaCreacion() => fechaCreacion;
    }
}