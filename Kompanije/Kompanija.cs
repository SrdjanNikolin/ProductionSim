using System;
using System.Collections.Generic;
using ProductionSimulation.Fabrike;
using ProductionSimulation.ProdajnaMesta;

namespace ProductionSimulation.Kompanije
{
    public class Kompanija
    {
        public List<Fabrika> ListaFabrika {get; private set;}
        public List<ProdajnoMesto> ListaProdajnihMesta {get; private set;}
        public void DodajFabriku(string naziv)
        {
            ListaFabrika = new List<Fabrika>();
            ListaFabrika.Add(new Fabrika(naziv));
        }
        public void DodajProdajnoMesto(string naziv)
        {
            ListaProdajnihMesta = new List<ProdajnoMesto>();
            ListaProdajnihMesta.Add(new ProdajnoMesto(naziv));
        }
        public ProdajnoMesto GetProdajnoMesto(string naziv)
        {
            return ListaProdajnihMesta.Find(m => m.Naziv == naziv);
        }
        public Fabrika GetFabrika(string naziv)
        {
            return ListaFabrika.Find(f => f.Naziv == naziv);
        }
    }
}