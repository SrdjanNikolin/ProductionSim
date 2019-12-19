using System;
using System.Collections.Generic;
using ProductionSimulation.ProdajnaMesta;
using ProductionSimulation.Proizvodi;
using ProductionSimulation.Zaposleni;
using System.Linq;
using System.IO;

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
        public void KreirajProizvod(int kolicina, int Id, string nazivProizvoda, int cena, int nadzornik)
        {
            //preimenuj
            int n = 0;
            if(kolicina == 0)
            {
                System.Console.WriteLine("Kolicina ne moze da bude 0.");
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
            using(StreamWriter writer = new StreamWriter("C:\\Users\\Srdjan\\Desktop\\Projects\\ProductionSimulation\\Logs\\KreiranProizvodLog.txt", true))
            {
                DateTime time = DateTime.Now;
                while(n < kolicina)
                {
                    listaProizvoda.Add(new Proizvod(Id, nazivProizvoda, cena));
                    writer.WriteLine($"Kreiran proizvod: Proizvod ID: [{Id}], Naziv: [{nazivProizvoda}], Fabrika: [{Naziv}], Vreme proizvodnje: [{time.ToString()}], Nadzornik: [{trenutniNadzornik}]");
                    n++;
                }
            }
        }
        public void Transport(ProdajnoMesto mesto, int[] zahtev, int nadzornik)
        {
            //preimenuj
            int n = 0;
            int i = 0;
            while(n < zahtev.Length)
            {
                while(i < zahtev[n])
                {
                    if(listaProizvoda.FirstOrDefault(p => p.Id == n+1) != null)
                    {
                        mesto.ListaProizvoda.Add(listaProizvoda.Find(p => p.Id == n+1));
                        var removeItem = listaProizvoda.First(p => p.Id == n+1);
                        listaProizvoda.Remove(removeItem);
                        i++;
                    }else
                    {
                        Console.WriteLine($"Nema vise proizvoda sa Id od {n+1}");
                        i = 0;
                        break;
                    }                   
                }
                i = 0;               
                n++;
            }
        }
    }
}