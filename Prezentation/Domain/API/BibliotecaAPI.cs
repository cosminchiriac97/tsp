using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;


using Domain.ModelAux;

namespace Domain
{
    public class BibliotecaAPI 
    {

        public static  bool AchizitieCarte(AchizitieCarte carti)
        {
            try
            {
                using (var context = new BibliotecaModelContainer())
                {
                    var autor = context.AUTORs.FirstOrDefault(pred => pred.Nume == carti.NumeAutor
                                                                      && pred.Prenume == carti.PrenumeAutor);

                    var gen = context.GENs.FirstOrDefault(pred => pred.Descriere == carti.Descriere);

                    if (autor == null)
                    {
                        autor = new AUTOR
                        {
                            Nume = carti.NumeAutor,
                            Prenume = carti.PrenumeAutor
                        };
                        context.AUTORs.Add(autor);
                    }
                  

                    if (gen == null)
                    {
                        gen = new GEN
                        {
                            Descriere = carti.Descriere
                        };
                        context.GENs.Add(gen);
                    }
               

     
                    for (var i = 0; i < carti.NumarCarti; i++)
                    {
                        var carte = new CARTE
                        {
                            AutorId = autor.AutorId,
                            GenId = gen.GenId,
                            Titlu = carti.Titlu
                        };

                        context.CARTEs.Add(carte);
                    }
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static CITITOR AddCititor(InregistrareCititor cititor)
        {
            try
            {
                using (var context = new BibliotecaModelContainer())
                {
                    var reader = context.CITITORs.FirstOrDefault(p =>
                        p.Prenume == cititor.Prenume && p.Nume == cititor.Nume && p.Adresa == cititor.Adresa &&
                        p.Email == cititor.Email);
                    if (reader == null)
                    {
                        var newCititor = new CITITOR
                        {
                            Nume = cititor.Nume,
                            Prenume = cititor.Prenume,
                            Adresa = cititor.Adresa,
                            Email = cititor.Email,
                            Stare = 0
                        };
                        context.CITITORs.Add(newCititor);
                        context.SaveChanges();
                        return newCititor;
                    }
                    return reader;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return null;
            }
        }

        public static List<CARTE> GetCarti(string descriere)
        {
            try
            {
                using (var context = new BibliotecaModelContainer())
                {
                    var gen = context.GENs.FirstOrDefault(p => p.Descriere == descriere);
                    if (gen == null)
                        return null;
                    var carti = context.CARTEs.Where(p => p.GenId == gen.GenId).GroupBy(p=>p.Titlu).Select(p=>p.FirstOrDefault()).ToList();      
                    return carti;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static bool ExistaCartea(string titlu, string autorNume, string autorPrenume)
        {
            try
            {
                using (var context = new BibliotecaModelContainer())
                {
                    var cartiDinBlioteca = context.CARTEs.Where(p => p.Titlu == titlu).ToList();
                    var autor = context.AUTORs.FirstOrDefault(p => p.Nume == autorNume && p.Prenume == autorPrenume);
                  
                    if (cartiDinBlioteca.Count != 0 && autor !=null)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static DateTime? EsteCarteaDisponibila(string autorNume,string autorPrenume, string titlu)
        {
            try
            {
                using (var context = new BibliotecaModelContainer())
                {
                    var autor = context.AUTORs.FirstOrDefault(p => p.Nume == autorNume && p.Prenume == autorPrenume);                
                    var cartiDinBlioteca = context.CARTEs.Where(p => p.Titlu == titlu && p.AutorId==autor.AutorId).ToList();
                   
                    foreach (var carte in cartiDinBlioteca)
                    {
                        var carteDisponibila = context.IMPRUMUTs.FirstOrDefault(p => p.CarteId == carte.CarteId && p.DataRestituire == null);
                        if (carteDisponibila == null)
                        {
                            return null;
                        }
                    }

                    var dataDisponibila = context.IMPRUMUTs.OrderBy(p => p.DataScadenta).FirstOrDefault();

                    return dataDisponibila.DataScadenta;

                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static bool ImprumutaCartea(CITITOR cititor, string titlu, string autorNume, string autorPrenume, int numerZile)
        {
            try
            {
                using (var context = new BibliotecaModelContainer())
                {
                    var autor = context.AUTORs.FirstOrDefault(p => p.Nume == autorNume && p.Prenume == autorPrenume);
                    var cartea = context.CARTEs.FirstOrDefault(p=>p.AutorId==autor.AutorId && p.Titlu == titlu);
                    if (autor == null || cartea == null)
                        return false;
                    var imprumut = new IMPRUMUT
                    {
                        CarteId = cartea.CarteId,
                        CititorId = cititor.CititorId,
                        DataImprumut = DateTime.Now,
                        DataScadenta = DateTime.Now.AddDays(numerZile)
                    };
                    context.IMPRUMUTs.Add(imprumut);
                    context.SaveChanges();
                    return true;
                }   


            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool PotRestituiiCartea(CITITOR cititor, int carteId)
        {
            try
            {
                using (var context = new BibliotecaModelContainer())
                {
                    var result = context.IMPRUMUTs.FirstOrDefault(p=>p.CarteId==carteId && p.CititorId==cititor.CititorId && p.DataRestituire == null);
                    if (result == null)
                        return false;
                    return true;
                }


            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool RestituieCarte(CITITOR cititor, int carteId, string textReview)
        {
            try
            {
                using (var context = new BibliotecaModelContainer())
                {
                    var result = context.IMPRUMUTs.FirstOrDefault(p => p.CarteId == carteId && p.CititorId == cititor.CititorId && p.DataRestituire == null);
                    if (result == null)
                        return false;
                    result.DataRestituire = DateTime.Now;
                    context.IMPRUMUTs.AddOrUpdate(result);

                    var imprumuturiPesteLimita = context.IMPRUMUTs
                        .Count(p => p.CititorId == cititor.CititorId && p.DataScadenta < p.DataRestituire);
                    if (imprumuturiPesteLimita > 2)
                    {
                        cititor.Stare = 1;
                        context.CITITORs.AddOrUpdate(cititor);
                    }

                    var review = new REVIEW
                    {
                        ImprumutId = result.ImprumutId,
                        Text = textReview
                    };
                    context.REVIEWs.Add(review);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<CITITOR> ArataCititoriDeLaPanaLa(DateTime deLa, DateTime panaLa)
        {
            try
            {
                using (var context = new BibliotecaModelContainer())
                {
                    var imprumuturi= context.IMPRUMUTs.Where(p =>
                        p.DataRestituire != null && p.DataImprumut >= deLa && p.DataRestituire <= panaLa).GroupBy(p => p.CititorId).Select(p => p.FirstOrDefault()).ToList();
                    List<CITITOR> list=new List<CITITOR>();
                    foreach (var imprumut in imprumuturi)
                    {
                        var cititor = context.CITITORs.FirstOrDefault(p=>p.CititorId == imprumut.CititorId);
                        if(cititor!=null)
                            list.Add(cititor);
                    }
                    return list;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<TopCarti> CeleMaiSolicitateCarti()
        {
            try
            {
                using (var context = new BibliotecaModelContainer())
                {
                    
                    var celeMaiCautate = context.IMPRUMUTs.GroupBy(p => p.Carti.Titlu).Select(p => new {Titlu=p.Key, Count = p.Count() }).ToArray();
                    celeMaiCautate = celeMaiCautate.OrderByDescending(p => p.Count).ToArray();
                    List<TopCarti> topCarti = new List<TopCarti>();
                    foreach (var carte in celeMaiCautate)
                    {
                        topCarti.Add(new TopCarti
                        {
                            Titlu = carte.Titlu,
                            Count = carte.Count
                        });
                    }
                    return topCarti;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<TopAutori> AutoriiCeiMaiCautati()
        {
            try
            {
                using (var context = new BibliotecaModelContainer())
                {

                    var celeMaiCautateCarti = context.IMPRUMUTs.GroupBy(p => p.Carti.Titlu).Select(p => new { Titlu = p.Key, Count = p.Count() }).ToArray();
                    var autori = context.AUTORs.ToList();
                    List<TopAutori> topAutori = new List<TopAutori>();
                    foreach (var autor in autori)
                    {
                        topAutori.Add(new TopAutori
                        {
                            Id = autor.AutorId,
                            Nume = autor.Nume,
                            Prenume = autor.Prenume,
                            Scor = 0
                        });
                    }

                    foreach (var carte in celeMaiCautateCarti)
                    {
                        var _carte = context.CARTEs.FirstOrDefault(p=>p.Titlu==carte.Titlu);
                        var index = topAutori.FindIndex(p => p.Id == _carte.AutorId);
                        if(_carte != null && index > 0)
                        {
                            topAutori[index].Scor = topAutori[index].Scor + carte.Count;
                        }
                    }
                    topAutori = topAutori.OrderByDescending(p => p.Scor).ToList();
                    return topAutori;

                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<TopGenuri> GenurileCeleMaiCautati()
        {
            try
            {
                using (var context = new BibliotecaModelContainer())
                {

                    var celeMaiCautateCarti = context.IMPRUMUTs.GroupBy(p => p.Carti.Titlu).Select(p => new { Titlu = p.Key, Count = p.Count() }).ToArray();
                    var genuri = context.GENs.ToList();
                    List<TopGenuri> topGenuri = new List<TopGenuri>();
                    foreach (var gen in genuri)
                    {
                        topGenuri.Add(new TopGenuri
                        {
                            Id = gen.GenId,
                            Name = gen.Descriere,
                            Scor = 0
                        });
                    }

                    foreach (var carte in celeMaiCautateCarti)
                    {
                        var _carte = context.CARTEs.FirstOrDefault(p => p.Titlu == carte.Titlu);
                        var index = topGenuri.FindIndex(p => p.Id == _carte.GenId);
                        if (_carte != null && index > 0)
                        {
                            topGenuri[index].Scor = topGenuri[index].Scor + carte.Count;
                        }
                    }
                    topGenuri = topGenuri.OrderByDescending(p => p.Scor).ToList();
                    return topGenuri;

                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<REVIEW> GetReviewsForABook(string bookTitle)
        {
            try
            {
                using (var context = new BibliotecaModelContainer())
                {
                    var carte = context.CARTEs.FirstOrDefault(p => p.Titlu == bookTitle);

                    var reviews = context.REVIEWs.Where(p=>p.Imprumut.CarteId == carte.CarteId).ToList();

                    return reviews;

                }
            }
            catch (Exception)
            {
                return null;
            }
        }

    }

    
  
}
