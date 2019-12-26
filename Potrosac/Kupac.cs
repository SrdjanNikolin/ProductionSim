
using System.Collections.Generic;
using System.Linq;
using ProductionSimulation.ProdajnaMesta;
using ProductionSimulation.Proizvodi;
using System;
using ProductionSimulation.Logger;

namespace ProductionSimulation.Potrosac
{
    public class Kupac
    {
        public string Ime {get; private set;}
        public int Dzeparac {get; private set;}
        public List<Proizvod> Korpa {get; set;}
        public NacinPlacanja NacinPlacanja { get; set; }
        public Kupac(string ime, int dzeparac, NacinPlacanja nacinPlacanja)
        {
            Korpa = new List<Proizvod>();
            Ime = ime;
            Dzeparac = dzeparac;
            NacinPlacanja = nacinPlacanja;
        }
        public void Kupi(ProdajnoMesto mesto, int proizvod, NacinPlacanja nacinPlacanja)
        {
            Proizvod trazenProizvod = mesto.ListaProizvoda.FirstOrDefault(p => p.Id == proizvod);
            if(trazenProizvod != null && trazenProizvod.Cena <= Dzeparac)
            {
                string message = $"Kupljen proizvod: Proizvod ID: [{proizvod}], Naziv mesta: [{mesto.Naziv}], Ime zaposlenog prodavca: [{mesto.ListaZaposlenih.FirstOrDefault(r => r.Zaduzenje == "prodavac").Ime}], Nacin placanja: [{nacinPlacanja.ToString()}], Ime kupca: [{Ime}]";

                Korpa.Add(trazenProizvod);
                Dzeparac -= trazenProizvod.Cena;
                mesto.ListaProizvoda.Remove(trazenProizvod);
                Log logger = new Log();
                DateTime time = DateTime.Now;
                logger.LogAction(time, "KupovinaLog", message);
            }
            else if(trazenProizvod == null)
            {              
                Console.WriteLine("Proizvod trenutno nije dostupan u prodavnici.");
            }
            else
            {
                Console.WriteLine("Nemate dovoljno sredstava.");
            }         
        }
    }
}