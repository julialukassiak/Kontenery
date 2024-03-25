using System;
using System.Collections.Generic;

namespace Kontenery.Klasy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tworzenie kontenerów różnych typów
            KontenerNaPlyny kontenerPlyny1 = new KontenerNaPlyny("KON-L-1", 2.5, 1.8, 2.0, 1.5, 1000, "mleko");
            KontenerNaGaz kontenerGaz1 = new KontenerNaGaz("KON-G-1", 2.2, 1.6, 1.8, 2.0, 1000,100);
            KontenerChlodniczy kontenerChlodniczy1 = new KontenerChlodniczy("KON-C-1", 1500, 2.0, 1.5, 2.2, 1000, "Banany", 12.5);

            // Utworzenie statku
            Kontenerowiec kontenerowiec1 = new Kontenerowiec(100, 100, 12);
            Kontenerowiec kontenerowiec2 = new Kontenerowiec(2500, 18, 90);
            

            // Załadowanie ładunku do kontenerów
            kontenerPlyny1.ZaladujLadunek(50);
            kontenerGaz1.ZaladujLadunek(100);
            kontenerChlodniczy1.ZaladujLadunek(100);

            // Utworzenie listy kontenerów
            List<Kontener> listaKontenerow = new List<Kontener>();
            listaKontenerow.Add(kontenerPlyny1);
            listaKontenerow.Add(kontenerGaz1);
            listaKontenerow.Add(kontenerChlodniczy1);
            
            // Załadowanie kontenera na statek
            kontenerowiec1.ZaladujKontener(kontenerPlyny1);
            
            // Załadowanie listy kontenerów na statek
            foreach (var kontener in listaKontenerow)
            {
                kontenerowiec1.ZaladujKontener(kontener);
            }
            
            // Usunięcie kontenera ze statku
            kontenerowiec1.UsunKontener("KON-P-1");

            // Rozładowanie kontenera
            kontenerowiec1.RozladujKontener("KON-G-1");

            //Zastąpienie kontenera na statku o danym numerze innymkontenerem
            KontenerNaGaz nowyKontenerGaz = new KontenerNaGaz("KON-G-2", 1.8, 1.6, 1.8, 2.0, 3.0, 50);
            kontenerowiec1.ZastapKontener("KON-G-1", nowyKontenerGaz);
            
            // Przeniesienie kontenera między statkami
            kontenerowiec1.PrzeniesKontenerMiedzyStatkami("KON-L-1", kontenerowiec2);

            // Wypisanie informacji o danym kontenerze
            kontenerPlyny1.WyswietlInformacje();
            kontenerGaz1.WyswietlInformacje();
            kontenerChlodniczy1.WyswietlInformacje();
            
            // Wypisanie informacji o danym statku i jego ładunku
            kontenerowiec1.WyswietlInformacje();
            kontenerowiec2.WyswietlInformacje();
            
        }
    }
}