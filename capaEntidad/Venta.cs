using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidad
{
    public class Venta
    {
        /* IdVenta IdCliente   TotalProducto MontoTotal  Contacto IdPais  IdTransccion FechaVenta*/
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public int TotalProducto { get; set; }
        public decimal MontoTotal { get; set; }
        public string Contacto { get; set; }
        public int IdPais { get; set; }
        public string IdTransaccion { get; set; }
        public string FechaVenta { get; set; }

        public List<DetalleVenta> oDetalleVenta { get; set; }

    }
}
