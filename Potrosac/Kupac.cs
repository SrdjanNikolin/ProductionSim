
using System.Collections.Generic;
using System.Linq;
using ProductionSimulation.ProdajnaMesta;
using ProductionSimulation.Proizvodi;
using System;

namespace ProductionSimulation.Potrosac
{
    public class Kupac
    {
        public string Ime {get; private set;}
        public int Dzeparac {get; private set;}
        public List<Proizvod> Korpa {get; set;}
        public NacinPlacanja NacinPlacanja {get;}
        public Kupac(string ime, int dzeparac)
        {
            Korpa = new List<Proizvod>();
            Ime = ime;
            Dzeparac = dzeparac;
        }
        public void Kupi(ProdajnoMesto mesto, int proizvod, NacinPlacanja nacinPlacanja)
        {
            Proizvod trazenProizvod = mesto.ListaProizvoda.First(p => p.Id == proizvod);
            if(trazenProizvod != null && trazenProizvod.Cena <= Dzeparac)
            {
                Korpa.Add(trazenProizvod);
                Dzeparac -= trazenProizvod.Cena;
                mesto.ListaProizvoda.Remove(trazenProizvod);
            }
            else if(trazenProizvod.Cena > Dzeparac)
            {
                Console.WriteLine("Nemate dovoljno sredstava.");
            }
            else
            {
                Console.WriteLine("Proizvod trenutno nije dostupan.");
            }
            Console.WriteLine($"{mesto.ListaProizvoda.Find(p => p.Id ==1).Naziv}, {nacinPlacanja}");
        }
    }
}