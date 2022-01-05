using ClientWCF.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientWCF.Models
{
    public class Prodotto
    {
        public int id { get; set; }
        [Display(Name = "Nome")]
        public string nome { get; set; }
        [Display(Name = "Produttore")]
        public int produttore { get; set; }
        [Display(Name = "Prezzo")]
        public float prezzo { get; set; }
        [Display(Name = "Categoria")]
        public int categoria { get; set; }
        [Display(Name="Quantità")]
        public int quantità { get; set; }
        [Display(Name = "Posizione")]
        public string posizione { get; set; }

        //metodo per convertire da server a client
        public void convertiServerToCLient(ProdottoServer ds)
        {
            this.id = ds.id;
            this.nome = ds.nome;
            this.produttore = ds.produttore;
            this.prezzo = ds.prezzo;
            this.categoria = ds.categoria;
            this.quantità = ds.quantita;
            this.posizione = ds.posizione;
        }

        //metodo per convertire da client a server
        public ProdottoServer convertiClientToServer()
        {

            ProdottoServer ds = new ProdottoServer();
            ds.id = this.id;
            ds.nome = this.nome;
            ds.produttore = this.produttore;
            ds.prezzo = this.prezzo;
            ds.categoria = this.categoria;
            ds.quantita = this.quantità;
            ds.posizione = this.posizione;
            return ds;
        }
    }
}