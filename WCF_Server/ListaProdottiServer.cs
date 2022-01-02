using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Server
{
    public class ListaProdottiServer
    {
        public ListaProdottiServer()
        {
            this.listaProducts = new List<ProdottoServer>();
        }
        public List<ProdottoServer> listaProducts { get; set; }
    }
}
