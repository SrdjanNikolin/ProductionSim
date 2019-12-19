using System;
namespace ProductionSimulation.Proizvodi
{
    public class Proizvod : AbstractProizvod
    {
        public override int Id { get; set;}
        public override string Naziv { get; set;}
        public override int Cena { get; set;}
        public Proizvod(int id, string naziv, int cena)
        {
            Id = id;
            Naziv = naziv;
            Cena = cena;
        }
    }
}