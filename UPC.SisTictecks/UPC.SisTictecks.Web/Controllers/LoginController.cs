using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using UPC.SisTictecks.EL;
using formsAuth = System.Web.Security.FormsAuthentication;

namespace UPC.SisTictecks.Web.Controllers
{
    public class LoginController : Controller
    {
        //Varibles de Invocacion
        //private UsuarioBL usuarioBL = new UsuarioBL();
        private UsuariosWS.UsuariosServiceClient UsuariosProxy = new UsuariosWS.UsuariosServiceClient();
        private SeguridadWS.SeguridadServiceClient SeguridadProxy = new SeguridadWS.SeguridadServiceClient();


        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login user)
        {
            UsuarioEN UsuLogin = new UsuarioEN();
                
            if (ModelState.IsValid)
            {
                try
                {
                    UsuLogin = SeguridadProxy.AutenticarUsuario(user.Usuario, user.Clave);
                    return RedirectToAction("Index", "Home");
                }
                catch (FaultException<RepetidoException> fe)
                {
                    ModelState.AddModelError("MensajeError", fe.Message + ": " + fe.Detail.Mensaje);
                }
                                   
                //    formsAuth.SetAuthCookie(user.Usuario, true);                                               
            }
            
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            formsAuth.SignOut();
            return Redirect(formsAuth.DefaultUrl);
        }

        [HttpGet]
        public ActionResult Registrar()
        {
            return View();
        }



	}
}