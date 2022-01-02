using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Server
{
    public class DipendenteServer
    {
        public DipendenteServer()
        {

        }

        public DipendenteServer(int ids, string n, string cogn, string tel, string psw, bool ceo)
        {
            this.id = ids;
            this.nome = n;
            this.cognome = cogn;
            this.telefono = tel;
            this.password = psw;
            this.amministratore = ceo;
        }

        public int id { get; set; }


        public string nome { get; set; }


        public string cognome { get; set; }


        public string telefono { get; set; }


        public string password { get; set; }

        public bool amministratore { get; set; }
    }
}
