using System;
using System.Collections.Generic;
using Domain;
using Domain.ModelAux;

namespace BilioWcf.Services
{

    public class BiblioWcf : IBiblioWcf
    {
        public bool AchizitieCarte(AchizitieCarte carti)
        {
           return  BibliotecaAPI.AchizitieCarte(carti);
        }

        public CITITOR AddCititor(InregistrareCititor cititor)
        {
            return BibliotecaAPI.AddCititor(cititor);
        }

        public List<CITITOR> ArataCititoriDeLaPanaLa(DateTime deLa, DateTime panaLa)
        {
            return BibliotecaAPI.ArataCititoriDeLaPanaLa(deLa, panaLa);
        }

        public List<TopAutori> AutoriiCeiMaiCautati()
        {
            return BibliotecaAPI.AutoriiCeiMaiCautati();
        }

        public List<TopCarti> CeleMaiSolicitateCarti()
        {
            return BibliotecaAPI.CeleMaiSolicitateCarti();
        }

        public DateTime? EsteCarteaDisponibila(string autorNume, string autorPrenume, string titlu)
        {
            return BibliotecaAPI.EsteCarteaDisponibila(autorNume, autorPrenume, titlu);
        }

        public bool ExistaCartea(string titlu, string autorNume, string autorPrenume)
        {
            return BibliotecaAPI.ExistaCartea(titlu, autorNume, autorPrenume);
        }

        public List<TopGenuri> GenurileCeleMaiCautati()
        {
            return BibliotecaAPI.GenurileCeleMaiCautati();
        }

        public List<CARTE> GetCarti(string descriere)
        {
            return BibliotecaAPI.GetCarti(descriere);
        }

        public List<REVIEW> GetReviewsForABook(string bookTitle)
        {
            return BibliotecaAPI.GetReviewsForABook(bookTitle);
        }

        public bool ImprumutaCartea(CITITOR cititor, string titlu, string autorNume, string autorPrenume, int numerZile)
        {
            return BibliotecaAPI.ImprumutaCartea(cititor, titlu, autorNume, autorPrenume, numerZile);
        }

        public bool PotRestituiiCartea(CITITOR cititor, int carteId)
        {
            return BibliotecaAPI.PotRestituiiCartea(cititor, carteId);
        }

        public bool RestituieCarte(CITITOR cititor, int carteId, string textReview)
        {
            return BibliotecaAPI.RestituieCarte(cititor, carteId, textReview);
        }
    }
}
