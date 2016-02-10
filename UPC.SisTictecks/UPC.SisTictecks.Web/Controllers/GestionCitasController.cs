using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPC.SisTictecks.EL;
using System.ServiceModel;

namespace UPC.SisTictecks.Web.Controllers
{
    public class GestionCitasController : Controller
    {
        private GestionCitasWS.GestionCitasServiceClient GestionCitasProxy = new GestionCitasWS.GestionCitasServiceClient();

        //
        // GET: /GestionCitas/
        public ActionResult Index()
        {
            List<CitaEN> listaCitas;
            listaCitas = GestionCitasProxy.ListarCitas().ToList();
            return View(listaCitas);
        }

        //
        // GET: /GestionCitas/Detalle/5
        public ActionResult Detalle(int id)
        {
            CitaEN cita;
            cita = GestionCitasProxy.ObtenerCita(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        //
        // GET: /GestionCitas/Registrar
        public ActionResult Registrar()
        {
            return View();
        }

        //
        // POST: /GestionCitas/Registrar
        [HttpPost]
        public ActionResult Registrar(CitaEN citaEN, int cboServicio, int cboTaller, int cboUsuario, int cboVehiculo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        citaEN.Servicio = new ServicioEN { Codigo = cboServicio };
                        citaEN.Usuario = new UsuarioEN { Codigo = cboUsuario };
                        citaEN.Vehiculo = new VehiculoEN { Codigo = cboVehiculo };
                        citaEN.Taller = new TallerEN { Codigo = cboTaller };
                        citaEN = GestionCitasProxy.CrearCita(citaEN);
                    }
                    catch (FaultException<RepetidoException> fe)
                    {
                        ModelState.AddModelError("MensajeError", fe.Message + ": " + fe.Detail.Mensaje);
                        return View(citaEN);
                    }

                }
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("MensajeError", "Ocurrió un error al grabar el registro.");
                return View(citaEN);
            }
        }

        //
        // GET: /GestionCitas/Editar/5
        public ActionResult Editar(int id)
        {
            CitaEN citaEN = new CitaEN();
            if (ModelState.IsValid)
            {
                try
                {
                    citaEN = GestionCitasProxy.ObtenerCita(id);
                }
                catch (FaultException<RepetidoException> fe)
                {
                    ModelState.AddModelError("MensajeError", fe.Message + ": " + fe.Detail.Mensaje);
                }
            }
            return View(citaEN);
        }

        //
        // POST: /GestionCitas/Editar/5
        [HttpPost]
        public ActionResult Editar(CitaEN citaEN, int cboServicio, int cboTaller, int cboUsuario, int cboVehiculo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    citaEN.Servicio = new ServicioEN { Codigo = cboServicio };
                    citaEN.Usuario = new UsuarioEN { Codigo = cboUsuario };
                    citaEN.Vehiculo = new VehiculoEN { Codigo = cboVehiculo };
                    citaEN.Taller = new TallerEN { Codigo = cboTaller };
                    GestionCitasProxy.ModificarCita(citaEN);
                }
                catch (FaultException<RepetidoException> fe)
                {
                    ModelState.AddModelError("MensajeError", fe.Message + ": " + fe.Detail.Mensaje);
                    return View(citaEN);
                }
            }

            return RedirectToAction("Index");
        }

        //
        // GET: /GestionCitas/Eliminar/5
        public ActionResult Eliminar(int id)
        {
            try
            {
                GestionCitasProxy.EliminarCita(id);
            }
            catch (FaultException<RepetidoException> fe)
            {
                ModelState.AddModelError("MensajeError", fe.Message + ": " + fe.Detail.Mensaje);
            }
            return RedirectToAction("Index");
        }


        public JsonResult ListaVehiculos()
        {
            VehiculoWS.VehiculoServiceClient _Proxy = new VehiculoWS.VehiculoServiceClient();
            return Json(_Proxy.ListarVehiculos().ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListaServicios()
        {
            ServiciosWS.ServicioServiceClient _proxy = new ServiciosWS.ServicioServiceClient();
            return Json(_proxy.ListarServicios().ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListaTalleres()
        {
            TalleresWS.TallerServiceClient _proxy = new TalleresWS.TallerServiceClient();
            return Json(_proxy.ListarTalleres().ToList(), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}
