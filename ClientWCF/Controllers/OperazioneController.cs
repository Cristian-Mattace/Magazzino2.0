using ClientWCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientWCF.Controllers
{
    public class OperazioneController : Controller
    {
        // GET: Operazione
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Operazioni()
        {
            ListaOperazioni LO = new ListaOperazioni();
            if (ModelState.IsValid)
            {
                //connessione col service
                try
                {
                    var wcf = new ServiceReference1.Service1Client();

                    var listaOpe = wcf.getOperazioni();

                    if (listaOpe == null)
                    {
                        throw new Exception("Non ci sono Operazioni!");
                    }
                    else
                    {
                        LO.ConvertServerList(listaOpe);
                        return View(LO);
                    }

                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                    return View("Error");
                }
            }

            ViewBag.Message = "Dati non consoni al Model specificato!";
            return View("Error");
        }
    }
}