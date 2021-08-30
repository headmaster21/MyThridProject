using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyThridProject.Pages
{
    public class CanculadoraModel : PageModel
    {
        Prestamo prestamo = new Prestamo();

        public void OnGet(float monto, float interes, int plazo)
        {
            this.prestamo.Monto = monto;
            this.prestamo.Ineres = interes;
            this.prestamo.Plazo = plazo;
        }
        public Prestamo Prestamos => this.prestamo;
    }

    public class Prestamo
    {
        public double Monto { get; set; }
        public int Plazo { get; set; }
        public double Ineres { get; set; }

        public double CoutasFijas()
        {
            float taza_interes = (float)Ineres / 100 / 12;
            float pago = taza_interes + 1;
            pago = (float)Math.Pow(pago, Plazo);
            pago = pago - 1;

            pago = taza_interes / pago;
            pago = taza_interes + pago;
            pago = (float)Monto * pago;


            return (pago >= 0) ? pago : 0;
        }
    }
}
