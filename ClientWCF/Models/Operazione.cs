using ClientWCF.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientWCF.Models
{
    public class Operazione
    {
        [Display(Name = "ID")]
        public int idOperazione { get; set; }
        [Display(Name = "ID dipendente")]
        public int idDipendente { get; set; }
        [Display(Name = "Data")]
        public DateTime data { get; set; }
        [Display(Name = "Descrizione")]
        public string descrizione { get; set; }
        [Display(Name = "ID prodotto")]
        public int idProdotto { get; set; }


        public void convertiServerToCLient(OperazioneServer os)
        {
            this.idOperazione = os.idOperazione;
            this.idDipendente = os.idDipendente;
            this.data = os.data;
            this.descrizione = os.descrizione;
            this.idProdotto = os.idProdotto;
        }
    }
}