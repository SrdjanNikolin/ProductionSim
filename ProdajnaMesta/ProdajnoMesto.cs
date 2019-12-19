using System;
using System.Collections.Generic;
using ProductionSimulation.Proizvodi;
using ProductionSimulation.Zaposleni;

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
        private int[] Zahtev() //Open Closed Principle, pogledati
        {
            int[] order = new int[2];
            Console.WriteLine("Molimo vas izaberite opcije: 1.Dodati monitore, 2. Dodati Tastature, 3. Exit");
            string input;
            int result;
            int kolicina;
            do
            {
                Console.Write("Izaberite opciju: ");
                input = Console.ReadLine();
                bool opcija = Int32.TryParse(input, out result);
                if(result == 1)
                {
                    Console.Write("Unesite zeljenu kolicinu monitora: ");
                    input = Console.ReadLine();
                    bool provera = Int32.TryParse(input, out kolicina);
                    if(provera != false)
                    {
                        order[0] =+ kolicina;
                    }else
                    {
                        Console.WriteLine("Unesite odgovarajucu kolicinu.");
                    }
                }
            }while(result != 3);
            return order;      
        }
        public int[] ZahtevVersion1(int kolicinaMonitora, int kolicinaTastatura)
        {
            int[] array = new int[2];
            array[0] = kolicinaMonitora;
            array[1] = kolicinaTastatura;
            return array;
        }
        public Dictionary<int, int> ZahtevVersion2()
        {
            Dictionary<int, int> zahtev = new Dictionary<int, int>();
            bool checkInput;
            bool checkYesNo;
            string input;
            int idProizvoda;
            int kolicinaProizvoda;
            Console.WriteLine("Popunite zahtev.");
            do
            {
                Console.Write("Izaberite id proizvoda: ");
                input = Console.ReadLine();
                checkInput = int.TryParse(input, out idProizvoda);
                if(!checkInput || idProizvoda < 1)
                {
                    continue;
                }
                Console.Write("Izaberite kolicinu: ");
                input = Console.ReadLine();
                checkInput = int.TryParse(input, out kolicinaProizvoda);
                if(!checkInput)
                {
                    continue;
                }
                if(!zahtev.ContainsKey(idProizvoda))
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
                        checkYesNo = false;
                        continue;
                    }else if(input == "da")
                    {
                        checkYesNo = true;
                        checkInput = false;
                        break;
                    }else
                    {
                        checkYesNo = true;
                    }
                } while (checkYesNo == false);
                
            }while(checkInput == false);
            return zahtev;
        }
    }
}