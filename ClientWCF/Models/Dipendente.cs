using ClientWCF.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientWCF.Models
{
    public class Dipendente
    {
        [Required]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Display(Name = "Cognome")]
        public string cognome { get; set; }

        [Display(Name = "Telefono")]
        public string telefono { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Display(Name = "Amministratore")]
        public bool amministratore { get; set; }

        //metodo per convertire da server a client
        public void convertiServerToCLient(DipendenteServer ds)
        {
            this.id = ds.id;
            this.nome = ds.nome;
            this.password = ds.password;
            this.cognome = ds.cognome;
            this.telefono = ds.telefono;
            this.amministratore = ds.amministratore;
        }

        //metodo per convertire da client a server
        public DipendenteServer convertiClientToServer()
        {

            DipendenteServer ds = new DipendenteServer();

            ds.id = this.id;
            ds.nome = this.nome;
            ds.cognome = this.cognome;
            ds.telefono = this.telefono;
            ds.password = this.password;
            ds.amministratore = this.amministratore;

            return ds;
        }

    }
}