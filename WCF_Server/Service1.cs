using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Server
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di classe "Service1" nel codice e nel file di configurazione contemporaneamente.
    public class Service1 : IService1
    {
        DB databse1 = new DB();
        public void DoWork()
        {
        }
        public void DoWork2()
        {
            Console.WriteLine("Ciao, sono dowork2!");
        }

        public DipendenteServer Login(int id, string pswd)
        {
            DipendenteServer ds = new DipendenteServer();

            try
            {
                //ci connettiamo al DB
                var x = databse1.getsqlconnect(databse1.connectstring());

                //ritorna l utente loggato
                ds = databse1.accessoutenti(x, id, pswd);
                return ds;
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore: " + e.ToString());
                return null;
            }
        }

        public ListaProdottiServer getListaProdotti()
        {
            ListaProdottiServer lsp = new ListaProdottiServer();

            try
            {
                //ci connettiamo al DB
                var x = databse1.getsqlconnect(databse1.connectstring());

                //ritorna la lista di prodotti
                lsp = databse1.getListaProdotti(x);
                return lsp;
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore: " + e.ToString());
                return null;
            }
        }


        public ProdottoServer getProdById(int n)
        {
            ProdottoServer ps = new ProdottoServer();
            try
            {
                //ci connettiamo al DB
                var x = databse1.getsqlconnect(databse1.connectstring());

                //ritorna la lista di prodotti
                ps = databse1.getProdottoById(x, n);
                return ps;
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore: " + e.ToString());
                return null;
            }
        }

        public DipendenteServer getUtenteById(int n)
        {
            DipendenteServer ps = new DipendenteServer();
            try
            {
                //ci connettiamo al DB
                var x = databse1.getsqlconnect(databse1.connectstring());

                //ritorna l user con l id che gli passiamo
                ps = databse1.getUtenteById(x, n);
                return ps;
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore: " + e.ToString());
                return null;
            }
        }


        public List<String> getFreePos()
        {
            List<String> postiDisponibili = new List<string>();
            try
            {
                //ci connettiamo al DB
                var x = databse1.getsqlconnect(databse1.connectstring());

                //ritorna la lista di prodotti
                postiDisponibili = databse1.getFreePosition(x);
                return postiDisponibili;
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore: " + e.ToString());
                return null;
            }
        }

        public bool updateProduct(int id, int quant, string pos, int idDip, string desc, string date)
        {
            try
            {
                //ci connettiamo al DB
                var x = databse1.getsqlconnect(databse1.connectstring());

                //ritorna true se ha effettuato correttamente le operazioni di update
                if (databse1.ProductUpdate(x, id, quant, pos, idDip, desc, date))
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore: " + e.ToString());
                return false;
            }
        }

        public bool CreaUtente(string nome, string cognome, string telefono, string pass, int ceo)
        {
            try
            {
                //ci connettiamo al DB
                var x = databse1.getsqlconnect(databse1.connectstring());

                //ritorna la lista di prodotti
                if (databse1.CreaUtente(x, nome, cognome, telefono, pass, ceo))
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore: " + e.ToString());
                return false;
            }
        }

        public bool EliminaDipendente(DipendenteServer ds)
        {
            try
            {
                //ci connettiamo al DB
                var x = databse1.getsqlconnect(databse1.connectstring());

                //eliminiamo il prodotto
                if (databse1.EliminaDipendente(x, ds))
                {
                    return true;
                }
                else
                    return false;

            }
            catch (Exception e)
            {
                Console.WriteLine("Errore: " + e.ToString());
                return false;
            }
        }

        public List<String> getNomiCategorie()
        {
            List<String> nomi = new List<String>();

            try
            {
                //ci connettiamo al DB
                var x = databse1.getsqlconnect(databse1.connectstring());

                //ritorna la lista dei nomi delle categorie
                nomi = databse1.getListaCategorie(x);
                return nomi;
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore: " + e.ToString());
                return null;
            }
        }

        public List<String> getNomiProduttori()
        {
            List<String> nomi = new List<String>();

            try
            {
                //ci connettiamo al DB
                var x = databse1.getsqlconnect(databse1.connectstring());

                //ritorna la lista dei nomi dei produttori
                nomi = databse1.getListaProduttori(x);
                return nomi;
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore: " + e.ToString());
                return null;
            }
        }


        public bool CreaProdotto(ProdottoServer ps)
        {
            try
            {
                //ci connettiamo al DB
                var x = databse1.getsqlconnect(databse1.connectstring());

                //crea il prodotto
                if (databse1.CreaProdotto(x, ps))
                {
                    return true;
                }
                else
                    return false;

            }
            catch (Exception e)
            {
                Console.WriteLine("Errore: " + e.ToString());
                return false;
            }
        }

        public bool EliminaProdotto(ProdottoServer ps)
        {
            try
            {
                //ci connettiamo al DB
                var x = databse1.getsqlconnect(databse1.connectstring());

                //eliminiamo il prodotto
                if (databse1.EliminaProdotto(x, ps))
                {
                    return true;
                }
                else
                    return false;

            }
            catch (Exception e)
            {
                Console.WriteLine("Errore: " + e.ToString());
                return false;
            }
        }

        public bool ProductUpdateCeo(ProdottoServer p1, int idUser, string date, string desc)
        {
            try
            {
                //ci connettiamo al DB
                var x = databse1.getsqlconnect(databse1.connectstring());

                //ritorna true se ha effetuato correttamente le operazioni di update
                if (databse1.ProductUpdateCeo(x,p1,idUser,date,desc))
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore: " + e.ToString());
                return false;
            }
        }

        public ListaDipendentiServer getListaDipendenti()
        {
            ListaDipendentiServer lsp = new ListaDipendentiServer();

            try
            {
                //ci connettiamo al DB
                var x = databse1.getsqlconnect(databse1.connectstring());

                //ritorna la lista di dipendenti
                lsp = databse1.getListaDipendenti(x);
                return lsp;
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore: " + e.ToString());
                return null;
            }
        }

        public bool UserUpdateCeo(DipendenteServer d1)
        {
            try
            {
                //ci connettiamo al DB
                var x = databse1.getsqlconnect(databse1.connectstring());

                //ritorna true se le modifiche sono state eseguite correttamente
                if (databse1.UserUpdateCeo(x, d1))
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore: " + e.ToString());
                return false;
            }
        }
    }
}
        

