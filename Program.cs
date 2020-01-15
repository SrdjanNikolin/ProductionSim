using System;
using System.Collections.Generic;
using ProductionSimulation.Kompanije;
using ProductionSimulation.Proizvodi;
using ProductionSimulation.Potrosac;

namespace ProductionSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Kompanija kompanijaTest = new Kompanija();
            kompanijaTest.DodajFabriku("Asus");
            kompanijaTest.DodajProdajnoMesto("Gigatron");
            kompanijaTest.GetFabrika("Asus").DodajRadnika("Marko Markovic", "radnik", 1, 2);
            kompanijaTest.GetFabrika("Asus").DodajRadnika("Maja Miscevic", "nadzornik za proizvodnju", 2);
            kompanijaTest.GetFabrika("Asus").DodajRadnika("Nikola Nikolic", "nadzornik za transport", 3);
            kompanijaTest.GetProdajnoMesto("Gigatron").DodajZaposlenog("Petar Petrovski", "prodavac", 3);
            kompanijaTest.GetFabrika("Asus").KreirajProizvod(20, 1, "Monitor", 80, 2);
            kompanijaTest.GetFabrika("Asus").KreirajProizvod(12, 2, "Tastatura", 50, 2);
            kompanijaTest.GetFabrika("Asus").KreirajProizvod(30, 3, "Mis", 15, 3);
            Dictionary<int, int> zahtev = kompanijaTest.GetProdajnoMesto("Gigatron").ZahtevZaIsporuku();
            //TODO: dodati u zahtev ime prodajnog mesta i proveriti
            kompanijaTest.GetFabrika("Asus").Transport(kompanijaTest.GetProdajnoMesto("Gigatron"), zahtev, kompanijaTest.GetFabrika("Asus").DobaviRadnika(3));
            Kupac kupac = new Kupac("Stefan Simanic", 500, NacinPlacanja.Kes);
            kupac.Kupi(kompanijaTest.GetProdajnoMesto("Gigatron"), 1, kupac.NacinPlacanja);
            kupac.Kupi(kompanijaTest.GetProdajnoMesto("Gigatron"), 2, kupac.NacinPlacanja);
            kupac.Kupi(kompanijaTest.GetProdajnoMesto("Gigatron"), 3, kupac.NacinPlacanja);
            kupac.Kupi(kompanijaTest.GetProdajnoMesto("Gigatron"), 4, kupac.NacinPlacanja);
        }
    }
}