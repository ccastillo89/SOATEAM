using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using formsAuth = System.Web.Security.FormsAuthentication;

namespace UPC.SisTictecks.Web.Controllers
{
    public class LoginController : Controller
    {
        //Varibles de Invocacion
        //private UsuarioBL usuarioBL = new UsuarioBL();

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

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(UsuarioEN user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (usuarioBL.Login(user.Usuario, user.Pass))
        //        {
        //            formsAuth.SetAuthCookie(user.Usuario, user.Recordarme);
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Usuario o password es incorrecto!");
        //        }
        //    }
        //    return View(user);
        //}

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