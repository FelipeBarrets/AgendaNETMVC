using agendaNET.DAO;
using agendaNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace agendaNET.Controllers
{
    public class LoginController : Controller
    {
        private readonly UsuarioDAO usuarioDAO;
        public LoginController()
        {
            this.usuarioDAO = new UsuarioDAO();
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginPrincipal(autenticacao autenticacao)
        {


           UsuarioDAO usuarioDAO = new UsuarioDAO();

          // Chama o método de validação do usuário e senhas passados.
           bool usuario = usuarioDAO.Logar(autenticacao.Login, autenticacao.Senha);

            if (usuario == true)
            {
                Session["usuario"] = autenticacao.Login;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }



        }

    }
}