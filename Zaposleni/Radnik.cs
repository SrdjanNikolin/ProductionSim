using System;

namespace ProductionSimulation.Zaposleni
{
    public class Radnik
    {
        public int Id {get; private set;}
        public string Ime {get; private set;}
        public string Zaduzenje {get; private set;}
        public int NadredjeniId {get; private set;}
        public Radnik(string ime, string zaduzenje, int id)
        {
            Id = id;
            Ime = ime;
            Zaduzenje = zaduzenje;
        }
        public Radnik(string ime, string zaduzenje, int id, int nadredjeni)
        {
            Id = id;
            Ime = ime;
            Zaduzenje = zaduzenje;
            NadredjeniId = nadredjeni;
        }
    }
}