using System;

namespace Kontenery.Klasy
{
    public class KontenerNaPlyny : Kontener, IHazardNotifier
    {
        public string RodzajLadunku { get; }
        public KontenerNaPlyny(string numerSeryjny, double masaLadunku, double wysokosc, double wagaWlasna, double glebokosc, double maksymalnaLadownosc, string rodzajLadunku)
            : base("KON-L", masaLadunku, wysokosc, wagaWlasna, glebokosc, maksymalnaLadownosc)
        {
            RodzajLadunku = rodzajLadunku;
        }

        public override void ZaladujLadunek(double masa)
        {
            if (MasaLadunku + masa > MaksymalnaLadownosc)
                throw new PrzekroczeniePojemnosciWyjatek("Masa ladunku przekracza pojemność kontenera.");

            if (masa > MaksymalnaLadownosc * 0.9 && !IsHazardous())
                throw new InvalidOperationException("Próba załadowania zbyt dużej ilości niebezpiecznego ładunku.");

            if (masa > MaksymalnaLadownosc * 0.5 && IsHazardous())
                throw new InvalidOperationException("Próba załadowania zbyt dużej ilości niebezpiecznego ładunku.");

            base.ZaladujLadunek(masa);
        }

        public bool IsHazardous()
        {
            string[] niebezpieczneLadunki = { "gaz", "ropa", "paliwo" }; 
            
            foreach (var ladunek in niebezpieczneLadunki)
            {
                if (RodzajLadunku.ToLower().Contains(ladunek))
                {
                    return true;
                }
            }
            return false;
        }


        public void WyswietlInformacje()
        {
            base.WyswietlInformacje();
            Console.WriteLine($"Rodzaj ładunku: {RodzajLadunku}");
        }
        

        public void Powiadom(string numerKontenera)
        {
            Console.WriteLine($"Notyfikacja: Kontener {numerKontenera} jest w niebezpieczeństwie.");
        }
    }
}