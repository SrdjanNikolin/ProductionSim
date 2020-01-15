using System;

namespace ProductionSimulation.Validacija
{
    //TODO: Mozda promeniti u validacujuZahteva? Pogledati svakako...
    public class ValidacijaProizvoda
    {
        public void Validacija (ref int id, ref int kolicina)
        {
            string input;
            bool checkInput;
            Console.WriteLine("Popunite zahtev.");
            do
            {
                Console.Write("Izaberite id proizvoda: ");
                input = Console.ReadLine();
                checkInput = int.TryParse(input, out id);
                if (!checkInput || id < 1)
                {
                    continue;
                }
                Console.Write("Izaberite kolicinu: ");
                input = Console.ReadLine();
                checkInput = int.TryParse(input, out kolicina);
                if (!checkInput || kolicina < 1)
                {
                    checkInput = false;
                    Console.WriteLine("Molimo unesite kolicinu.");
                }
            } while (checkInput == false);
        }
    }
}