using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Server
{
    public class ListaOperazioniServer
    {
        public ListaOperazioniServer()
        {
            this.listaOpe = new List<OperazioneServer>();
        }
        public List<OperazioneServer> listaOpe { get; set; }
    }
}
