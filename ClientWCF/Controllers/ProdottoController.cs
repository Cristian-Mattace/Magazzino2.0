using ClientWCF.Models;
using ClientWCF.ServiceReference1;
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
                        throw new Exception("Impossibile trovare il prodotto con id: "+id);
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
                    ViewBag.Message = e.Message;
                    return View("Error");
                }
            }
            ViewBag.Message = "Dati non consoni al Model specificato!";
            return View("Error");
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

                    //controllo cosa è stato cambiato per metterlo nella descrizione
                    Prodotto p = new Prodotto();
                    p.convertiServerToCLient(wcf.getProdById(p1.id));
                    string cambiamenti = "";
                    if (p.quantità != p1.quantità) cambiamenti = "Quantità = " + p1.quantità + " ";
                    if (p.posizione != p1.posizione) cambiamenti = cambiamenti + "Posizione = " + p1.posizione;

                    //convertiamo il model in un oggetto per il server
                    var ps = p1.convertiClientToServer();

                    //controllo che ritorni true
                    if (wcf.updateProduct(ps, i, cambiamenti, date))
                    {
                        //ritorno alla view prodotti tramite redirectToAction
                        return RedirectToAction("Prodotti");
                    }
                    else
                    {
                        throw new Exception("Impossibile aggiornare il prodotto!");
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
                        throw new Exception("Impossibile stampare i prodotti!");
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
                    ViewBag.Message = e.Message;
                    return View("Error");
                }
            }
            ViewBag.Message = "Dati non consoni al Model specificato!";
            return View("Error");
        }

        public ActionResult CreaProdotto()
        {
            Prodotto p1 = new Prodotto();
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

                    return View(p1);

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
                    {
                        throw new Exception("Impossibile creare prodotto!");
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


        public ActionResult EliminaProdotto(int id)
        {
            if (ModelState.IsValid)
            {
                //connessione col service
                try
                {
                    var wcf = new ServiceReference1.Service1Client();
                    Prodotto p = new Prodotto();

                    //chiedo al server di trovarmi il prodotto con l id specificato e poi lo converto in un model per il client
                    p.convertiServerToCLient(wcf.getProdById(id));
                    return View(p);
                }
                catch (Exception e)
                {
                    ViewBag.Message = "Impossibile trovare il prodotto!";
                    return View("Error");
                }
            }
            ViewBag.Message = "Dati non consoni al Model specificato!";
            return View("Error");
        }

        [HttpPost, ActionName("EliminaProdotto")]
        public ActionResult EliminaProdottoConferma(int id)
        {
            if (ModelState.IsValid)
            {
                //connessione col service
                try
                {
                    var wcf = new ServiceReference1.Service1Client();
                    //chiamo il metodo elimina utente, con parametro l'utente con l'id passato
                    if (wcf.EliminaProdotto(wcf.getProdById(id)))
                    {
                        return RedirectToAction("Prodotti");
                    }
                    else
                    {
                        throw new Exception("Impossibile eliminare il prodotto!");
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
                        throw new Exception("Impossibile trovare il prodotto con id: "+id);
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
                    ViewBag.Message = e.Message;
                    return View("Error");
                }
            }
            ViewBag.Message = "Dati non consoni al Model specificato!";
            return View("Error");
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
                        throw new Exception("Impossibile modificare il prodotto!");
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