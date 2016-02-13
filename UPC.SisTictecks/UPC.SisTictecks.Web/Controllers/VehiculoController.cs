using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using UPC.SisTictecks.EL;

namespace UPC.SisTictecks.Web.Controllers
{
    public class VehiculoController : Controller
    {
        private VehiculoWS.VehiculoServiceClient VehiculoProxy = new VehiculoWS.VehiculoServiceClient();

     
        // GET: /Vehiculo/
        public ActionResult Index()
        {
            var codUsuarioLogueado = FachadaSesion.Usuario.Codigo;
            return View(VehiculoProxy.ListarVehiculosPorUsuario(codUsuarioLogueado.ToString()).ToList());
        }

        //
        // GET: /Vehiculo/Detalles/5
        public ActionResult Detalles(int id)
        {
            VehiculoEN vehiculo;
            vehiculo = VehiculoProxy.ObtenerVehiculo(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        //
        // GET: /Vehiculo/Registrar
        public ActionResult Registrar()
        {
            return View();
        }

        //
        // POST: /Vehiculo/Registrar
        [HttpPost]
        public ActionResult Registrar(VehiculoEN vehiculoEN, string cboMarca,
                    string cboModelo, string cboColor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        if (cboMarca == null || cboMarca == "0")
                        {
                            ModelState.AddModelError("MensajeError", "Seleccione Marca");
                            return View(vehiculoEN);
                        }

                        if (cboModelo == null || cboModelo == "0")
                        {
                            ModelState.AddModelError("MensajeError", "Seleccione Modelo");
                            return View(vehiculoEN);
                        }

                        if (cboColor == null || cboColor == "0")
                        {
                            ModelState.AddModelError("MensajeError", "Seleccione Color");
                            return View(vehiculoEN);
                        }

                        vehiculoEN.Marca = new MarcaEN { Codigo = Convert.ToInt32(cboMarca)};
                        vehiculoEN.Modelo = new ModeloEN { Codigo = Convert.ToInt32(cboModelo) };
                        vehiculoEN.Color = new ColorEN { Codigo = Convert.ToInt32(cboColor) };
                        vehiculoEN.Usuario = new UsuarioEN { Codigo = FachadaSesion.Usuario.Codigo };
                        vehiculoEN = VehiculoProxy.CrearVehiculo(vehiculoEN);
                    }
                    catch (FaultException<RepetidoException> fe)
                    {
                        ModelState.AddModelError("MensajeError", fe.Message + ": " + fe.Detail.Mensaje);
                        return View(vehiculoEN);
                    }

                }
                //return RedirectToAction("Index");
                return RedirectToAction("Registrar", "GestionCitas");
            }
            catch
            {
                ModelState.AddModelError("MensajeError", "Ocurrió un error al grabar el registro.");
                return View(vehiculoEN);
            }
        }

        //
        // GET: /Vehiculo/Editar/5
        public ActionResult Editar(int id)
        {
            VehiculoEN vehiculoEN = new VehiculoEN();
            if (ModelState.IsValid)
            {
                try
                {
                    vehiculoEN = VehiculoProxy.ObtenerVehiculo(id);
                }
                catch (FaultException<RepetidoException> fe)
                {
                    ModelState.AddModelError("MensajeError", fe.Message + ": " + fe.Detail.Mensaje);
                }
            }
            return View(vehiculoEN);
        }

        //
        // POST: /Vehiculo/Editar/5
        [HttpPost]
        public ActionResult Editar(VehiculoEN vehiculoEN, string cboMarca,
                    string cboModelo, string cboColor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (cboMarca == null || cboMarca == "0")
                    {
                        ModelState.AddModelError("MensajeError", "Seleccione Marca");
                        return View(vehiculoEN);
                    }

                    if (cboModelo == null || cboModelo == "0")
                    {
                        ModelState.AddModelError("MensajeError", "Seleccione Modelo");
                        return View(vehiculoEN);
                    }

                    if (cboColor == null || cboColor == "0")
                    {
                        ModelState.AddModelError("MensajeError", "Seleccione Color");
                        return View(vehiculoEN);
                    }

                    vehiculoEN.Marca = new MarcaEN { Codigo = Convert.ToInt32(cboMarca) };
                    vehiculoEN.Modelo = new ModeloEN { Codigo = Convert.ToInt32(cboModelo) };
                    vehiculoEN.Color = new ColorEN { Codigo = Convert.ToInt32(cboColor) };
                    vehiculoEN.Usuario = new UsuarioEN { Codigo = FachadaSesion.Usuario.Codigo };
                    VehiculoProxy.ModificarVehiculo(vehiculoEN);
                }
                catch (FaultException<RepetidoException> fe)
                {
                    ModelState.AddModelError("MensajeError", fe.Message + ": " + fe.Detail.Mensaje);
                    return View(vehiculoEN);
                }
            }

            return RedirectToAction("Index");
        }

        //
        // GET: /Vehiculo/Eliminar/5
        public ActionResult Eliminar(int id)
        {
            try
            {
                VehiculoProxy.EliminarVehiculo(id);
            }
            catch (FaultException<RepetidoException> fe)
            {
                ModelState.AddModelError("MensajeError", fe.Message + ": " + fe.Detail.Mensaje);
            }

            return RedirectToAction("Index");
        }

        public JsonResult ListaMarcas()
        {
            return Json(VehiculoProxy.ListarMarcas().ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListaModelos(string codigoMarca)
        {
            MarcaEN marca = new MarcaEN() { Codigo = Convert.ToInt32(codigoMarca) };
            return Json(VehiculoProxy.ListarModelosXMarca(marca).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListaColores()
        {
            return Json(VehiculoProxy.ListarColores().ToList(), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}
