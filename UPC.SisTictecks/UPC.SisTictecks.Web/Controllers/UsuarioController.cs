using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UPC.SisTictecks.Web.Controllers
{
    public class UsuarioController : Controller
    {
        //private UsuarioBL usuarioBL = new UsuarioBL();

        //
        // GET: /Usuario/
        //public ActionResult Index()
        //{
        //    return View(usuarioBL.Listar());
        //}

        ////
        //// GET: /Usuario/Detalles/1
        //public ActionResult Detalles(int id)
        //{
        //    UsuarioEN usuario = usuarioBL.Obtener(id);
        //    if (usuario == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(usuario);
        //}

        ////
        //// GET: /Usuario/Registrar
        //public ActionResult Registrar()
        //{
        //    return View();
        //}


        ////
        //// POST: /Usuario/Registrar
        //[HttpPost]
        //public ActionResult Registrar(UsuarioEN usuarioEN) 
        //{
        //    try
        //    {
        //        if (ModelState.IsValid) 
        //        {
        //            bool correcto = usuarioBL.Registrar(usuarioEN);
        //            if (correcto)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //            else
        //            {

        //            }
                    
        //        }
        //        return View(usuarioEN);
        //    }
        //    catch
        //    {
        //        return View(usuarioEN);
        //    }
        //}

        ////
        //// GET: /Usuario/Editar/5
        //public ActionResult Editar(int id)
        //{
        //    UsuarioEN usuario = usuarioBL.Obtener(id);
        //    if (usuario == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(usuario);
        //}


        ////
        //// POST: /Usuario/Editar/5
        //[HttpPost]
        //public ActionResult Editar(UsuarioEN usuarioEN)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            bool correcto = usuarioBL.Actualizar(usuarioEN);
        //            if (correcto)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //            else
        //            {

        //            }

        //        }
        //        return View(usuarioEN);

        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /Usuario/Eliminar/5
        //public ActionResult Eliminar(int id)
        //{
        //    UsuarioEN usuarioEN = usuarioBL.Obtener(id);
        //    if (usuarioEN == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(usuarioEN);
        //}

        ////
        //// POST: /Usuario/Eliminar/5
        //[HttpPost]
        //public ActionResult Eliminar(UsuarioEN usuarioEN)
        //{
        //    try
        //    {
        //        int id = usuarioEN.Id;
        //        bool correcto = usuarioBL.Eliminar(id);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        protected override void Dispose(bool disposing)
        {
                base.Dispose(disposing);
        }

	}
}