using System;
using System.Collections.Generic;

namespace Kontenery.Klasy
{
    public class Kontenerowiec
    {
        public double MaksymalnaPredkosc { get; }
        public int MaksymalnaLiczbaKontenerow { get; }
        public double MaksymalnaWagaKontenerow { get; }
        public double AktualnaWagaKontenerow { get; private set; }
        public List<Kontener> Kontenery { get; private set; }

        public Dictionary <string, double> ProduktyITemperatury { get; private set; }

        
        public Kontenerowiec(double maksymalnaPredkosc, int maksymalnaLiczbaKontenerow, double maksymalnaWagaKontenerow)
        {
            MaksymalnaPredkosc = maksymalnaPredkosc;
            MaksymalnaLiczbaKontenerow = maksymalnaLiczbaKontenerow;
            MaksymalnaWagaKontenerow = maksymalnaWagaKontenerow;
            AktualnaWagaKontenerow = 0;
            Kontenery = new List<Kontener>();
            ProduktyITemperatury = new Dictionary<string, double>();
        }

        public void ZaladujKontener(Kontener kontener)
        {
            if (Kontenery.Count >= MaksymalnaLiczbaKontenerow)
            {
                Console.WriteLine("Nie można załadować więcej kontenerów. Statek jest pełny.");
                return;
            }

            if (AktualnaWagaKontenerow + kontener.MasaLadunku > MaksymalnaWagaKontenerow)
            {
                Console.WriteLine("Przekroczono maksymalną wagę kontenerów. Nie można załadować więcej kontenerów.");
                return;
            }
            

            Kontenery.Add(kontener);
            AktualnaWagaKontenerow += kontener.MasaLadunku;
            Console.WriteLine($"Kontener o numerze seryjnym {kontener.NumerSeryjny} został załadowany na statek.");
        }


        
        
        public void UsunKontener(string numerSeryjny)
        {
            Kontener kontener = Kontenery.Find(k => k.NumerSeryjny == numerSeryjny);
            if (kontener != null)
            {
                Kontenery.Remove(kontener);
                AktualnaWagaKontenerow -= kontener.MasaLadunku;
                Console.WriteLine($"Kontener o numerze seryjnym {numerSeryjny} został usunięty ze statku.");
            }
            else
            {
                Console.WriteLine($"Nie można znaleźć kontenera o numerze seryjnym {numerSeryjny} na statku.");
            }
        }

        
        
        public void RozladujKontener(string numerSeryjny)
        {
            Kontener kontener = Kontenery.Find(k => k.NumerSeryjny == numerSeryjny);
            if (kontener != null)
            {
                kontener.OproznijKontener();
                AktualnaWagaKontenerow -= kontener.MasaLadunku;
                Console.WriteLine($"Kontener o numerze seryjnym {numerSeryjny} został rozładowany.");
            }
            else
            {
                Console.WriteLine($"Nie można znaleźć kontenera o numerze seryjnym {numerSeryjny} na statku.");
            }
        }

        
        
        public void ZastapKontener(string numerSeryjny, Kontener nowyKontener)
        {
            Kontener kontener = Kontenery.Find(k => k.NumerSeryjny == numerSeryjny);
            if (kontener != null)
            {
                AktualnaWagaKontenerow -= kontener.MasaLadunku;
                AktualnaWagaKontenerow += nowyKontener.MasaLadunku;
                int index = Kontenery.IndexOf(kontener);
                Kontenery[index] = nowyKontener;
                Console.WriteLine($"Kontener o numerze seryjnym {numerSeryjny} został zastąpiony nowym kontenerem.");
            }
            else
            {
                Console.WriteLine($"Nie można znaleźć kontenera o numerze seryjnym {numerSeryjny} na statku.");
            }
        }

        
        public void PrzeniesKontenerMiedzyStatkami(string numerSeryjny, Kontenerowiec innyStatek)
        {
            Kontener kontener = Kontenery.Find(k => k.NumerSeryjny == numerSeryjny);
            if (kontener != null)
            {
                AktualnaWagaKontenerow -= kontener.MasaLadunku;
                innyStatek.ZaladujKontener(kontener);
                Kontenery.Remove(kontener);
                Console.WriteLine($"Kontener o numerze seryjnym {numerSeryjny} został przeniesiony na inny statek.");
            }
            else
            {
                Console.WriteLine($"Nie można znaleźć kontenera o numerze seryjnym {numerSeryjny} na statku.");
            }
        }

        
        public void WyswietlInformacje()
        {
            Console.WriteLine($"Aktualna liczba kontenerów na statku: {Kontenery.Count}");
            Console.WriteLine($"Aktualna waga kontenerów na statku: {AktualnaWagaKontenerow} ton");
            
            foreach (var kontener in Kontenery)
            {
                kontener.WyswietlInformacje();
            }
        }
        
        
    }
}
