using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio.Entidades;


namespace Infraestructura.Data.Sql
{
    public class PaisDAL
    {
        conexionSQL conecta = new conexionSQL();


        public List<tb_paises> listadoPais() {
            List<tb_paises> lista = new List<tb_paises>();

            SqlCommand cmd = new SqlCommand("USP_LISTADOPAIS", conecta.CN);
            conecta.CN.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read()) {
                tb_paises reg = new tb_paises();

                reg.idpais = dr[0].ToString();
                reg.nombrepais = dr[1].ToString();

                lista.Add(reg);
                
            }

            conecta.CN.Close();
            dr.Close();
            
            return lista;
        }


    }
}
