using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPC.SisTictecks.EL;
using UPC.SisTictecks.Helpers;
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
            listaCitas = GestionCitasProxy.ListarCitasPendientesDeAtencion(FachadaSesion.Usuario.Codigo.ToString()).ToList();
            return View(listaCitas);
        }

        public ActionResult MisCitas()
        {
            List<CitaEN> listaCitas;
            listaCitas = GestionCitasProxy.ListarCitasPendientesDeAtencion(FachadaSesion.Usuario.Codigo.ToString()).ToList();
            return View(listaCitas);            
        }

        public ActionResult HistorialCitas()
        {
            List<CitaEN> listaHistorialCitas;
            listaHistorialCitas = GestionCitasProxy.ListarHistorialDeCitas(FachadaSesion.Usuario.Codigo.ToString()).ToList();
            return View(listaHistorialCitas);
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
        public ActionResult Registrar(CitaEN citaEN, int cboServicios, int cboTalleres, int cboVehiculos)
        {
            try
            {                                
                if (cboVehiculos == 0)
                {
                    ModelState.AddModelError("MensajeError", "Seleccione Vehículo");
                    return View(citaEN);
                }
                else if (cboServicios == 0 )
                {
                    ModelState.AddModelError("MensajeError", "Seleccione Servicio");
                    return View(citaEN);
                }
                else if (cboTalleres == 0)
                {
                    ModelState.AddModelError("MensajeError", "Seleccione Talleres");
                    return View(citaEN);
                }

                if (ModelState.IsValid)
                {
                    try
                    {                        
                        citaEN.Servicio = new ServicioEN { Codigo = cboServicios };
                        citaEN.Usuario = new UsuarioEN { Codigo = FachadaSesion.Usuario.Codigo };
                        citaEN.Vehiculo = new VehiculoEN { Codigo = cboVehiculos };
                        citaEN.Taller = new TallerEN { Codigo = cboTalleres };

                        int anio = Convert.ToInt32(citaEN.Fecha.Substring(6, 4));
                        int mes = Convert.ToInt32(citaEN.Fecha.Substring(3, 2));
                        int dia = Convert.ToInt32(citaEN.Fecha.Substring(0, 2));
                        citaEN.HoraInicio = new DateTime(anio, mes, dia, citaEN.RangoHora, 0, 0);

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

        public ActionResult CancelarCita(int id)
        {
            //if(estadoCita==(int)eEstadosCita.Cancelado)
            //    ViewBag.Mensaje = "La cita ya se encuentra Cancelada.";

            GestionCitasProxy.DarAltaCita(new CitaEN { Codigo = id, Fecha = DateTime.Now.ToShortDateString() });
            return RedirectToAction("MisCitas"); 
        }

        public ActionResult AprobarCita(int id)
        {
            //if (estadoCita == (int)eEstadosCita.realizado)
            //    ViewBag.Mensaje = "La cita ya se encuentra Aprobada.";

            GestionCitasProxy.DarBajaCita(new CitaEN { Codigo = id });
            return RedirectToAction("MisCitas");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}
