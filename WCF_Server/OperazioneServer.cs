using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Server
{
    public class OperazioneServer
    {
        public OperazioneServer()
        {

        }

        public OperazioneServer(int ido, int idd, DateTime d, string desc, int idp)
        {
            this.idOperazione = ido;
            this.idDipendente = idd;
            this.data = d;
            this.descrizione = desc;
            this.idProdotto = idp;
        }
        public int idOperazione { get; set; }
        public int idDipendente { get; set; }
        public DateTime data { get; set; }
        public string descrizione { get; set; }
        public int idProdotto { get; set; }
    }
}
