using mvc_Session_NetFramework.DAOs;
using mvc_Session_NetFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_Session_NetFramework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var usuario = Session["usuario"];

            if (usuario != null)
            {
                return Redirect("/Home/Private");
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public ActionResult Login(string usuario, string password)
        {

            var usuarioEncontrado = UsuarioDAO.getInstancia().buscarUsuario(usuario, password);

            if (usuarioEncontrado != null)
            {

                Session.Add("usuario", new Usuario(usuario, password));
                return Redirect("/Home/Private");

            }
            else
            {

                ViewBag.msg = "El usuario no existe";
                return View("Index");

            }

        }

        [HttpPost]

        public ActionResult Register(string usuario, string password)
        {

            UsuarioDAO.getInstancia().add(new Usuario(usuario, password));
            ViewBag.msg = "El usuario fue creado correctamente";
            return View("Index");

        }

        public ActionResult Logout()
        {

            Session.Clear();
            return Redirect("/Home/Index");

        }


        public ActionResult Private()
        {

            var usuario = (Usuario) Session["usuario"];

            if (usuario != null)
            {

                ViewBag.usuario = usuario;
                return View("Private");

            }
            else
            {
                return View("Index");
            }

        }

    }
}