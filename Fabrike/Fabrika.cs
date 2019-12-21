using System;
using System.Collections.Generic;
using ProductionSimulation.ProdajnaMesta;
using ProductionSimulation.Proizvodi;
using ProductionSimulation.Zaposleni;
using System.Linq;
using ProductionSimulation.Logger;

namespace ProductionSimulation.Fabrike
{
    public class Fabrika
    {
        public string Naziv {get; private set;}
        public List<Radnik> ListaRadnika {get; private set;}
        private List<Proizvod> listaProizvoda = new List<Proizvod>();
        public Fabrika(string naziv)
        {
            listaProizvoda = new List<Proizvod>();
            ListaRadnika = new List<Radnik>();
            Naziv = naziv;
        }
        public void DodajRadnika(string ime, string zaduzenje, int id, int nadredjeni = 0)
        {
            ListaRadnika.Add(new Radnik(ime, zaduzenje, id, nadredjeni));
        }
        public Radnik DobaviRadnika(int id)
        {
            return ListaRadnika.Find(r => r.Id == id);
        }
        public void KreirajProizvod(int kolicina, int id, string nazivProizvoda, int cena, int nadzornik)
        {
            //preimenuj
            int n = 0;
            if(kolicina == 0)
            {
                Console.WriteLine("Kolicina ne moze da bude 0.");
                return;
            }                       
            string trenutniNadzornik;
            if(ListaRadnika.Find(r => r.Id == nadzornik) != null)
            {
                trenutniNadzornik = ListaRadnika.Find(r => r.Id == nadzornik).Ime;
            }
            else
            {
                trenutniNadzornik = "Nadzornik nije u sistemu.";
            }
            Log logger = new Log();
            DateTime time = DateTime.Now;           
            string message = $"Kreiran proizvod: Proizvod ID: [{id}], Naziv: [{nazivProizvoda}], Fabrika: [{Naziv}], Nadzornik: [{trenutniNadzornik}]";
            while (n < kolicina)
            {
                listaProizvoda.Add(new Proizvod(id, nazivProizvoda, cena));
                logger.LogAction(time, "ProizvodnjaLog", message);
                n++;
            }
        }
        public void Transport(ProdajnoMesto mesto, Dictionary<int, int> zahtev, int nadzornik)
        {
            //preimenuj
            int kolicina = 0;
            foreach(KeyValuePair<int, int> item in zahtev)
            {
                while(kolicina < item.Value)
                {
                    if(listaProizvoda.FirstOrDefault(p => p.Id == item.Key) != null)
                    {
                        mesto.ListaProizvoda.Add(listaProizvoda.Find(p => p.Id == item.Key));
                        var removeItem = listaProizvoda.First(p => p.Id == item.Key);
                        listaProizvoda.Remove(removeItem);
                        kolicina++;
                    }else
                    {
                        Console.WriteLine($"Nema vise proizvoda sa Id od {item.Key}");
                        kolicina = 0;
                        break;
                    }
                }
                kolicina = 0;
            }
        }
    }
}