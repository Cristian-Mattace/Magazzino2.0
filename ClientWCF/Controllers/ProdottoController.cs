using ClientWCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientWCF.Controllers
{
    public class ProdottoController : Controller
    {
        // GET: Prodotto
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AzioniProdotto(int id)
        {
            Prodotto p = new Prodotto();
            if (ModelState.IsValid)
            {
                //connessione col service
                try
                {
                    var wcf = new ServiceReference1.Service1Client();
                    //controllo che ritorni un prodotto
                    if (wcf.getProdById(id) == null)
                    {
                        return Content("Non ci sono prodotti con ID = " + id);
                    }
                    else
                    {
                        //converto il prodotto da server a client e chiamo la view con il prodotto client
                        p.convertiServerToCLient(wcf.getProdById(id));

                        //Creo una lista di stringhe ed aggiungo posizione corrente del prodotto + quelle disponibili
                        List<String> posizioni = new List<string>();
                        posizioni.Add(p.posizione);
                        foreach(var z in wcf.getFreePos())
                        {
                            posizioni.Add(z);
                        }

                        ViewBag.data = posizioni;
                        ViewBag.Message = p.nome;
                        return View(p);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("ERRORE: " + e.ToString());
                    return View();
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult AzioniProdotto(Prodotto p1)
        {
            if (ModelState.IsValid)
            {
                //connessione col service
                try
                {
                    var wcf = new ServiceReference1.Service1Client();
                    int i = (int)Session["ID"];
                    string date = DateTime.UtcNow.ToString("yyyy-MM-dd");
                    //controllo che ritorni un prodotto
                    if (wcf.updateProduct(p1.id, p1.quantità, p1.posizione,i,"Aggiornamento",date))
                    {
                        //ritorno alla view prodotti tramite redirectToAction
                        return RedirectToAction("Prodotti");
                    }
                    else
                    {
                        return Content("CAZZO");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("ERRORE: " + e.ToString());
                    return View();
                }
            }
            return View();
        }

        public ActionResult Prodotti()
        {
            ListaProdotti LP = new ListaProdotti();
            if (ModelState.IsValid)
            {
                //connessione col service
                try
                {
                    var wcf = new ServiceReference1.Service1Client();

                    if (wcf.getListaProdotti() == null)
                    {
                        return Content("Non ci sono prodotti nel db!");
                    }
                    else
                    {
                        //recupero la lista dei nomi delle categorie e la passo alla vista con viewbag.categorie
                        List<String> nomiCat = new List<string>();
                        ViewBag.categorie = wcf.getNomiCategorie();
                        //recupero la lista dei nomi dei produttori e la passo alla vista con viewbag.produttori
                        List<String> nomiProd = new List<string>();
                        ViewBag.produttori = wcf.getNomiProduttori();
                        LP.ConvertServerList(wcf.getListaProdotti());
                        return View(LP);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("ERRORE: " + e.ToString());
                    return View();
                }
            }
        
            return View(LP);
        }

        public ActionResult CreaProdotto()
        {
            if (ModelState.IsValid)
            {
                //connessione col service
                try
                {
                    var wcf = new ServiceReference1.Service1Client();

                    List<String> nomiCat = new List<string>(); 
                    foreach(var x in wcf.getNomiCategorie())
                    {
                        nomiCat.Add(x);
                    }
                    ViewBag.nomiCat = nomiCat;

                    List<String> nomiProd = new List<string>();
                    foreach (var x in wcf.getNomiProduttori())
                    {
                        nomiProd.Add(x);
                    }
                    ViewBag.nomiProd = nomiProd;

                    List<String> posti = new List<string>();
                    foreach (var x in wcf.getFreePos())
                    {
                        posti.Add(x);
                    }
                    ViewBag.posti = posti;

                }
                catch (Exception e)
                {
                    Console.WriteLine("ERRORE: " + e.ToString());
                    return View();
                }
            }
        
            Prodotto p1 = new Prodotto();
            return View(p1);
        }

        [HttpPost]
        public ActionResult CreaProdotto(Prodotto p1)
        {
            if (ModelState.IsValid)
            {
                //connessione col service
                try
                {
                    var wcf = new ServiceReference1.Service1Client();

                    var ProductToServer = p1.convertiClientToServer();


                    if (wcf.CreaProdotto(ProductToServer))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                        return Content("CAZZO");
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERRORE: " + e.ToString());
                    return View();
                }
            }
            return View("CAZZO");
        }


        public ActionResult EliminaProdotto(int id)
        {
            if (ModelState.IsValid)
            {
                //connessione col service
                try
                {
                    var wcf = new ServiceReference1.Service1Client();
                    //chiamo il metodo elimina prodotto, con parametro il prodotto con l'id passato
                    if (wcf.EliminaProdotto(wcf.getProdById(id)))
                    {
                        return RedirectToAction("Prodotti");
                    }
                    else
                        return Content("CAZZO");
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERRORE: " + e.ToString());
                    return View();
                }
            }
            return View("CAZZO");
        }

        public ActionResult ModificaProdotto(int id)
        {
            Prodotto p = new Prodotto();
            if (ModelState.IsValid)
            {
                //connessione col service
                try
                {
                    var wcf = new ServiceReference1.Service1Client();
                    //controllo che ritorni un prodotto
                    var prodServer = wcf.getProdById(id);
                    if (prodServer == null)
                    {
                        return Content("Non ci sono prodotti con ID = " + id);
                    }
                    else
                    {
                        //converto il prodotto da server a client e chiamo la view con il prodotto client
                        p.convertiServerToCLient(prodServer);


                        List<String> nomiCat = new List<string>();
                        foreach (var x in wcf.getNomiCategorie())
                        {
                            nomiCat.Add(x);
                        }
                        ViewBag.nomiCat = nomiCat;

                        List<String> nomiProd = new List<string>();
                        foreach (var x in wcf.getNomiProduttori())
                        {
                            nomiProd.Add(x);
                        }
                        ViewBag.nomiProd = nomiProd;

                        List<String> posti = new List<string>();
                        posti.Add(p.posizione);
                        foreach (var x in wcf.getFreePos())
                        {
                            posti.Add(x);
                        }
                        ViewBag.posti = posti;

                        ViewBag.Message = p.nome;
                        return View(p);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("ERRORE: " + e.ToString());
                    return View();
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult ModificaProdotto(Prodotto p1)
        {
            if (ModelState.IsValid)
            {
                //connessione col service
                try
                {
                    var wcf = new ServiceReference1.Service1Client();
                    int idUser = (int)Session["ID"];
                    string date = DateTime.UtcNow.ToString("yyyy-MM-dd");

                    var ProdottoToServer = p1.convertiClientToServer();

                    //controllo che ritorni true
                    if (wcf.ProductUpdateCeo(ProdottoToServer,idUser,date,"Aggiornamento"))
                    {
                        //ritorno alla view prodotti tramite redirectToAction
                        return RedirectToAction("Prodotti");
                    }
                    else
                    {
                        return Content("CAZZO");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("ERRORE: " + e.ToString());
                    return View();
                }
            }
            return View();
        }

    }
}