﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.42000
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientWCF.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DipendenteServer", Namespace="http://schemas.datacontract.org/2004/07/WCF_Server")]
    [System.SerializableAttribute()]
    public partial class DipendenteServer : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool amministratoreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string cognomeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nomeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string passwordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string telefonoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool amministratore {
            get {
                return this.amministratoreField;
            }
            set {
                if ((this.amministratoreField.Equals(value) != true)) {
                    this.amministratoreField = value;
                    this.RaisePropertyChanged("amministratore");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string cognome {
            get {
                return this.cognomeField;
            }
            set {
                if ((object.ReferenceEquals(this.cognomeField, value) != true)) {
                    this.cognomeField = value;
                    this.RaisePropertyChanged("cognome");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nome {
            get {
                return this.nomeField;
            }
            set {
                if ((object.ReferenceEquals(this.nomeField, value) != true)) {
                    this.nomeField = value;
                    this.RaisePropertyChanged("nome");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string password {
            get {
                return this.passwordField;
            }
            set {
                if ((object.ReferenceEquals(this.passwordField, value) != true)) {
                    this.passwordField = value;
                    this.RaisePropertyChanged("password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string telefono {
            get {
                return this.telefonoField;
            }
            set {
                if ((object.ReferenceEquals(this.telefonoField, value) != true)) {
                    this.telefonoField = value;
                    this.RaisePropertyChanged("telefono");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ListaProdottiServer", Namespace="http://schemas.datacontract.org/2004/07/WCF_Server")]
    [System.SerializableAttribute()]
    public partial class ListaProdottiServer : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ClientWCF.ServiceReference1.ProdottoServer[] listaProductsField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ClientWCF.ServiceReference1.ProdottoServer[] listaProducts {
            get {
                return this.listaProductsField;
            }
            set {
                if ((object.ReferenceEquals(this.listaProductsField, value) != true)) {
                    this.listaProductsField = value;
                    this.RaisePropertyChanged("listaProducts");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProdottoServer", Namespace="http://schemas.datacontract.org/2004/07/WCF_Server")]
    [System.SerializableAttribute()]
    public partial class ProdottoServer : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int categoriaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nomeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string posizioneField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float prezzoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int produttoreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int quantitaField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int categoria {
            get {
                return this.categoriaField;
            }
            set {
                if ((this.categoriaField.Equals(value) != true)) {
                    this.categoriaField = value;
                    this.RaisePropertyChanged("categoria");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nome {
            get {
                return this.nomeField;
            }
            set {
                if ((object.ReferenceEquals(this.nomeField, value) != true)) {
                    this.nomeField = value;
                    this.RaisePropertyChanged("nome");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string posizione {
            get {
                return this.posizioneField;
            }
            set {
                if ((object.ReferenceEquals(this.posizioneField, value) != true)) {
                    this.posizioneField = value;
                    this.RaisePropertyChanged("posizione");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float prezzo {
            get {
                return this.prezzoField;
            }
            set {
                if ((this.prezzoField.Equals(value) != true)) {
                    this.prezzoField = value;
                    this.RaisePropertyChanged("prezzo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int produttore {
            get {
                return this.produttoreField;
            }
            set {
                if ((this.produttoreField.Equals(value) != true)) {
                    this.produttoreField = value;
                    this.RaisePropertyChanged("produttore");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int quantita {
            get {
                return this.quantitaField;
            }
            set {
                if ((this.quantitaField.Equals(value) != true)) {
                    this.quantitaField = value;
                    this.RaisePropertyChanged("quantita");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ListaDipendentiServer", Namespace="http://schemas.datacontract.org/2004/07/WCF_Server")]
    [System.SerializableAttribute()]
    public partial class ListaDipendentiServer : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ClientWCF.ServiceReference1.DipendenteServer[] listaDipendServerField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ClientWCF.ServiceReference1.DipendenteServer[] listaDipendServer {
            get {
                return this.listaDipendServerField;
            }
            set {
                if ((object.ReferenceEquals(this.listaDipendServerField, value) != true)) {
                    this.listaDipendServerField = value;
                    this.RaisePropertyChanged("listaDipendServer");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DoWork", ReplyAction="http://tempuri.org/IService1/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DoWork", ReplyAction="http://tempuri.org/IService1/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DoWork2", ReplyAction="http://tempuri.org/IService1/DoWork2Response")]
        void DoWork2();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DoWork2", ReplyAction="http://tempuri.org/IService1/DoWork2Response")]
        System.Threading.Tasks.Task DoWork2Async();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Login", ReplyAction="http://tempuri.org/IService1/LoginResponse")]
        ClientWCF.ServiceReference1.DipendenteServer Login(int id, string pswd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Login", ReplyAction="http://tempuri.org/IService1/LoginResponse")]
        System.Threading.Tasks.Task<ClientWCF.ServiceReference1.DipendenteServer> LoginAsync(int id, string pswd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getListaProdotti", ReplyAction="http://tempuri.org/IService1/getListaProdottiResponse")]
        ClientWCF.ServiceReference1.ListaProdottiServer getListaProdotti();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getListaProdotti", ReplyAction="http://tempuri.org/IService1/getListaProdottiResponse")]
        System.Threading.Tasks.Task<ClientWCF.ServiceReference1.ListaProdottiServer> getListaProdottiAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getProdById", ReplyAction="http://tempuri.org/IService1/getProdByIdResponse")]
        ClientWCF.ServiceReference1.ProdottoServer getProdById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getProdById", ReplyAction="http://tempuri.org/IService1/getProdByIdResponse")]
        System.Threading.Tasks.Task<ClientWCF.ServiceReference1.ProdottoServer> getProdByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getFreePos", ReplyAction="http://tempuri.org/IService1/getFreePosResponse")]
        string[] getFreePos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getFreePos", ReplyAction="http://tempuri.org/IService1/getFreePosResponse")]
        System.Threading.Tasks.Task<string[]> getFreePosAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getNomiCategorie", ReplyAction="http://tempuri.org/IService1/getNomiCategorieResponse")]
        string[] getNomiCategorie();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getNomiCategorie", ReplyAction="http://tempuri.org/IService1/getNomiCategorieResponse")]
        System.Threading.Tasks.Task<string[]> getNomiCategorieAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getNomiProduttori", ReplyAction="http://tempuri.org/IService1/getNomiProduttoriResponse")]
        string[] getNomiProduttori();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getNomiProduttori", ReplyAction="http://tempuri.org/IService1/getNomiProduttoriResponse")]
        System.Threading.Tasks.Task<string[]> getNomiProduttoriAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreaProdotto", ReplyAction="http://tempuri.org/IService1/CreaProdottoResponse")]
        bool CreaProdotto(ClientWCF.ServiceReference1.ProdottoServer ps);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreaProdotto", ReplyAction="http://tempuri.org/IService1/CreaProdottoResponse")]
        System.Threading.Tasks.Task<bool> CreaProdottoAsync(ClientWCF.ServiceReference1.ProdottoServer ps);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EliminaProdotto", ReplyAction="http://tempuri.org/IService1/EliminaProdottoResponse")]
        bool EliminaProdotto(ClientWCF.ServiceReference1.ProdottoServer ps);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EliminaProdotto", ReplyAction="http://tempuri.org/IService1/EliminaProdottoResponse")]
        System.Threading.Tasks.Task<bool> EliminaProdottoAsync(ClientWCF.ServiceReference1.ProdottoServer ps);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/updateProduct", ReplyAction="http://tempuri.org/IService1/updateProductResponse")]
        bool updateProduct(int id, int quant, string pos, int idDip, string desc, string date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/updateProduct", ReplyAction="http://tempuri.org/IService1/updateProductResponse")]
        System.Threading.Tasks.Task<bool> updateProductAsync(int id, int quant, string pos, int idDip, string desc, string date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreaUtente", ReplyAction="http://tempuri.org/IService1/CreaUtenteResponse")]
        bool CreaUtente(string nome, string cognome, string telefono, string pass, int ceo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreaUtente", ReplyAction="http://tempuri.org/IService1/CreaUtenteResponse")]
        System.Threading.Tasks.Task<bool> CreaUtenteAsync(string nome, string cognome, string telefono, string pass, int ceo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EliminaDipendente", ReplyAction="http://tempuri.org/IService1/EliminaDipendenteResponse")]
        bool EliminaDipendente(ClientWCF.ServiceReference1.DipendenteServer ds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EliminaDipendente", ReplyAction="http://tempuri.org/IService1/EliminaDipendenteResponse")]
        System.Threading.Tasks.Task<bool> EliminaDipendenteAsync(ClientWCF.ServiceReference1.DipendenteServer ds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ProductUpdateCeo", ReplyAction="http://tempuri.org/IService1/ProductUpdateCeoResponse")]
        bool ProductUpdateCeo(ClientWCF.ServiceReference1.ProdottoServer p1, int idUser, string date, string desc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ProductUpdateCeo", ReplyAction="http://tempuri.org/IService1/ProductUpdateCeoResponse")]
        System.Threading.Tasks.Task<bool> ProductUpdateCeoAsync(ClientWCF.ServiceReference1.ProdottoServer p1, int idUser, string date, string desc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getListaDipendenti", ReplyAction="http://tempuri.org/IService1/getListaDipendentiResponse")]
        ClientWCF.ServiceReference1.ListaDipendentiServer getListaDipendenti();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getListaDipendenti", ReplyAction="http://tempuri.org/IService1/getListaDipendentiResponse")]
        System.Threading.Tasks.Task<ClientWCF.ServiceReference1.ListaDipendentiServer> getListaDipendentiAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UserUpdateCeo", ReplyAction="http://tempuri.org/IService1/UserUpdateCeoResponse")]
        bool UserUpdateCeo(ClientWCF.ServiceReference1.DipendenteServer d1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UserUpdateCeo", ReplyAction="http://tempuri.org/IService1/UserUpdateCeoResponse")]
        System.Threading.Tasks.Task<bool> UserUpdateCeoAsync(ClientWCF.ServiceReference1.DipendenteServer d1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getUtenteById", ReplyAction="http://tempuri.org/IService1/getUtenteByIdResponse")]
        ClientWCF.ServiceReference1.DipendenteServer getUtenteById(int n);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getUtenteById", ReplyAction="http://tempuri.org/IService1/getUtenteByIdResponse")]
        System.Threading.Tasks.Task<ClientWCF.ServiceReference1.DipendenteServer> getUtenteByIdAsync(int n);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : ClientWCF.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<ClientWCF.ServiceReference1.IService1>, ClientWCF.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public void DoWork2() {
            base.Channel.DoWork2();
        }
        
        public System.Threading.Tasks.Task DoWork2Async() {
            return base.Channel.DoWork2Async();
        }
        
        public ClientWCF.ServiceReference1.DipendenteServer Login(int id, string pswd) {
            return base.Channel.Login(id, pswd);
        }
        
        public System.Threading.Tasks.Task<ClientWCF.ServiceReference1.DipendenteServer> LoginAsync(int id, string pswd) {
            return base.Channel.LoginAsync(id, pswd);
        }
        
        public ClientWCF.ServiceReference1.ListaProdottiServer getListaProdotti() {
            return base.Channel.getListaProdotti();
        }
        
        public System.Threading.Tasks.Task<ClientWCF.ServiceReference1.ListaProdottiServer> getListaProdottiAsync() {
            return base.Channel.getListaProdottiAsync();
        }
        
        public ClientWCF.ServiceReference1.ProdottoServer getProdById(int id) {
            return base.Channel.getProdById(id);
        }
        
        public System.Threading.Tasks.Task<ClientWCF.ServiceReference1.ProdottoServer> getProdByIdAsync(int id) {
            return base.Channel.getProdByIdAsync(id);
        }
        
        public string[] getFreePos() {
            return base.Channel.getFreePos();
        }
        
        public System.Threading.Tasks.Task<string[]> getFreePosAsync() {
            return base.Channel.getFreePosAsync();
        }
        
        public string[] getNomiCategorie() {
            return base.Channel.getNomiCategorie();
        }
        
        public System.Threading.Tasks.Task<string[]> getNomiCategorieAsync() {
            return base.Channel.getNomiCategorieAsync();
        }
        
        public string[] getNomiProduttori() {
            return base.Channel.getNomiProduttori();
        }
        
        public System.Threading.Tasks.Task<string[]> getNomiProduttoriAsync() {
            return base.Channel.getNomiProduttoriAsync();
        }
        
        public bool CreaProdotto(ClientWCF.ServiceReference1.ProdottoServer ps) {
            return base.Channel.CreaProdotto(ps);
        }
        
        public System.Threading.Tasks.Task<bool> CreaProdottoAsync(ClientWCF.ServiceReference1.ProdottoServer ps) {
            return base.Channel.CreaProdottoAsync(ps);
        }
        
        public bool EliminaProdotto(ClientWCF.ServiceReference1.ProdottoServer ps) {
            return base.Channel.EliminaProdotto(ps);
        }
        
        public System.Threading.Tasks.Task<bool> EliminaProdottoAsync(ClientWCF.ServiceReference1.ProdottoServer ps) {
            return base.Channel.EliminaProdottoAsync(ps);
        }
        
        public bool updateProduct(int id, int quant, string pos, int idDip, string desc, string date) {
            return base.Channel.updateProduct(id, quant, pos, idDip, desc, date);
        }
        
        public System.Threading.Tasks.Task<bool> updateProductAsync(int id, int quant, string pos, int idDip, string desc, string date) {
            return base.Channel.updateProductAsync(id, quant, pos, idDip, desc, date);
        }
        
        public bool CreaUtente(string nome, string cognome, string telefono, string pass, int ceo) {
            return base.Channel.CreaUtente(nome, cognome, telefono, pass, ceo);
        }
        
        public System.Threading.Tasks.Task<bool> CreaUtenteAsync(string nome, string cognome, string telefono, string pass, int ceo) {
            return base.Channel.CreaUtenteAsync(nome, cognome, telefono, pass, ceo);
        }
        
        public bool EliminaDipendente(ClientWCF.ServiceReference1.DipendenteServer ds) {
            return base.Channel.EliminaDipendente(ds);
        }
        
        public System.Threading.Tasks.Task<bool> EliminaDipendenteAsync(ClientWCF.ServiceReference1.DipendenteServer ds) {
            return base.Channel.EliminaDipendenteAsync(ds);
        }
        
        public bool ProductUpdateCeo(ClientWCF.ServiceReference1.ProdottoServer p1, int idUser, string date, string desc) {
            return base.Channel.ProductUpdateCeo(p1, idUser, date, desc);
        }
        
        public System.Threading.Tasks.Task<bool> ProductUpdateCeoAsync(ClientWCF.ServiceReference1.ProdottoServer p1, int idUser, string date, string desc) {
            return base.Channel.ProductUpdateCeoAsync(p1, idUser, date, desc);
        }
        
        public ClientWCF.ServiceReference1.ListaDipendentiServer getListaDipendenti() {
            return base.Channel.getListaDipendenti();
        }
        
        public System.Threading.Tasks.Task<ClientWCF.ServiceReference1.ListaDipendentiServer> getListaDipendentiAsync() {
            return base.Channel.getListaDipendentiAsync();
        }
        
        public bool UserUpdateCeo(ClientWCF.ServiceReference1.DipendenteServer d1) {
            return base.Channel.UserUpdateCeo(d1);
        }
        
        public System.Threading.Tasks.Task<bool> UserUpdateCeoAsync(ClientWCF.ServiceReference1.DipendenteServer d1) {
            return base.Channel.UserUpdateCeoAsync(d1);
        }
        
        public ClientWCF.ServiceReference1.DipendenteServer getUtenteById(int n) {
            return base.Channel.getUtenteById(n);
        }
        
        public System.Threading.Tasks.Task<ClientWCF.ServiceReference1.DipendenteServer> getUtenteByIdAsync(int n) {
            return base.Channel.getUtenteByIdAsync(n);
        }
    }
}
