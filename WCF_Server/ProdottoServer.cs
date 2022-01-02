using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Server
{
    public class ProdottoServer
    {
        public ProdottoServer()
        {
            
        }

        public ProdottoServer(int ids, string n, int prod, float prez, int cat, int qua, string pos)
        {
            this.id = ids;
            this.nome = n;
            this.produttore = prod;
            this.prezzo = prez;
            this.quantita = qua;
            this.categoria = cat;        
            this.posizione = pos;
        }
        public int id { get; set; }
        public string nome { get; set; }

        public int produttore { get; set; }
        public float prezzo { get; set; }
        public int categoria { get; set; }

        public int quantita { get; set; }

        public string posizione { get; set; }
    }
}
