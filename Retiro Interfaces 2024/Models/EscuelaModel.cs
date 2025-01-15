using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Retiro_Interfaces_2024.Models
{
    public class EscuelaModel
    {
        private string codigoEscuela;
        private string nombre;
        private DateTime fechaCreacion;
        private FacultadModel facultad;

        public EscuelaModel(
            String codigoEscuela,
            String nombre,
            DateTime fechaCreacion,
            FacultadModel facultad
            ) 
        {
            if (facultad == null)
            {
                throw new ArgumentNullException(nameof(facultad), "La facultad no puede ser nula.");
            }
            this.codigoEscuela = codigoEscuela;
            this.nombre = nombre;
            this.fechaCreacion = fechaCreacion;
            this.facultad = facultad;
        }
        public String getCodigoEscuela() => codigoEscuela;
        public String getNombre() => nombre;
        public DateTime getFechaCreacion() => fechaCreacion;
        public FacultadModel getFacultad() => facultad;

    }
}