using ClientWCF.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWCF.Models
{
    public class ListaProdotti
    {
        public ListaProdotti()
        {
            this.listaProducts = new List<Prodotto>();
        }
        public List<Prodotto> listaProducts { get; set; }

        //metodo per convertire da server a client
        public void ConvertServerList(ListaProdottiServer lpserver)
        {
            foreach(var c in lpserver.listaProducts)
            {
                Prodotto p1 = new Prodotto();
                p1.convertiServerToCLient(c);
                this.listaProducts.Add(p1);
            }
        }
        
    }
}