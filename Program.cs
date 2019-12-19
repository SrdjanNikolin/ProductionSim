using System;
using System.Collections.Generic;
using ProductionSimulation.Kompanije;
using ProductionSimulation.Proizvodi;
using ProductionSimulation.Potrosac;

namespace ProductionSimulation
{
    class Program
    {
        //Napisati metode da dobavim fabriku i prodajno mesto
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            // Kompanija kompanija = new Kompanija();
            // kompanija.DodajFabriku("TestFabrika");
            // kompanija.DodajProdajnoMesto("TestMesto");
            // kompanija.GetFabrika("TestFabrika").DodajRadnika("Maja", "Radnik", 1);
            // kompanija.GetFabrika("TestFabrika").KreirajProizvod(5,1,"Monitor", 80, 1);
            // kompanija.GetFabrika("TestFabrika").KreirajProizvod(3,2,"Tastatura", 30, 1);
            // int[] zahtevi = kompanija.GetProdajnoMesto("TestMesto").ZahtevVersion1(8, 3);
            // kompanija.GetFabrika("TestFabrika").Transport(kompanija.GetProdajnoMesto("TestMesto"), zahtevi, 1);     
            // List<Proizvod> listaProizvoda = kompanija.GetProdajnoMesto("TestMesto").ListaProizvoda;
            //new
            Kompanija kompanijaTest = new Kompanija();
            kompanijaTest.DodajFabriku("Asus");
            kompanijaTest.DodajProdajnoMesto("Gigatron");
            kompanijaTest.GetFabrika("Asus").DodajRadnika("Marko Markovic", "radnik", 1, 2);
            kompanijaTest.GetFabrika("Asus").DodajRadnika("Maja Miscevic", "nadzornik za proizvodnju", 2);
            kompanijaTest.GetFabrika("Asus").DodajRadnika("Nikola Nikolic", "nadzornik za transport", 3);
            kompanijaTest.GetProdajnoMesto("Gigatron").DodajZaposlenog("Petar Petrovski", "prodavac", 3);
            kompanijaTest.ListaFabrika.Find(f => f.Naziv == "Asus").KreirajProizvod(20, 1, "Monitor", 80, 2);
            int[] zahtev = kompanijaTest.GetProdajnoMesto("Gigatron").ZahtevVersion1(10, 50);
            kompanijaTest.ListaFabrika.Find(f => f.Naziv == "Asus").Transport(kompanijaTest.GetProdajnoMesto("Gigatron"), zahtev, 3);
            Kupac kupac = new Kupac("Stefan Simanic", 500);
            kupac.Kupi(kompanijaTest.GetProdajnoMesto("Gigatron"), 1, NacinPlacanja.Kes);

        }
    }
}