using System;

namespace Kontenery.Klasy
{
    public class Kontener
    {
        public string NumerSeryjny { get; }
        public double MasaLadunku { get; set; }
        public double Wysokosc { get; }
        public double WagaWlasna { get; }
        public double Glebokosc { get; }
        public double MaksymalnaLadownosc { get; }

        private static int _licznik = 1;

        public Kontener(string numerSeryjny, double masaLadunku, double wysokosc, double wagaWlasna, double glebokosc, double maksymalnaLadownosc)
        {
            NumerSeryjny = numerSeryjny;
            MasaLadunku = masaLadunku;
            Wysokosc = wysokosc;
            WagaWlasna = wagaWlasna;
            Glebokosc = glebokosc;
            MaksymalnaLadownosc = maksymalnaLadownosc;

            NumerSeryjny = GenerujNumerSeryjny();
        }

        private string GenerujNumerSeryjny()
        {
            string rodzajKontenera = GetType().Name switch
            {
                nameof(KontenerNaPlyny) => "L",
                nameof(KontenerNaGaz) => "G",
                nameof(KontenerChlodniczy) => "C",
                _ => throw new NotImplementedException("Nieobsługiwany typ kontenera.")
            };

            return $"KON-{rodzajKontenera}-{_licznik++}";
        }


        public virtual void ZaladujLadunek(double masa)
        {
            if (masa > MaksymalnaLadownosc)
            {
                throw new PrzekroczeniePojemnosciWyjatek("Masa ladunku przekracza pojemność kontenera.");
            }
            else
            {
                MasaLadunku += masa;
            }
        }

        public virtual void OproznijKontener()
        {
            MasaLadunku = 0;
        }

        
        
        public void WyswietlInformacje()
        {
            Console.WriteLine($"Numer seryjny: {NumerSeryjny}");
            Console.WriteLine($"Masa ładunku: {MasaLadunku}");
            Console.WriteLine($"Wysokość: {Wysokosc}");
            Console.WriteLine($"Waga własna: {WagaWlasna}");
            Console.WriteLine($"Głębokość: {Glebokosc}");
            Console.WriteLine($"Maksymalna ładowność: {MaksymalnaLadownosc}");
        }

        
    }
}

