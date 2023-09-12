using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidad
{
    public  class Reporte

        //FechaVenta Cliente Producto Precio  Cantidad Total   IdTransaccion
    {
        public string FechaRegistro { get; set; }
        public string Usuario { get; set; }
        public string Cliente { get; set; }
        public string Producto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public string IdTransaccion { get; set; }

    }
}
