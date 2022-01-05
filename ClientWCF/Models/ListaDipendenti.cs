using ClientWCF.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWCF.Models
{
    public class ListaDipendenti
    {
        public ListaDipendenti()
        {
            this.listaDipend = new List<Dipendente>();
        }
        public List<Dipendente> listaDipend { get; set; }

        //metodo per convertire da server a client
        public void convertiListaDipendentiServer(ListaDipendentiServer lds) 
        {
            foreach(var x in lds.listaDipendServer)
            {
                Dipendente d1 = new Dipendente();

                d1.convertiServerToCLient(x);

                this.listaDipend.Add(d1);
            }
        }


    }
}