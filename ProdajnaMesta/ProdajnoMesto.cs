using System;
using System.Collections.Generic;
using ProductionSimulation.Proizvodi;
using ProductionSimulation.Zaposleni;
using ProductionSimulation.Validacija;
using ProductionSimulation.Logger;
using System.Text;

namespace ProductionSimulation.ProdajnaMesta
{
    public class ProdajnoMesto
    {
        public string Naziv {get; private set;}
        public List<Proizvod> ListaProizvoda {get; private set;}
        public List<Radnik> ListaZaposlenih {get; private set;}
        public ProdajnoMesto(string naziv)
        {
            ListaZaposlenih = new List<Radnik>();
            ListaProizvoda = new List<Proizvod>();
            Naziv = naziv;
        }
        public void DodajZaposlenog(string ime, string zaduzenje, int id, int nadredjeni = 0)
        {
            ListaZaposlenih.Add(new Radnik(ime, zaduzenje, id, nadredjeni));
        }
        public Dictionary<int, int> ZahtevZaIsporuku()
        {
            Dictionary<int, int> zahtev = new Dictionary<int, int>();
            bool checkInput = false;
            string input;
            int idProizvoda = 0;
            int kolicinaProizvoda = 0;
            ValidacijaProizvoda validacija = new ValidacijaProizvoda();
            do
            {
                validacija.Validacija(ref idProizvoda, ref kolicinaProizvoda);
                if (!zahtev.ContainsKey(idProizvoda))
                {
                    zahtev.Add(idProizvoda, kolicinaProizvoda);
                }
                else
                {
                    zahtev[idProizvoda] += kolicinaProizvoda;
                }
                Console.WriteLine("Nastaviti sa zahtevima? uneti da ili ne");
                do
                {
                    input = Console.ReadLine();
                    if (input != "da" && input != "ne")
                    {
                        continue;
                    }
                    else if (input == "da")
                    {
                        break;
                    }
                    else
                    {
                        checkInput = true;
                        break;
                    }
                } while (checkInput == false);
            } while (checkInput == false);

            //log
            DateTime time = DateTime.Now;
            Log logger = new Log();
            StringBuilder builder = new StringBuilder("Poslat je zahtev za: ");
            foreach(KeyValuePair<int, int> item in zahtev)
            {
                builder.Append($"[{item.Value}] proizvoda sa id [{item.Key}], ");
            }
            builder.Remove(builder.Length - 2, 2);
            logger.LogAction(time, "ZahtevLog", builder.ToString());
            return zahtev;
        }
    }
}