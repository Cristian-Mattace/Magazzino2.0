using ClientWCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientWCF.Controllers
{
    public class UtenteController : Controller
    {
        // GET: Utente
        public ActionResult Index()
        {
            return View();
        }

        //ritorniamo alla view con l'oggetto utente, contenente id e password inseriti
        public ActionResult Login()
        {
            var ut = new Dipendente();
            return View(ut);
        }

        //tramite il dipendente passato, controlliamo se esiste l'account con il metodo del server
        //dopodichè andiamo alla view MenuUtente con le info del dipendente
        [HttpPost]
        public ActionResult Login(Dipendente ut)
        {
            if (ModelState.IsValid)
            {
                //connessione col service
                try
                {
                    var wcf = new ServiceReference1.Service1Client();

                    //gli mandiamo le credenziali e lui controlla se 
                    //c'è un utente con quelle credenziali, se c'è ci invia i dati dell utente
                    if (wcf.Login(ut.id, ut.password) == null)
                    {
                        ViewBag.Message = "ID o password errati!";
                        return View();
                    }
                    else
                    {
                        ut.convertiServerToCLient(wcf.Login(ut.id, ut.password));
                        Session["ID"] = ut.id;
                        if (ut.amministratore == true)
                        {
                            Session["CEO"] = 1;
                        }
                        else
                        {
                            Session["CEO"] = 0;
                        }

                        //creo una viewBag con i prodotti in esaurimento
                        string prodotti = "";
                        foreach (var x in wcf.getProductInExhaustion())
                        {
                            prodotti = prodotti + x + " - ";
                        }
                        if (prodotti != "")
                        {
                            prodotti = prodotti.Remove(prodotti.Length - 3);
                            ViewBag.prodottiInEsaurimento = prodotti;
                        }
                        return View("MenuUtente", ut);
                    }
                }catch(Exception e)
                {
                    ViewBag.Message = e.Message;
                    return View("Error");
                }
            }
            ViewBag.Message = "Dati non consoni al Model specificato!";
            return View("Error");
        }

        //crea un dipendente contenente i dati inseriti e lo ritorna alla view
        public ActionResult CreaUtente()
        {
            Dipendente dp = new Dipendente();
            return View(dp);
        }

        //tramite il dipendente passato come parametro creiamo il nuovo dipendente nel DB col metodo del server
        [HttpPost]
        public ActionResult CreaUtente(Dipendente dp)
        {
            if (ModelState.IsValid)
            {
                //connessione col service
                try
                {
                    var wcf = new ServiceReference1.Service1Client();

                    //verifico che la creazione dell utente ritorni un bool a true
                    if (wcf.CreaUtente(dp.convertiClientToServer()))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                        throw new Exception("Impossibile creare nuovo utente!");
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

        //esegue il logout, settando a null le Session utilizzate
        //NON USA LA VIEW LOGOUT, ma torna nuovamente alla index
        public ActionResult Logout()
        {
            try
            {
                Session["ID"] = null;
                Session["CEO"] = null;

                //ritorno nella home
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View("Error");
            }
            
        }

        //recupero la lista di dipendenti dal server e ritorno alla view passandogli la lista
        public ActionResult Utenti()
        {
            ListaDipendenti LP = new ListaDipendenti();
            if (ModelState.IsValid)
            {
                //connessione col service
                try
                {
                    var wcf = new ServiceReference1.Service1Client();
                    //recuper la lista dipendenti server
                    var listaDip = wcf.getListaDipendenti();

                    if (listaDip == null)
                    {
                        throw new Exception("Non ci sono dipendenti!");
                    }
                    else
                    {
                        //converto la lista da server a client e la passo alla view
                        LP.convertiListaDipendentiServer(listaDip);
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

        //ricerca dell'utente tramite id inserito nella textBox, se lo trova lo ritorna alla view
        [HttpPost]
        public ActionResult Utenti(String IdDip)
        {
            var dip = IdDip;
            ListaDipendenti LP = new ListaDipendenti();
            if (ModelState.IsValid)
            {
                //connessione col service
                try
                {
                    var wcf = new ServiceReference1.Service1Client();
                    //recupero il dipendente con quell'ID
                    var serverDip = wcf.getUtenteById(int.Parse(dip));       

                    if (serverDip == null)
                    {
                        throw new Exception("Non ci sono dipendenti con ID: " + dip);
                    }
                    else
                    {
                        //ritorno la lista dippendenti convertita alla view (anche se ritorna sempre 1 dipendente)
                        Dipendente dp = new Dipendente();
                        dp.convertiServerToCLient(serverDip);
                        LP.listaDipend.Add(dp);
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

        //recupera il dipendente che vogliamo modificare e lo passa alla view
        public ActionResult ModificaUtente(int id)
        {
            Dipendente d = new Dipendente();
            if (ModelState.IsValid)
            {
                //connessione col service
                try
                {
                    var wcf = new ServiceReference1.Service1Client();
                    //controllo che ritorni un prodotto
                    var dipserver = wcf.getUtenteById(id);
                    if (dipserver == null)
                    {
                        throw new Exception("Non ci sono utenti con ID = " + id);
                    }
                    else
                    {
                        //converto l user da server a client e chiamo la view con l user client
                        d.convertiServerToCLient(dipserver);

                        ViewBag.Message = d.nome;
                        return View(d);
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

        //modifica il dipendente che gli è stato passato come parametro e lo modifica, ritornando alla lista di utenti aggiornata
        [HttpPost]
        public ActionResult ModificaUtente(Dipendente d)
        {
            if (ModelState.IsValid)
            {
                //connessione col service
                try
                {
                    var wcf = new ServiceReference1.Service1Client();

                    var DipendToServer = d.convertiClientToServer();

                    //controllo che ritorni true
                    if (wcf.UserUpdateCeo(DipendToServer))
                    {
                        //ritorno alla view prodotti tramite redirectToAction
                        return RedirectToAction("Utenti");
                    }
                    else
                    {
                        throw new Exception("Impossibile modificare utente!");
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

        //recupera il dipendente che vogliamo eliminare e lo passa alla view
        public ActionResult EliminaUtente(int id)
        {
            if (ModelState.IsValid)
            {
                //connessione col service
                try
                {
                    var wcf = new ServiceReference1.Service1Client();
                    Dipendente d = new Dipendente();
                    //chiamo il metodo get utente by id, con parametro l'utente con l'id passato
                    d.convertiServerToCLient(wcf.getUtenteById(id));
                    return View(d);
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

        //conferma per eliminare l'utente
        [HttpPost, ActionName("EliminaUtente")]
        public ActionResult EliminaUtenteConferma(int id)
        {
            if (ModelState.IsValid)
            {
                //connessione col service
                try
                {
                    var wcf = new ServiceReference1.Service1Client();
                    //chiamo il metodo elimina utente, con parametro l'utente con l'id passato
                    if (wcf.EliminaDipendente(wcf.getUtenteById(id)))
                    {
                        return RedirectToAction("Utenti");
                    }
                    else
                        throw new Exception("Impossibile eliminare utente!");
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