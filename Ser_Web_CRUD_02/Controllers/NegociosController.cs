using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Dominio.Entidades;
using Dominio.Repositorio;
namespace Ser_Web_CRUD_02.Controllers
{
    public class NegociosController : Controller
    {
        ClienteBL cliente = new ClienteBL();
        PaisBL pais = new PaisBL();

        // GET: Negocios

        /***********LISTADO DE CLIENTES****************/
        public ActionResult Index()
        {

            return View( cliente.listadoClientes());
        }


        /*************AGREGAR NUEVO CLIENTE**************/
        public ActionResult AgregarCliente() {

            ViewBag.paises = new SelectList(pais.listadoPais(), "idpais", "nombrepais");

            return View(new tb_cliente());
        }

        [HttpPost]
        public ActionResult AgregarCliente(tb_cliente reg)
        {
            ViewBag.paises = new SelectList(pais.listadoPais(),"idpais","nombrepais",reg.idpais);

            ViewBag.mensaje = cliente.AgregarCliente(reg);

            return View(reg);

        }

        /****************ACTUALIZAR CLIENTE********************/

        public ActionResult ActualizarCliente(string id) {

            var reg = cliente.listadoClientes().Where(x=>x.idcliente==id).FirstOrDefault();

            ViewBag.paises = new SelectList(pais.listadoPais(),"idpais","nombrepais",reg.idpais);


            return View(reg);
            
        }
        [HttpPost]
        public ActionResult ActualizarCliente(tb_cliente reg) {

            ViewBag.paises = new SelectList(pais.listadoPais(),"idpais","nombrepais",reg.idpais);

            ViewBag.mensaje = cliente.ActualizarCliente(reg);
            return View(reg);

        }

        /**************ELIMINAR PASANDO TODO EL REGISTRO***********/
     /*   public ActionResult EliminarCliente(string id) {

            var reg = cliente.listadoClientes().Where(x=>x.idcliente==id).FirstOrDefault();

            ViewBag.mensaje = cliente.EliminarCliente(reg);

            return RedirectToAction("Index");

        }
        */
        /****************ELIMINAR PASANDO EL ID*************/
        public ActionResult EliminarCliente(string id)
        {
            
            ViewBag.mensaje = cliente.EliminarCli(id);

            return RedirectToAction("Index");

        }

        public ActionResult DetalleCliente(string id) {

            if (id == null)
            {
                return RedirectToAction("Index");
            }
            else {

                return View(cliente.listadoClientes().Where(x=>x.idcliente==id).FirstOrDefault());
            }
        }


    }
}