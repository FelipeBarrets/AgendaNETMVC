using agendaNET.DAO;
using agendaNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace agendaNET.Controllers
{
    public class HomeController : Controller
    {

        private EventosDAO eventos;


        public HomeController()
        {
            this.eventos = new EventosDAO();
        }

        [HttpGet]
        public ActionResult Index()
        {
            string usuario = Session["usuario"].ToString();
            ViewData["DadosConsulta"] = eventos.listaEventos(usuario);
            return View();
        }

        [HttpPost]
        public ActionResult Index(string campoBusca)
        {
            string usuario = Session["usuario"].ToString();
            ViewData["DadosConsulta"] = eventos.buscaEvento(campoBusca, usuario);
            return View();
        }


        public ActionResult editarEvento(Eventos dados) {

            if (dados.idEventos == null) {
                dados.idEventos = "";
            }
            dados.criadorEvento = Session["usuario"].ToString();
            eventos.inserirEvento(dados);

           return RedirectToAction("Index");
        }

        


        public JsonResult buscaEditEvento(string numeroId)
        {

            string nomeUsuario = Session["usuario"].ToString();
            Eventos retorno = eventos.buscaEditEvento(numeroId, nomeUsuario);


            return Json(new { retorno }, JsonRequestBehavior.AllowGet);

        }


    }
}