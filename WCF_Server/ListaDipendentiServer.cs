using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Server
{
    public class ListaDipendentiServer
    {
        public ListaDipendentiServer()
        {
            this.listaDipendServer = new List<DipendenteServer>();
        }
        public List<DipendenteServer> listaDipendServer { get; set; }
    }
}
