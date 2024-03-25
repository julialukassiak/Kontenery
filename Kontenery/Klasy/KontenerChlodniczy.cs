using System;

namespace Kontenery.Klasy
{
    public class KontenerChlodniczy : Kontener
    {
        public string RodzajProduktu { get; }
        public double Temperatura { get; }

        public KontenerChlodniczy(string numerSeryjny, double masaLadunku, double wysokosc, double wagaWlasna, double glebokosc, double maksymalnaLadownosc, string rodzajProduktu, double temperatura)
            : base("KON-C", masaLadunku, wysokosc, wagaWlasna, glebokosc, maksymalnaLadownosc)
        {
            RodzajProduktu = rodzajProduktu;
            Temperatura = temperatura;
        }

        public override void ZaladujLadunek(double masa)
        {
            if (MasaLadunku + masa > MaksymalnaLadownosc)
                throw new PrzekroczeniePojemnosciWyjatek("Masa ladunku przekracza pojemność kontenera.");

            if (!string.IsNullOrEmpty(RodzajProduktu))
            {
                //czy produkt jest tego samego typu co już znajdujący się w kontenerze
                if (!string.Equals(RodzajProduktu, this.RodzajProduktu, StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("Kontener może przechowywać wyłącznie produkty tego samego typu.");
                }

                // Sprawdź, czy temperatura produktu jest odpowiednia dla kontenera
                if ((RodzajProduktu == "Banany" && Temperatura < 13.3) ||
                    (RodzajProduktu == "Czekolada" && Temperatura < 18) ||
                    (RodzajProduktu == "Ryba" && Temperatura < 2) ||
                    (RodzajProduktu == "Mieso" && Temperatura < -15) ||
                    (RodzajProduktu == "Lody" && Temperatura < -18) ||
                    (RodzajProduktu == "Mrozona pizza" && Temperatura < -30) ||
                    (RodzajProduktu == "Ser" && Temperatura < 7.2) ||
                    (RodzajProduktu == "Kielbasa" && Temperatura < 5) ||
                    (RodzajProduktu == "Maslo" && Temperatura < 20.5) ||
                    (RodzajProduktu == "Jajka" && Temperatura < 19))
                {
                    throw new InvalidOperationException($"Temperatura kontenera jest zbyt niska dla produktu: {RodzajProduktu}.");
                }

            }

            base.ZaladujLadunek(masa);
        }
        
        
        
        public void WyswietlInformacje()
        {
            base.WyswietlInformacje();
            Console.WriteLine($"Rodzaj produktu: {RodzajProduktu}");
            Console.WriteLine($"Temperatura: {Temperatura}");
        }
        
        
    }
}