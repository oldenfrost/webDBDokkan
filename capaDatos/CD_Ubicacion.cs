using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using capaEntidad;
using System.Globalization;
namespace capaDatos
{
    public class CD_Ubicacion
    {
        public List<Pais> ObtenerPais()
        {
            List<Pais> lista = new List<Pais>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {


                    string query = "select *from PAIS";



                    SqlCommand cmd = new SqlCommand(query, oconexion);
         
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Pais()
                            {
                                IdPais = Convert.ToInt32(dr["IdPais"]),
                                Dominio = dr["Dominio"].ToString(),
                            }
                

                            );
                        }
                    }



                }
            }
            catch
            {
                lista = new List<Pais>();
            }


            return lista;
        }

    }
}
