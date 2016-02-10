using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using UPC.SisTictecks.EL;

namespace UPC.SisTictecks.Web.Controllers
{
    public class UsuarioController : Controller
    {        
        private UsuariosWS.UsuariosServiceClient UsuariosProxy = new UsuariosWS.UsuariosServiceClient();

        //GET: /Usuario/
        public ActionResult Index()
        {
            List<UsuarioEN> listaUsuarios;
            listaUsuarios = UsuariosProxy.ListarUsuarios().ToList();
            return View(listaUsuarios);
        }

        //
        // GET: /Usuario/Detalles/1
        public ActionResult Detalles(int id)
        {
            UsuarioEN usuario;
            usuario = UsuariosProxy.ObtenerUsuario(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // GET: /Usuario/Registrar
        public ActionResult Registrar()
        {            
            return View();
        }


        //
        // POST: /Usuario/Registrar
        [HttpPost]
        public ActionResult Registrar(UsuarioEN usuarioEN, int cboPerfiles)
        {
            try
            {
                if (ModelState.IsValid)
                {                    
                    try
                    {
                        usuarioEN.Perfil = new PerfilEN { Codigo = cboPerfiles };
                        usuarioEN.Usuario = usuarioEN.Usuario.ToUpper();
                        usuarioEN = UsuariosProxy.CrearUsuario(usuarioEN);                        
                    }
                    catch (FaultException<RepetidoException> fe)
                    {
                        ModelState.AddModelError("MensajeError", fe.Message+": "+ fe.Detail.Mensaje);
                        return View(usuarioEN);
                    }                    

                }
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("MensajeError", "Ocurrió un error al grabar el registro.");
                return View(usuarioEN);
            }
        }

        // GET: /Usuario/Editar/5
        public ActionResult Editar(int id)
        {
            UsuarioEN usuario = new UsuarioEN();
            if (ModelState.IsValid)
            {                
                try
                {
                    usuario = UsuariosProxy.ObtenerUsuario(id);
                }
                catch (FaultException<RepetidoException> fe)
                {
                    ModelState.AddModelError("MensajeError", fe.Message + ": " + fe.Detail.Mensaje);
                }
            }           
            return View(usuario);
        }

        //
        // POST: /Usuario/Editar/5
        [HttpPost]
        public ActionResult Editar(UsuarioEN usuarioEN,int cboPerfiles)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    usuarioEN.Perfil = new PerfilEN { Codigo = cboPerfiles };
                    usuarioEN.Usuario = usuarioEN.Usuario.ToUpper();
                    UsuariosProxy.ModificarUsuario(usuarioEN);
                }
                catch (FaultException<RepetidoException> fe)
                {
                    ModelState.AddModelError("MensajeError", fe.Message + ": " + fe.Detail.Mensaje);
                    return View(usuarioEN);
                }
            }

            return RedirectToAction("Index");
        }

        // GET: /Usuario/Eliminar/5
        public ActionResult Eliminar(int id)
        {
            try
            {
                UsuariosProxy.EliminarUsuario(id);
            }
            catch (FaultException<RepetidoException> fe)
            {
                ModelState.AddModelError("MensajeError", fe.Message + ": " + fe.Detail.Mensaje);                
            }
                        
            return RedirectToAction("Index");
        }

        public JsonResult ListaPerfiles()
        {
            return Json(UsuariosProxy.ListarPerfiles().ToList(), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
                base.Dispose(disposing);
        }

	}
}