using System;
using System.Collections.Generic;
using System.ServiceModel;
using BilioWcf.Contracts;
using Domain;
using Domain.ModelAux;


namespace BilioWcf.Services
{
  
    [ServiceContract]
    public interface IBiblioWcf
    {
        [OperationContract]
        bool AchizitieCarte(AchizitieCarte carti);
        [OperationContract]
        CITITOR AddCititor(InregistrareCititor cititor);
        [OperationContract]
        List<CARTE> GetCarti(string descriere);
        [OperationContract]
        bool ExistaCartea(string titlu, string autorNume, string autorPrenume);
        [OperationContract]
        DateTime? EsteCarteaDisponibila(string autorNume, string autorPrenume, string titlu);
        [OperationContract]
        bool ImprumutaCartea(CITITOR cititor, string titlu, string autorNume, string autorPrenume, int numerZile);
        [OperationContract]
        bool PotRestituiiCartea(CITITOR cititor, int carteId);
        [OperationContract]
        bool RestituieCarte(CITITOR cititor, int carteId, string textReview);
        [OperationContract]
        List<CITITOR> ArataCititoriDeLaPanaLa(DateTime deLa, DateTime panaLa);
        [OperationContract]
        List<TopCarti> CeleMaiSolicitateCarti();
        [OperationContract]
        List<TopAutori> AutoriiCeiMaiCautati();
        [OperationContract]
        List<TopGenuri> GenurileCeleMaiCautati();
        [OperationContract]
        List<REVIEW> GetReviewsForABook(string bookTitle);

    }

}
