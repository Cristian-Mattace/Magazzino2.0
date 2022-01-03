using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Server
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di interfaccia "IService1" nel codice e nel file di configurazione contemporaneamente.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void DoWork();


        [OperationContract]
        DipendenteServer Login(int id, string pswd);

        [OperationContract]
        ListaProdottiServer getListaProdotti();

        [OperationContract]
        ProdottoServer getProdById(int id);

        [OperationContract]
        List<String> getFreePos();

        [OperationContract]
        List<String> getNomiCategorie();

        [OperationContract]
        List<String> getNomiProduttori();

        [OperationContract]
        bool CreaProdotto(ProdottoServer ps);

        [OperationContract]
        bool EliminaProdotto(ProdottoServer ps);

        [OperationContract]
        bool updateProduct(ProdottoServer p, int idDip, string desc, string date);

        [OperationContract]
        bool CreaUtente(DipendenteServer ds);

        [OperationContract]
        bool EliminaDipendente(DipendenteServer ds);

        [OperationContract]
        bool ProductUpdateCeo(ProdottoServer p1, int idUser, string date, string desc);

        [OperationContract]
        ListaDipendentiServer getListaDipendenti();

        [OperationContract]
        bool UserUpdateCeo(DipendenteServer d1);

        [OperationContract]
        DipendenteServer getUtenteById(int n);

        [OperationContract]
        List<string> getProductInExhaustion();

    }
}
