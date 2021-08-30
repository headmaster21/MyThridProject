using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyThridProject.Pages
{
    public class CajeroModel : PageModel
    {

        public bool error { get; set; } = false;
        public String Message { get; set; } = "";

        private float Balance = 28400;
        private float ABC_Balance = 10000;



        private double valor_mil = 0;
        private double valor_quinientos = 0;
        private double valor_cien = 0;
        private double valor_cincuenta = 0;

        public void OnGet(String banco, float monto)
        {

            valor_mil = 0;
            valor_quinientos = 0;
            valor_cien = 0;
            valor_cincuenta = 0;

            if (monto > Balance)
            {
                error = true;
                Message = "Monto solicitado excede el banlance del Cajero.";
                return;
            }

            if (banco == "ABC" & monto > ABC_Balance)
            {
                error = true;
                Message = "Esta Operacion excede el Balance Maximo para el banco ABC.";
                return;
            }

            if (banco == "ABC" & monto > 2000)
            {
                error = true;
                Message = "Monto solicitado excede lo permitido para el Banco ABC.";
                return;
            }


            this.valor_mil = Math.Truncate(monto / 1000);
            this.valor_quinientos = Math.Truncate((monto - (valor_mil * 1000)) / 500);
            this.valor_cien = Math.Truncate((monto - ((valor_mil * 1000) + (valor_quinientos * 500))) / 100);
            this.valor_cincuenta = Math.Truncate((monto - ((valor_mil * 1000) + (valor_quinientos * 500) + (valor_cien * 100))) / 50);

        }

        public double Valor_1000 { get { return this.valor_mil; } }
        public double Valor_500 { get { return this.valor_quinientos; }}

        public double Valor_100 { get { return this.valor_cien;  }  }
        public double Valor_50 { get { return this.valor_cincuenta; } }


    }
}
