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

        //recupera il prodotto che il dipendente vuole modificare e lo ritorna alla view
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
                        //converto il prodotto da server a client
                        p.convertiServerToCLient(wcf.getProdById(id));

                        //Creo una lista di stringhe ed aggiungo posizione corrente del prodotto + quelle disponibili
                        List<String> posizioni = new List<string>();
                        posizioni.Add(p.posizione);
                        foreach(var z in wcf.getFreePos())
                        {
                            posizioni.Add(z);
                        }

                        //aggiungo le posizioni al viewbag.data
                        ViewBag.data = posizioni;
                        //aggiungo il nome del prodotto al viewbag.message
                        ViewBag.Message = p.nome;
                        //ritorno alla view passandogli il prodotto selezionato
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

        //chiama il metodo del server per modificare il prodotto e ritorna alla lista prodotti aggiornata
        [HttpPost]
        public ActionResult AzioniProdotto(Prodotto p1)
        {
            if (ModelState.IsValid)
            {
                //connessione col service
                try
                {
                    var wcf = new ServiceReference1.Service1Client();
                    //recupero l'id del dipendente che vuole fare la modifica
                    int idDip = (int)Session["ID"];
                    //recupero la data attuale
                    string date = DateTime.UtcNow.AddHours(1).ToString("yyyy-MM-dd HH:mm:ss");

                    //controllo cosa è stato cambiato per metterlo nella descrizione
                    Prodotto p = new Prodotto();
                    p.convertiServerToCLient(wcf.getProdById(p1.id));
                    string cambiamenti = "";
                    if (p.quantità != p1.quantità) cambiamenti = "Quantità = " + p1.quantità + " ";
                    if (p.posizione != p1.posizione) cambiamenti = cambiamenti + "Posizione = " + p1.posizione;

                    //se non cambiamo niente torniamo alla lista dei prodotti
                    if (p.quantità == p1.quantità && p.posizione == p1.posizione) return RedirectToAction("Prodotti");

                    //convertiamo il model in un oggetto per il server
                    var ps = p1.convertiClientToServer();

                    //controllo che ritorni true
                    if (wcf.updateProduct(ps, idDip, cambiamenti, date))
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

        //recupero tutti i prodotti dal server e li passo alla view
        public ActionResult Prodotti()
        {
            ListaProdotti LP = new ListaProdotti();
            if (ModelState.IsValid)
            {
                //connessione col service
                try
                {
                    var wcf = new ServiceReference1.Service1Client();

                    //otteniamo la lista di categorie e la inseriamo in una combobox nella view
                    List<String> nomiCate = new List<string>();
                    foreach (var x in wcf.getNomiCategorie())
                    {
                        nomiCate.Add(x);
                    }
                    //aggiungo le categorie alla viewbag.nomiCate
                    ViewBag.nomiCate = nomiCate;

                    if (wcf.getListaProdotti() == null)
                    {
                        throw new Exception("Impossibile stampare i prodotti!");
                    }
                    else
                    {
                        //recupero la lista dei nomi delle categorie e la passo alla vista con viewbag.categorie
                        ViewBag.categorie = nomiCate;

                        //recupero la lista dei nomi dei produttori e la passo alla vista con viewbag.produttori
                        ViewBag.produttori = wcf.getNomiProduttori();

                        //converto la lista di prodotti da server a client
                        LP.ConvertServerList(wcf.getListaProdotti());
                        //ritorno alla view con la lista prodotti client
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

        //recupera tutti i prodotti della categoria selezionata e li passa alla view
        [HttpPost]
        public ActionResult Prodotti(String Categoria)
        {
            if (ModelState.IsValid)
            {
                //recupero il valore della categoria
                var selectedValue = Categoria;
                ListaProdotti LP = new ListaProdotti();

                //connessione col service
                try
                {
                    var wcf = new ServiceReference1.Service1Client();

                    //otteniamo la lista di categorie e la inseriamo in una combobox nella view
                    List<String> nomiCate = new List<string>();
                    foreach (var x in wcf.getNomiCategorie())
                    {
                        nomiCate.Add(x);
                    }
                    ViewBag.nomiCate = nomiCate;

                    //ottenialmo la lista di prodotti con categoria scelta
                    var prodByCat = wcf.getListaProdottiByCategory(int.Parse(selectedValue));

                    if (prodByCat == null)
                    {
                        throw new Exception("Impossibile stampare i prodotti!");
                    }
                    else
                    {
                        //recupero la lista dei nomi delle categorie e la passo alla vista con viewbag.categorie
                        ViewBag.categorie = nomiCate;

                        //recupero la lista dei nomi dei produttori e la passo alla vista con viewbag.produttori
                        ViewBag.produttori = wcf.getNomiProduttori();

                        //converto la lista prodotti da server a client
                        LP.ConvertServerList(prodByCat);
                        //ritorno la view con la lista prodotti client
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

        //recupera le categorie, i produttori ed i posti disponibili e li passa alla view
        public ActionResult CreaProdotto()
        {
            Prodotto p1 = new Prodotto();
            if (ModelState.IsValid)
            {
                //connessione col service
                try
                {
                    var wcf = new ServiceReference1.Service1Client();

                    //recupero i nomi delle categorie
                    List<String> nomiCat = new List<string>(); 
                    foreach(var x in wcf.getNomiCategorie())
                    {
                        nomiCat.Add(x);
                    }
                    ViewBag.nomiCat = nomiCat;

                    //recupero i nomi dei produttori
                    List<String> nomiProd = new List<string>();
                    foreach (var x in wcf.getNomiProduttori())
                    {
                        nomiProd.Add(x);
                    }
                    ViewBag.nomiProd = nomiProd;

                    //recupero i posti disponibili
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

        //chiamo il metodo per creaare il prodotto del server e ritorno alla lista di prodotti aggiornata
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

                    //controllo che la creazione vada a buon fine
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


        //recupera l'oggetto che voglio eliminare e lo passo alla view
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

        //confermo l'eliminazione del prodotto chiamando il metodo del server e ritornando alla lista prodotti aggiornata
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

        //recupero il prodotto che il CEO vuole modificare e lo passo alla view
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

                        //recupero le categorie
                        List<String> nomiCat = new List<string>();
                        foreach (var x in wcf.getNomiCategorie())
                        {
                            nomiCat.Add(x);
                        }
                        ViewBag.nomiCat = nomiCat;

                        //recupero i produttori
                        List<String> nomiProd = new List<string>();
                        foreach (var x in wcf.getNomiProduttori())
                        {
                            nomiProd.Add(x);
                        }
                        ViewBag.nomiProd = nomiProd;

                        //Recupero i posti disponibili
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

        //chiamo il metodo per modificare il prodotto CEO e ritorno alla lista di prodotti aggiornata
        [HttpPost]
        public ActionResult ModificaProdotto(Prodotto p1)
        {
            if (ModelState.IsValid)
            {
                //connessione col service
                try
                {
                    var wcf = new ServiceReference1.Service1Client();
                    //recupero l'id del CEO
                    int idUser = (int)Session["ID"];
                    //recupero la data
                    string date = DateTime.UtcNow.AddHours(1).ToString("yyyy-MM-dd HH:mm:ss");

                    //controllo cosa è stato cambiato per metterlo nella descrizione
                    Prodotto p = new Prodotto();
                    p.convertiServerToCLient(wcf.getProdById(p1.id));
                    string cambiamenti = "";
                    if (p.quantità != p1.quantità) cambiamenti = "Quantità = " + p1.quantità + " ";
                    if (p.posizione != p1.posizione) cambiamenti = cambiamenti + "Posizione = " + p1.posizione;

                    //se cambio il resto scrive aggiornamento generico
                    if (p.nome != p1.nome || p.produttore != p1.produttore || p.categoria != p1.categoria || p.prezzo != p1.prezzo) cambiamenti = "Aggiornamento generico";
                    //se non cambio nulla torno alla view
                    if (p.nome == p1.nome && p.produttore == p1.produttore && p.categoria == p1.categoria && p.prezzo == p1.prezzo && p.quantità == p1.quantità && p.posizione == p1.posizione) return RedirectToAction("Prodotti");

                    var ProdottoToServer = p1.convertiClientToServer();

                    //controllo che ritorni true
                    if (wcf.ProductUpdateCeo(ProdottoToServer,idUser,date,cambiamenti))
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