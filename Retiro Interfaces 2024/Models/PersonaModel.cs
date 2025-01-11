using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Retiro_Interfaces_2024.Models
{
    public class PersonaModel
    {
        private string nombre;
        private string apellido;
        private string direccion;
        private string lugar_nacimiento;
        private DateTime fechaNacimiento;
        private string tipoDocumentoIdentidad;
        private string numeroDocumento;
        PersonaModel() { }

        public string getNombre() => nombre;
        public string getApellido() => apellido;
        public string getDireccion() => direccion;
        public string getLugarNacimiento() => lugar_nacimiento;
        public DateTime getFechaNacimiento() => fechaNacimiento;
        public string getTipoDocumentoIdentidad() => tipoDocumentoIdentidad;
        public string getNumeroDocumento() => numeroDocumento;


        public class Builder
        {
            private String _nombre;
            private String _apellido;
            private String _direccion;
            private String _lugar_nacimiento;
            private DateTime _fechaNacimiento;
            private String _tipoDocumentoIdentidad;
            private String _numeroDocumento;

            public Builder addNombre(String name)
            {
                _nombre = name;
                return this;
            }
            public Builder addApellido(String lastName)
            {
                _apellido = lastName;
                return this;
            }
            public Builder addDireccion(String Address)
            {
                _direccion = Address;
                return this;
            }
            public Builder addLugarNacimiento(String bornPlace)
            {
                _lugar_nacimiento = bornPlace;
                return this;
            }
            public Builder addFechaNacimiento(DateTime dateTimePerson)
            {
                _fechaNacimiento = dateTimePerson;
                return this;
            }
            public Builder addTipoDocIdent(String TipoDocIdent)
            {
                _tipoDocumentoIdentidad = TipoDocIdent;
                return this;
            }
            public Builder addNumeroDoc(String NumeroDoc)
            {
                _numeroDocumento = NumeroDoc;
                return this;
            }
            public PersonaModel builder()
            {
                return new PersonaModel
                {
                    nombre = _nombre,
                    apellido = _apellido,
                    direccion = _direccion,
                    fechaNacimiento = _fechaNacimiento,
                    lugar_nacimiento = _lugar_nacimiento,
                    tipoDocumentoIdentidad = _tipoDocumentoIdentidad,
                    numeroDocumento = _numeroDocumento
                };
            }
        }
    }
}