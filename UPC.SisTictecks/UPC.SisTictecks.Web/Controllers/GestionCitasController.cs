using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPC.SisTictecks.EL;
using UPC.SisTictecks.Helpers;
using System.ServiceModel;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Text;
using System.Runtime.Serialization.Json;

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
            GestionCitasProxy.DarAltaCita(new CitaEN { Codigo = id, Fecha = DateTime.Now.ToShortDateString() });
            return RedirectToAction("MisCitas"); 
        }


        public ActionResult ListaCitasEnAlta()
        {
            HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost:28603/AtencionCitaService.svc/AltasCita");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string citasJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            List<CitaEN> listaCitasAltas = js2.Deserialize<List<CitaEN>>(citasJson2);
            return View(listaCitasAltas);
        }

        public ActionResult DarAltaCita(int id)
        {
            CitaEN citaEN = null;
            if (ModelState.IsValid)
            {
                HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost:28603/AtencionCitaService.svc/AltasCita/" + id.ToString());
                req2.Method = "GET";
                HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
                StreamReader reader2 = new StreamReader(res2.GetResponseStream());
                string citasJson2 = reader2.ReadToEnd();
                JavaScriptSerializer js2 = new JavaScriptSerializer();
                citaEN = js2.Deserialize<CitaEN>(citasJson2);
                citaEN.RangoHora = 1;
            }
            return View(citaEN);
        }

        [HttpPost]
        public ActionResult DarAltaCita(CitaEN citaEN)
        {
            if (ModelState.IsValid)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string postdata = serializer.Serialize(citaEN);;
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest req = (HttpWebRequest)WebRequest
                    .Create("http://localhost:28603/AtencionCitaService.svc/AltasCita");
                req.Method = "POST";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";
                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                HttpWebResponse res = null;
                try
                {
                    res = (HttpWebResponse)req.GetResponse();
                    StreamReader reader = new StreamReader(res.GetResponseStream());
                    string citaAltaJson = reader.ReadToEnd();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    CitaEN citaEnAlta = js.Deserialize<CitaEN>(citaAltaJson);
                }
                catch (WebException e)
                {
                    HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                    string message = ((HttpWebResponse)e.Response).StatusDescription;
                    StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                    string error = reader.ReadToEnd();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string mensaje = js.Deserialize<string>(error);

                    ModelState.AddModelError("MensajeError", mensaje);
                    return View(citaEN);
                }
            }
            //return View(citaEN);
            return RedirectToAction("ListaCitasEnAlta");
        }

        public ActionResult DarBajaCita(int id)
        {
            if (ModelState.IsValid)
            {
                CitaEN citaEN = new CitaEN() { Codigo = id};
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string postdata = serializer.Serialize(citaEN); ;
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest req = (HttpWebRequest)WebRequest
                    .Create("http://localhost:28603/AtencionCitaService.svc/BajasCita");
                req.Method = "POST";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";
                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                HttpWebResponse res = null;
                try
                {
                    res = (HttpWebResponse)req.GetResponse();
                    StreamReader reader = new StreamReader(res.GetResponseStream());
                    string citaAltaJson = reader.ReadToEnd();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    CitaEN citaEnAlta = js.Deserialize<CitaEN>(citaAltaJson);
                }
                catch (WebException e)
                {
                    HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                    string message = ((HttpWebResponse)e.Response).StatusDescription;
                    StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                    string error = reader.ReadToEnd();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string mensaje = js.Deserialize<string>(error);

                    ModelState.AddModelError("MensajeError", mensaje);
                    return View(citaEN);
                }
            }
            return RedirectToAction("MisCitas");
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}
