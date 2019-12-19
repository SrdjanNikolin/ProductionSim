using System;

namespace ProductionSimulation.Proizvodi
{
    public abstract class AbstractProizvod
    {
        public abstract int Id {get; set;}
        public abstract string Naziv {get; set;}
        public abstract int Cena {get; set;}
    }
}