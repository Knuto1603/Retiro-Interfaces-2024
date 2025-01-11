using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Retiro_Interfaces_2024.Models
{
    public class EvidenciaModel
    {
        private string url;

        EvidenciaModel(String url)
        {
            this.url = url;
        }
        public String getUrl() => url;
    }
}