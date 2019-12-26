using System;
using System.Collections.Generic;
using ProductionSimulation.ProdajnaMesta;
using ProductionSimulation.Proizvodi;
using ProductionSimulation.Zaposleni;
using System.Linq;
using ProductionSimulation.Logger;
using System.Text;

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
        //TODO: validacija za dodavanje i dobavljanje radnika
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
            if(kolicina == 0)
            {
                Console.WriteLine("Kolicina ne moze da bude 0.");
                return;
            }
            int proizvodCount = 0;
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
            while (proizvodCount < kolicina)
            {
                listaProizvoda.Add(new Proizvod(id, nazivProizvoda, cena));
                logger.LogAction(time, "ProizvodnjaLog", message);
                proizvodCount++;
            }
        }
        public void Transport(ProdajnoMesto mesto, Dictionary<int, int> zahtev, Radnik nadzornik)
        {
            int kolicina = 0;
            StringBuilder message = new StringBuilder($"Transport: Naziv fabrike: [{Naziv}], Naziv odredista: [{mesto.Naziv}], Nadzornik: [{nadzornik.Ime}], proizvodi: ");
            StringBuilder imeProizvoda = new StringBuilder();
            
            foreach(KeyValuePair<int, int> item in zahtev)
            {
                while(kolicina < item.Value)
                {
                    if(listaProizvoda.FirstOrDefault(p => p.Id == item.Key) != null)
                    {
                        mesto.ListaProizvoda.Add(listaProizvoda.Find(p => p.Id == item.Key));
                        if (!imeProizvoda.Equals(listaProizvoda.Find(p => p.Id == item.Key).Naziv))
                        {
                            imeProizvoda.Clear();
                            imeProizvoda.Append(listaProizvoda.Find(p => p.Id == item.Key).Naziv);
                        }
                        var removeItem = listaProizvoda.First(p => p.Id == item.Key);
                        listaProizvoda.Remove(removeItem);
                        kolicina++;
                    }else
                    {
                        Console.WriteLine($"Nema vise proizvoda sa Id od {item.Key}");
                        break;
                    }
                }
                if(kolicina != 0)
                {
                    message.Append($"[{kolicina}] x [{imeProizvoda.ToString()}], ");
                }              
                kolicina = 0;
            }
            if(imeProizvoda.Length > 0)
            {
                Log logger = new Log();
                DateTime time = DateTime.Now;
                logger.LogAction(time, "TransportLog", message.ToString());
            }
        }
    }
}