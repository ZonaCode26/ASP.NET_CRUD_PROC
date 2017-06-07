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
    public class ClienteBL
    {
        ClienteDAL cliente = new ClienteDAL();

        public List<tb_cliente> listadoClientes()
        {

            return cliente.listadoClientes();
        }

        public string AgregarCliente(tb_cliente reg)
        {
            return cliente.AgregarCliente(reg);

        }

        public string ActualizarCliente(tb_cliente reg)
        {
            return cliente.ActualizarCliente(reg);

        }


        public string EliminarCliente(tb_cliente reg)
        {
            return cliente.EliminarCliente(reg);
        }

        public string EliminarCli(string id)
        {
            return cliente.EliminarCli(id);
        }




        }

    }
