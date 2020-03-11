using System;
using System.Collections.Generic;

namespace Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pirate> HollandPirates = new List<Pirate>();
            HollandPirates.Add(new Gunner("Rindert"));
            HollandPirates.Add(new Quartermaster("Manon"));
            HollandPirates.Add(new Carpenter("Gaula"));
            HollandPirates.Add(new Captain("Remco", "Dutch"));

            Ship schip1 = new Ship(HollandPirates);

            // haal schip gegevens op
            Console.WriteLine("Schip1 vaart met de volgende piraten aan boord:");
            List<string> pirates = schip1.GetPirates();
            foreach (string name in pirates)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
            string[] captin = schip1.GetCaptain();
            if (captin[0] != null)
                Console.WriteLine("De capitein is " + captin[0] + " en vaart onder de " + captin[1] + " vlag.");
            else
                Console.WriteLine("Zeer bijzonder, maar er is geen kapitein!");

            int keuze = 0;
            do
            {
                keuze = AskWhatToDo();
                switch(keuze)
                {
                    case 1:
                        Console.Write("Hoe heet het schip dat je gaat aanvallen? ");
                        string naam = Console.ReadLine();
                        (int value, List<string> names) = schip1.Enter(naam);
                        for (int i = 0; i < names.Count; i += 2)
                            Console.WriteLine(names[i] + " heeft €" + names[i + 1] + " buit gemaakt!");
                        Console.WriteLine("Je hebt €" + Convert.ToString(value) + " buit gemaakt op " + naam + "!");
                        break;
                    case 2:
                        Console.WriteLine("Je hebt de volgende buiten:");
                        List<string> loots = schip1.GetLoot().GetLoots();
                        for (int i = 0; i < loots.Count; i += 2)
                            Console.WriteLine("Op " + loots[i] + " hebben jullie €" + loots[i + 1] + " buit gemaakt!");
                        break;

                }
            } while (keuze != 0);

        }

        private static int AskWhatToDo()
        {
            Console.WriteLine("Maak een keuze op een actie uit te voeren:");
            Console.WriteLine("0. Stop");
            Console.WriteLine("1. Val een schip aan");
            Console.WriteLine("2. Bekijk buiten");
            Console.Write("Jouw keuze: ");
            int keuze = Convert.ToInt32(Console.ReadLine());
            return keuze;
        }


    }
}
