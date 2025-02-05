using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Retiro_Interfaces_2024.Models
{
    public class MotivoModel
    {
        private string motivo;

        public MotivoModel(String motivo)
        {
            this.motivo= motivo;
        }

        public string getMotivo() => motivo;
    }
}