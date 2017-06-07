using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio.Entidades;
using Infraestructura.Data.Sql;

namespace Dominio.Repositorio
{
    public class PaisBL
    {
        public List<tb_paises> listadoPais() {
            PaisDAL pais = new PaisDAL();
            return pais.listadoPais();

        }


    }
}
