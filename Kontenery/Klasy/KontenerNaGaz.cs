namespace Kontenery.Klasy
{
    public class KontenerNaGaz : Kontener, IHazardNotifier
    {
        public double Cisnienie { get; }

        public KontenerNaGaz(string numerSeryjny, double masaLadunku, double wysokosc, double wagaWlasna, double glebokosc, double maksymalnaLadownosc, double cisnienie)
            : base("KON-G", masaLadunku, wysokosc, wagaWlasna, glebokosc, maksymalnaLadownosc)
        {
            Cisnienie = cisnienie;
        }

        public override void OproznijKontener()
        {
            MasaLadunku *= 0.05; 
        }

        
        public override void ZaladujLadunek(double masa)
        {
            if (masa > MaksymalnaLadownosc)
                throw new PrzekroczeniePojemnosciWyjatek("Masa ladunku przekracza pojemność kontenera.");

            base.ZaladujLadunek(masa);
        }

        
        public void WyswietlInformacje()
        {
            base.WyswietlInformacje();
            Console.WriteLine($"Cisnienie: {Cisnienie}");
        }
        
        
        public void Powiadom(string numerKontenera)
        {
            Console.WriteLine($"Notyfikacja: Kontener {numerKontenera} jest w niebezpieczeństwie.");
        }
    }
    
}


