using ClientWCF.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWCF.Models
{
    public class ListaOperazioni
    {
        public ListaOperazioni()
        {
            this.listaOperazione = new List<Operazione>();
        }
        public List<Operazione> listaOperazione { get; set; }

        //metodo per convertire da server a client
        public void ConvertServerList(ListaOperazioniServer loserver)
        {
            foreach (var c in loserver.listaOpe)
            {
                Operazione o1 = new Operazione();
                o1.convertiServerToCLient(c);
                this.listaOperazione.Add(o1);
            }
        }
    }
}