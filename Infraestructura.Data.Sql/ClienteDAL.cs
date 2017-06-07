using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Dominio.Entidades;
using System.Data.SqlClient;

namespace Infraestructura.Data.Sql
{
    public class ClienteDAL
    {
        //instanciar para tener acceso a la coneccion
        conexionSQL conecta = new conexionSQL();


        //metodo que retorna la lista de los clientes
        public List<tb_cliente> listadoClientes() {
            List<tb_cliente> lista = new List<tb_cliente>();

            SqlCommand cmd = new SqlCommand("USP_LISTADOCLIENTES",conecta.CN);
            cmd.CommandType = CommandType.StoredProcedure;
            conecta.CN.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read()) {
                tb_cliente reg = new tb_cliente();
                reg.idcliente = dr[0].ToString();
                reg.nombrecia = dr[1].ToString();
                reg.direccion = dr[2].ToString();
                reg.idpais = dr[3].ToString();
                reg.telefono = dr[4].ToString();

                lista.Add(reg);
            }
            dr.Close();
            conecta.CN.Close();
            return lista;
        }

        //Metodo para agregar a un nuevo cliente
        public string AgregarCliente(tb_cliente reg) {

                    string msg = "";
            try {

                SqlCommand cmd = new SqlCommand("USP_AGREGARCLIENTE",conecta.CN);
                conecta.CN.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id",reg.idcliente);
                cmd.Parameters.AddWithValue("@nom", reg.nombrecia);
                cmd.Parameters.AddWithValue("@dir", reg.direccion);
                cmd.Parameters.AddWithValue("@pais", reg.idpais);
                cmd.Parameters.AddWithValue("@tel", reg.telefono);

                cmd.ExecuteNonQuery();
                msg = "Registro Agregado";

            }
            catch (SqlException e) {
                msg = e.Message;
            }
            finally {
                conecta.CN.Close();
            }
            return msg;
        }

        public string ActualizarCliente(tb_cliente reg) {
            string msg = "";
            try {
                SqlCommand cmd = new SqlCommand("USP_ACTUALIZARCLIENTE",conecta.CN);
                cmd.CommandType = CommandType.StoredProcedure;
                conecta.CN.Open();
                cmd.Parameters.AddWithValue("@id",reg.idcliente);
                cmd.Parameters.AddWithValue("@nom", reg.nombrecia);
                cmd.Parameters.AddWithValue("@dir", reg.direccion);
                cmd.Parameters.AddWithValue("@pais", reg.idpais);
                cmd.Parameters.AddWithValue("@tel", reg.telefono);

                cmd.ExecuteNonQuery();
                msg = "Actualizacion Correcta";
            }
            catch (SqlException e) {
                msg = e.Message;
            }
            finally {
                conecta.CN.Close();
            }
            return msg;
        }

        public string EliminarCliente(tb_cliente reg) {

            string msg = "";
            try {

                SqlCommand cmd = new SqlCommand("USP_ELIMINARCLIENTE",conecta.CN);
                cmd.CommandType = CommandType.StoredProcedure;
                conecta.CN.Open();
                cmd.Parameters.AddWithValue("@id",reg.idcliente);

                cmd.ExecuteNonQuery();
                msg = "ELiminacion Correcta";
            }
            catch (SqlException e) {
                msg = e.Message;
            }
            finally {
                conecta.CN.Close();
            }
            return msg;
        }


        public string EliminarCli(string id)
        {

            string msg = "";
            try
            {

                SqlCommand cmd = new SqlCommand("USP_ELIMINARCLIENTE", conecta.CN);
                cmd.CommandType = CommandType.StoredProcedure;
                conecta.CN.Open();
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                msg = "ELiminacion Correcta";
            }
            catch (SqlException e)
            {
                msg = e.Message;
            }
            finally
            {
                conecta.CN.Close();
            }
            return msg;
        }


    }
}
