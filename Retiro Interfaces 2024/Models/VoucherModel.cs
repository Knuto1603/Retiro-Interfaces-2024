using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Retiro_Interfaces_2024.Models
{
    public class VoucherModel
    {
        private string codigoVoucher;

        VoucherModel(string codigoVoucher) { 
            this.codigoVoucher = codigoVoucher;
        }
        
        public string getCodigoVoucher() => codigoVoucher;
    }
}