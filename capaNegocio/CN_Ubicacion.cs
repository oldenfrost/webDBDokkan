using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using capaEntidad;
using System.Globalization;
using System.Runtime.CompilerServices;
using capaDatos;

namespace capaNegocio
{
    public class CN_Ubicacion
    {
       private CD_Ubicacion objCapaDato= new CD_Ubicacion();
        public List<Pais> ObtenerPais()
        {
            return objCapaDato.ObtenerPais();
        }
    }
}
